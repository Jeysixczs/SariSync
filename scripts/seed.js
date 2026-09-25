// Optional helper to seed a few sample suppliers and products.
//
// 1. In the Firebase console, go to Project settings -> Service accounts ->
//    Generate new private key, and save it as serviceAccountKey.json in this
//    project's root (it's git-ignored).
// 2. npm install firebase-admin --save-dev
// 3. npm run seed

import { readFileSync } from 'node:fs'
import { initializeApp, cert } from 'firebase-admin/app'
import { getFirestore, Timestamp } from 'firebase-admin/firestore'

const serviceAccount = JSON.parse(readFileSync('./serviceAccountKey.json', 'utf8'))
initializeApp({ credential: cert(serviceAccount) })
const db = getFirestore()

async function seed() {
  const supplierRef = await db.collection('suppliers').add({
    supplierName: 'Sample Distributor Co.',
    contactPerson: 'Juan Dela Cruz',
    phoneNumber: '0917-000-0000',
    address: 'Quezon City, Metro Manila',
    createdDate: Timestamp.now(),
    isActive: true,
  })

  const sampleProducts = [
    { name: 'Instant Noodles', category: 'Groceries', price: 10, sellingPrice: 15, stock: 100 },
    { name: 'Bottled Water 500ml', category: 'Beverages', price: 8, sellingPrice: 12, stock: 80 },
    { name: 'Canned Sardines', category: 'Groceries', price: 18, sellingPrice: 25, stock: 60 },
    { name: 'Cooking Oil 1L', category: 'Groceries', price: 90, sellingPrice: 110, stock: 30 },
    { name: 'Softdrinks 1.5L', category: 'Beverages', price: 55, sellingPrice: 70, stock: 40 },
  ]

  for (const p of sampleProducts) {
    await db.collection('products').add({
      ...p,
      description: '',
      imageUrl: '',
      dateAdded: Timestamp.now(),
      dateExpired: null,
      isActive: true,
      supplierId: supplierRef.id,
      supplierName: 'Sample Distributor Co.',
      supplierPayment: 0,
    })
  }

  console.log('Seeded 1 supplier and 5 products.')
}

seed().then(() => process.exit(0)).catch((err) => {
  console.error(err)
  process.exit(1)
})
