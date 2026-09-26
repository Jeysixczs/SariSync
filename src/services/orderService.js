import {
  collection,
  doc,
  getDoc,
  getDocs,
  onSnapshot,
  orderBy,
  query,
  runTransaction,
  serverTimestamp,
  updateDoc,
  where,
} from 'firebase/firestore'
import { auth, db } from '../firebase'
import { toDate } from '../utils/format'

const COLLECTION = 'orders'
const PRODUCTS_COLLECTION = 'products'
const ordersRef = collection(db, COLLECTION)

function storeId() {
  return auth.currentUser?.uid
}

function mapOrder(docSnap) {
  const data = docSnap.data()
  return {
    id: docSnap.id,
    customerName: data.customerName ?? 'Walk-in',
    notes: data.notes ?? '',
    remarks: data.remarks ?? '',
    orderDate: toDate(data.orderDate),
    isPaid: !!data.isPaid,
    totalAmount: data.totalAmount ?? 0,
    items: data.items ?? [],
  }
}

export function subscribeOrders(onChange) {
  const q = query(ordersRef, where('storeId', '==', storeId()), orderBy('orderDate', 'desc'))
  return onSnapshot(q, (snap) => onChange(snap.docs.map(mapOrder)))
}

export async function getAllOrders() {
  const q = query(ordersRef, where('storeId', '==', storeId()), orderBy('orderDate', 'desc'))
  const snap = await getDocs(q)
  return snap.docs.map(mapOrder)
}

export async function getOrderWithDetails(id) {
  const snap = await getDoc(doc(db, COLLECTION, id))
  return snap.exists() ? mapOrder(snap) : null
}

export function searchOrders(orders, term) {
  const t = term.trim().toLowerCase()
  if (!t) return orders
  return orders.filter(
    (o) =>
      String(o.id).toLowerCase().includes(t) ||
      (o.customerName || '').toLowerCase().includes(t) ||
      (o.notes || '').toLowerCase().includes(t) ||
      (o.remarks || '').toLowerCase().includes(t)
  )
}

/**
 * Creates an order and decrements product stock atomically, mirroring
 * Orders.ProcessOrder() in the original WinForms app (insert order + details,
 * then reduce tbl_Product.Stock inside one DB transaction).
 *
 * cart: [{ productId, productName, quantity, unitPrice }]
 */
export async function checkout({ customerName, notes, remarks, isPaid, cart }) {
  if (!cart?.length) throw new Error('Cart is empty.')

  return runTransaction(db, async (tx) => {
    const productRefs = cart.map((item) => doc(db, PRODUCTS_COLLECTION, item.productId))
    const productSnaps = await Promise.all(productRefs.map((ref) => tx.get(ref)))

    let totalAmount = 0
    const items = cart.map((item, i) => {
      const snap = productSnaps[i]
      if (!snap.exists()) throw new Error(`Product "${item.productName}" no longer exists.`)
      const stock = snap.data().stock ?? 0
      if (stock < item.quantity) {
        throw new Error(`Insufficient stock for "${item.productName}" (only ${stock} left).`)
      }
      const totalPrice = item.quantity * item.unitPrice
      totalAmount += totalPrice
      return {
        productId: item.productId,
        productName: item.productName,
        quantity: item.quantity,
        unitPrice: item.unitPrice,
        totalPrice,
      }
    })

    productRefs.forEach((ref, i) => {
      const newStock = (productSnaps[i].data().stock ?? 0) - cart[i].quantity
      tx.update(ref, { stock: newStock })
    })

    const newOrderRef = doc(ordersRef)
    tx.set(newOrderRef, {
      customerName: customerName || 'Walk-in',
      notes: notes || '',
      remarks: remarks || '',
      orderDate: serverTimestamp(),
      isPaid: !!isPaid,
      totalAmount,
      items,
      storeId: storeId(),
    })

    return newOrderRef.id
  })
}

export async function markOrderAsPaid(id) {
  await updateDoc(doc(db, COLLECTION, id), { isPaid: true })
}
