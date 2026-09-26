import {
  addDoc,
  collection,
  deleteField,
  doc,
  getDoc,
  getDocs,
  onSnapshot,
  orderBy,
  query,
  serverTimestamp,
  updateDoc,
  where,
} from 'firebase/firestore'
import { auth, db } from '../firebase'
import { uploadImage } from './cloudinary'
import { toDate } from '../utils/format'

const COLLECTION = 'products'
const productsRef = collection(db, COLLECTION)

// Each signed-in account only ever sees its own store's data: every query is
// scoped to storeId == the current user's uid, and every new document is
// tagged with it on create. See firestore.rules for the server-side half of
// this (client-side filtering alone doesn't stop cross-account access).
function storeId() {
  return auth.currentUser?.uid
}

function mapProduct(docSnap) {
  const data = docSnap.data()
  return {
    id: docSnap.id,
    name: data.name ?? '',
    description: data.description ?? '',
    category: data.category ?? '',
    price: data.price ?? 0,
    sellingPrice: data.sellingPrice ?? 0,
    stock: data.stock ?? 0,
    imageUrl: data.imageUrl ?? '',
    dateAdded: toDate(data.dateAdded),
    dateExpired: toDate(data.dateExpired),
    isActive: data.isActive !== false,
    supplierId: data.supplierId ?? '',
    supplierName: data.supplierName ?? '',
    supplierPayment: data.supplierPayment ?? 0,
  }
}

// Realtime subscription to all active products (used by Products page, POS, Dashboard)
export function subscribeProducts(onChange, { includeInactive = false } = {}) {
  const q = includeInactive
    ? query(productsRef, where('storeId', '==', storeId()), orderBy('name'))
    : query(productsRef, where('storeId', '==', storeId()), where('isActive', '==', true), orderBy('name'))
  return onSnapshot(q, (snap) => {
    onChange(snap.docs.map(mapProduct))
  })
}

export async function getAllProducts() {
  const q = query(productsRef, where('storeId', '==', storeId()), where('isActive', '==', true), orderBy('name'))
  const snap = await getDocs(q)
  return snap.docs.map(mapProduct)
}

// Products with no expiry date, or an expiry date in the future
export function getNotExpired(products) {
  const now = new Date()
  return products.filter((p) => !p.dateExpired || p.dateExpired > now)
}

export function getExpired(products) {
  const now = new Date()
  return products.filter((p) => p.dateExpired && p.dateExpired < now)
}

// Expiring within the next 30 days but not yet expired
export function getCriticallyExpiring(products) {
  const now = new Date()
  const in30 = new Date()
  in30.setDate(in30.getDate() + 30)
  return products.filter((p) => p.dateExpired && p.dateExpired >= now && p.dateExpired <= in30)
}

export function getStockLevel(products, level) {
  if (level === 'low') return products.filter((p) => p.stock < 10)
  if (level === 'medium') return products.filter((p) => p.stock >= 10 && p.stock <= 50)
  if (level === 'high') return products.filter((p) => p.stock > 50)
  return products
}

export function getCategories(products) {
  return [...new Set(products.map((p) => p.category).filter(Boolean))].sort()
}

// Pure, synchronous — checks against an already-loaded products list instead
// of firing an extra Firestore query on every save. Callers pass in whatever
// list they already have from the shared subscription (see DataContext).
export function checkDuplicateProduct(products, name, excludeId = null) {
  return products.some(
    (p) => p.id !== excludeId && p.isActive !== false && p.name.toLowerCase() === name.toLowerCase()
  )
}

export async function uploadProductImage(productId, file) {
  const { url } = await uploadImage(file, `product-images/${productId}`)
  return url
}

// imageFile (admin's own upload) always wins over suggestedImageUrl (the
// Pexels auto-suggestion shown in the form) when both are present.
// existingProducts: the caller's already-loaded product list, used only for
// the client-side duplicate-name check above (no extra read).
export async function addProduct(product, imageFile, suggestedImageUrl, existingProducts = []) {
  if (checkDuplicateProduct(existingProducts, product.name)) {
    throw new Error('A product with the same name already exists.')
  }
  const payload = {
    name: product.name,
    description: product.description || '',
    category: product.category,
    price: Number(product.price) || 0,
    sellingPrice: Number(product.sellingPrice) || 0,
    stock: Number(product.stock) || 0,
    imageUrl: imageFile ? '' : suggestedImageUrl || '',
    dateAdded: serverTimestamp(),
    dateExpired: product.dateExpired ? new Date(product.dateExpired) : null,
    isActive: true,
    supplierId: product.supplierId || '',
    supplierName: product.supplierName || '',
    supplierPayment: Number(product.supplierPayment) || 0,
    storeId: storeId(),
  }
  const docRef = await addDoc(productsRef, payload)
  if (imageFile) {
    const url = await uploadProductImage(docRef.id, imageFile)
    await updateDoc(docRef, { imageUrl: url })
  }
  return docRef.id
}

export async function updateProduct(id, product, imageFile, suggestedImageUrl) {
  const payload = {
    name: product.name,
    description: product.description || '',
    category: product.category,
    price: Number(product.price) || 0,
    sellingPrice: Number(product.sellingPrice) || 0,
    stock: Number(product.stock) || 0,
    dateExpired: product.dateExpired ? new Date(product.dateExpired) : null,
    supplierId: product.supplierId || '',
    supplierName: product.supplierName || '',
    supplierPayment: Number(product.supplierPayment) || 0,
  }
  if (imageFile) {
    payload.imageUrl = await uploadProductImage(id, imageFile)
  } else if (suggestedImageUrl) {
    payload.imageUrl = suggestedImageUrl
  }
  await updateDoc(doc(db, COLLECTION, id), payload)
}

// Soft delete, mirroring the WinForms app's IsActive = 0 pattern
export async function deleteProduct(id) {
  await updateDoc(doc(db, COLLECTION, id), { isActive: false })
}

export async function deleteMultipleProducts(ids) {
  await Promise.all(ids.map((id) => deleteProduct(id)))
}

export async function getProductById(id) {
  const snap = await getDoc(doc(db, COLLECTION, id))
  return snap.exists() ? mapProduct(snap) : null
}

export function searchProducts(products, term) {
  const t = term.trim().toLowerCase()
  if (!t) return products
  return products.filter(
    (p) =>
      p.name.toLowerCase().includes(t) ||
      p.category.toLowerCase().includes(t) ||
      (p.description || '').toLowerCase().includes(t)
  )
}

export async function removeProductImage(id) {
  // Note: unsigned Cloudinary uploads can only be deleted via a signed/
  // authenticated request (needs a backend), so this just detaches the
  // reference in Firestore. The unused image stays in Cloudinary storage.
  await updateDoc(doc(db, COLLECTION, id), { imageUrl: deleteField() })
}
