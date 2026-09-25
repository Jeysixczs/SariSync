import { useEffect, useMemo, useState } from 'react'
import { Minus, Plus, Search, ShoppingCart, Trash2 } from 'lucide-react'
import Modal from '../components/Modal'
import { subscribeProducts, getNotExpired, searchProducts } from '../services/productService'
import { checkout } from '../services/orderService'
import { formatCurrency, formatDateTime } from '../utils/format'

export default function PointOfSale() {
  const [products, setProducts] = useState([])
  const [search, setSearch] = useState('')
  const [cart, setCart] = useState([]) // { productId, productName, unitPrice, quantity, stock }
  const [customerName, setCustomerName] = useState('')
  const [notes, setNotes] = useState('')
  const [remarks, setRemarks] = useState('')
  const [isPaid, setIsPaid] = useState(true)
  const [busy, setBusy] = useState(false)
  const [error, setError] = useState('')
  const [receipt, setReceipt] = useState(null)

  useEffect(() => subscribeProducts(setProducts), [])

  const available = useMemo(() => {
    const sellable = getNotExpired(products).filter((p) => p.stock > 0)
    return searchProducts(sellable, search)
  }, [products, search])

  const total = useMemo(() => cart.reduce((sum, i) => sum + i.unitPrice * i.quantity, 0), [cart])

  function addToCart(product) {
    setCart((prev) => {
      const existing = prev.find((i) => i.productId === product.id)
      if (existing) {
        if (existing.quantity >= product.stock) return prev
        return prev.map((i) => (i.productId === product.id ? { ...i, quantity: i.quantity + 1 } : i))
      }
      return [
        ...prev,
        { productId: product.id, productName: product.name, unitPrice: product.sellingPrice, quantity: 1, stock: product.stock },
      ]
    })
  }

  function changeQty(productId, delta) {
    setCart((prev) =>
      prev
        .map((i) =>
          i.productId === productId
            ? { ...i, quantity: Math.max(1, Math.min(i.stock, i.quantity + delta)) }
            : i
        )
    )
  }

  function removeFromCart(productId) {
    setCart((prev) => prev.filter((i) => i.productId !== productId))
  }

  async function handleCheckout() {
    setError('')
    setBusy(true)
    try {
      const orderId = await checkout({ customerName, notes, remarks, isPaid, cart })
      setReceipt({
        orderId,
        customerName: customerName || 'Walk-in',
        items: cart,
        total,
        isPaid,
        date: new Date(),
      })
      setCart([])
      setCustomerName('')
      setNotes('')
      setRemarks('')
    } catch (err) {
      setError(err.message || 'Checkout failed.')
    } finally {
      setBusy(false)
    }
  }

  return (
    <div className="grid grid-cols-1 gap-6 lg:grid-cols-3">
      <div className="lg:col-span-2 space-y-4">
        <div className="relative">
          <Search size={16} className="absolute left-3 top-1/2 -translate-y-1/2 text-slate-400" />
          <input
            className="input pl-9"
            placeholder="Search products…"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
          />
        </div>
        <div className="grid grid-cols-2 gap-3 sm:grid-cols-3">
          {available.map((p) => (
            <button
              key={p.id}
              onClick={() => addToCart(p)}
              className="card flex flex-col items-start p-3 text-left transition hover:border-brand-400 hover:shadow-md"
            >
              {p.imageUrl ? (
                <img src={p.imageUrl} alt={p.name} className="mb-2 h-20 w-full rounded-lg object-cover" />
              ) : (
                <div className="mb-2 h-20 w-full rounded-lg bg-slate-100" />
              )}
              <p className="text-sm font-medium text-slate-700 line-clamp-1">{p.name}</p>
              <p className="text-xs text-slate-400">{p.stock} in stock</p>
              <p className="mt-1 font-semibold text-brand-700">{formatCurrency(p.sellingPrice)}</p>
            </button>
          ))}
          {available.length === 0 && (
            <p className="col-span-full py-8 text-center text-slate-400">No available products.</p>
          )}
        </div>
      </div>

      <div className="card flex flex-col p-4">
        <h3 className="mb-3 flex items-center gap-2 font-semibold text-slate-700">
          <ShoppingCart size={16} /> Cart
        </h3>
        <div className="flex-1 space-y-3 overflow-y-auto">
          {cart.map((item) => (
            <div key={item.productId} className="flex items-center justify-between gap-2 text-sm">
              <div className="min-w-0 flex-1">
                <p className="truncate font-medium text-slate-700">{item.productName}</p>
                <p className="text-xs text-slate-400">{formatCurrency(item.unitPrice)} each</p>
              </div>
              <div className="flex items-center gap-1">
                <button className="rounded p-1 hover:bg-slate-100" onClick={() => changeQty(item.productId, -1)}>
                  <Minus size={14} />
                </button>
                <span className="w-6 text-center">{item.quantity}</span>
                <button className="rounded p-1 hover:bg-slate-100" onClick={() => changeQty(item.productId, 1)}>
                  <Plus size={14} />
                </button>
              </div>
              <button className="text-red-400 hover:text-red-600" onClick={() => removeFromCart(item.productId)}>
                <Trash2 size={14} />
              </button>
            </div>
          ))}
          {cart.length === 0 && <p className="text-sm text-slate-400">Cart is empty. Tap a product to add it.</p>}
        </div>

        <div className="mt-4 space-y-3 border-t border-slate-200 pt-4">
          <input className="input" placeholder="Customer name (optional)" value={customerName} onChange={(e) => setCustomerName(e.target.value)} />
          <input className="input" placeholder="Notes" value={notes} onChange={(e) => setNotes(e.target.value)} />
          <input className="input" placeholder="Remarks" value={remarks} onChange={(e) => setRemarks(e.target.value)} />
          <label className="flex items-center gap-2 text-sm text-slate-600">
            <input type="checkbox" checked={isPaid} onChange={(e) => setIsPaid(e.target.checked)} />
            Mark as paid
          </label>
          {error && <p className="text-sm text-red-600">{error}</p>}
          <div className="flex items-center justify-between text-lg font-semibold text-slate-800">
            <span>Total</span>
            <span>{formatCurrency(total)}</span>
          </div>
          <button className="btn-primary w-full" disabled={busy || cart.length === 0} onClick={handleCheckout}>
            {busy ? 'Processing…' : 'Complete order'}
          </button>
        </div>
      </div>

      <Modal open={!!receipt} title="Receipt" onClose={() => setReceipt(null)} width="max-w-sm">
        {receipt && (
          <div className="space-y-3 text-sm">
            <div className="text-center">
              <p className="font-semibold">SariSync Store</p>
              <p className="text-xs text-slate-400">Order #{receipt.orderId.slice(0, 8).toUpperCase()}</p>
              <p className="text-xs text-slate-400">{formatDateTime(receipt.date)}</p>
            </div>
            <div className="border-t border-dashed border-slate-300 pt-2">
              <p>Customer: {receipt.customerName}</p>
            </div>
            <div className="space-y-1 border-t border-dashed border-slate-300 pt-2">
              {receipt.items.map((i) => (
                <div key={i.productId} className="flex justify-between">
                  <span>{i.quantity} × {i.productName}</span>
                  <span>{formatCurrency(i.unitPrice * i.quantity)}</span>
                </div>
              ))}
            </div>
            <div className="flex justify-between border-t border-dashed border-slate-300 pt-2 font-semibold">
              <span>Total</span>
              <span>{formatCurrency(receipt.total)}</span>
            </div>
            <p className="text-center text-xs text-slate-400">{receipt.isPaid ? 'PAID' : 'UNPAID'}</p>
            <button className="btn-secondary w-full" onClick={() => window.print()}>Print receipt</button>
          </div>
        )}
      </Modal>
    </div>
  )
}
