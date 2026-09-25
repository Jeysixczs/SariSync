# SariSync Web

A React + Firebase rebuild of the **SariSync** WinForms admin app
(`SariSariStore.Admin` / `SariSariStore.Core`). Same features, running in the
browser instead of on one Windows PC, with Firestore instead of SQL Server.

## What moved where

| WinForms (SQL Server) | Web app (Firebase) |
|---|---|
| `LoginForm` | `src/pages/Login.jsx` — Firebase Authentication (email/password) |
| `DashboardForm` | `src/pages/Dashboard.jsx` — live KPIs + 7‑day sales chart |
| `ProductForm` / `AddEditProductForm` / `InventoryForm` | `src/pages/Products.jsx` — Firestore `products` collection, images in Firebase Storage |
| `AddEditSupplierForm` | `src/pages/Suppliers.jsx` — Firestore `suppliers` collection |
| `PointOfSaleForm` / `Register` / `ReceiptForm` | `src/pages/PointOfSale.jsx` — cart + checkout runs as one Firestore transaction (creates the order **and** decrements stock atomically, same guarantee as the old SQL transaction) |
| `HistoryF` / `OrderDetailsForm` | `src/pages/Orders.jsx` — Firestore `orders` collection (order items are stored inline on the order document) |
| `ReportFrom` / `ReportPrint` | `src/pages/Reports.jsx` — sales-by-product, daily, monthly and date-range reports, computed client-side from the orders you already have loaded |
| `ExpiredForm` / `NotificationForm` | `src/pages/ExpiredProducts.jsx` — expired items and items expiring within 30 days |
| `tbl_Product`, `tbl_suppliers`, `tbl_Order`, `tbl_OrderDetails` | Firestore collections `products`, `suppliers`, `orders` (order details are embedded, not a separate collection) |

Soft deletes are preserved: removing a product or supplier sets `isActive:
false` instead of deleting the document, exactly like the old
`UPDATE ... SET IsActive = 0` calls.

## 1. Create a Firebase project

1. Go to the [Firebase console](https://console.firebase.google.com/) → **Add project**.
2. Enable **Authentication** → Sign-in method → **Email/Password**.
3. Enable **Firestore Database** (start in production mode; the rules below lock it down).
4. Enable **Storage** (for product photos).
5. In **Project settings → General → Your apps**, add a **Web app** and copy the config values.
6. Create your first admin/cashier login under **Authentication → Users → Add user** (there's no public sign-up screen — this is an internal admin tool, same as the desktop app).

## 2. Configure the app

```bash
cp .env.example .env
# paste the values from the Firebase console into .env
```

## 3. Install and run

```bash
npm install
npm run dev
```

Open the printed local URL and sign in with the user you created in step 1.

## 4. Deploy security rules

The included `firestore.rules` and `storage.rules` only allow access to
signed-in users (there's no customer-facing part of this app, so this mirrors
the "only staff can run the desktop app" model). Deploy them with the
[Firebase CLI](https://firebase.google.com/docs/cli):

```bash
npm install -g firebase-tools
firebase login
firebase use --add        # pick your project
firebase deploy --only firestore:rules,storage:rules
```

## 5. (Optional) seed sample data

```bash
npm install firebase-admin --save-dev
# download a service account key (Project settings -> Service accounts)
# save it as ./serviceAccountKey.json (already git-ignored)
npm run seed
```

## 6. Build & deploy the site

```bash
npm run build
firebase deploy --only hosting
```

## Data model (Firestore)

**`products`**
`name, description, category, price, sellingPrice, stock, imageUrl, dateAdded, dateExpired, isActive, supplierId, supplierName, supplierPayment`

**`suppliers`**
`supplierName, contactPerson, phoneNumber, address, createdDate, isActive`

**`orders`**
`customerName, notes, remarks, orderDate, isPaid, totalAmount, items: [{productId, productName, quantity, unitPrice, totalPrice}]`

## Notes on the port

- The original app's `ConnectionHelper` pointed at a specific local SQL Server
  instance (`JEYSI\SQLEXPRESS`) — that's gone; Firestore is the database now,
  reachable from any browser, not just one PC.
- Stock validation on checkout (`ProcessOrder`'s "insufficient stock" check)
  is reproduced inside a Firestore transaction in `src/services/orderService.js`.
- Reports were originally computed with SQL `GROUP BY`. Firestore doesn't do
  server-side aggregation like that, so `src/services/reportService.js`
  recomputes the same aggregates from the orders already loaded in the browser.
  This is fine at sari-sari-store scale; if the order history grows very
  large, move this into a scheduled Cloud Function instead.
- Multi-supplier product image storage now uses Firebase Storage instead of
  a local `ProductImages` folder next to the `.exe`.
