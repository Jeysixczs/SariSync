import {
  addDoc,
  collection,
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
import { db } from '../firebase'
import { toDate } from '../utils/format'

const COLLECTION = 'suppliers'
const suppliersRef = collection(db, COLLECTION)

function mapSupplier(docSnap) {
  const data = docSnap.data()
  return {
    id: docSnap.id,
    supplierName: data.supplierName ?? '',
    contactPerson: data.contactPerson ?? '',
    phoneNumber: data.phoneNumber ?? '',
    address: data.address ?? '',
    createdDate: toDate(data.createdDate),
    isActive: data.isActive !== false,
  }
}

export function subscribeSuppliers(onChange) {
  const q = query(suppliersRef, where('isActive', '==', true), orderBy('supplierName'))
  return onSnapshot(q, (snap) => onChange(snap.docs.map(mapSupplier)))
}

export async function getAllSuppliers() {
  const q = query(suppliersRef, where('isActive', '==', true), orderBy('supplierName'))
  const snap = await getDocs(q)
  return snap.docs.map(mapSupplier)
}

export async function getSupplierById(id) {
  const snap = await getDoc(doc(db, COLLECTION, id))
  return snap.exists() ? mapSupplier(snap) : null
}

export async function addSupplier(supplier) {
  const docRef = await addDoc(suppliersRef, {
    supplierName: supplier.supplierName,
    contactPerson: supplier.contactPerson || '',
    phoneNumber: supplier.phoneNumber || '',
    address: supplier.address || '',
    createdDate: serverTimestamp(),
    isActive: true,
  })
  return docRef.id
}

export async function updateSupplier(id, supplier) {
  await updateDoc(doc(db, COLLECTION, id), {
    supplierName: supplier.supplierName,
    contactPerson: supplier.contactPerson || '',
    phoneNumber: supplier.phoneNumber || '',
    address: supplier.address || '',
  })
}

// Soft delete, same pattern as the WinForms app
export async function deleteSupplier(id) {
  await updateDoc(doc(db, COLLECTION, id), { isActive: false })
}
