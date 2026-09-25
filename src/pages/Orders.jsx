import { useEffect, useMemo, useState } from 'react'
import { CheckCircle2, Search } from 'lucide-react'
import Modal from '../components/Modal'
import { subscribeOrders, searchOrders, markOrderAsPaid } from '../services/orderService'
import { formatCurrency, formatDateTime } from '../utils/format'

export default function Orders() {
  const [orders, setOrders] = useState([])
  const [search, setSearch] = useState('')
  const [selected, setSelected] = useState(null)

  useEffect(() => subscribeOrders(setOrders), [])

  const filtered = useMemo(() => searchOrders(orders, search), [orders, search])

  async function handleMarkPaid(order) {
    await markOrderAsPaid(order.id)
    setSelected((prev) => (prev && prev.id === order.id ? { ...prev, isPaid: true } : prev))
  }

  return (
    <div className="space-y-4">
      <div className="relative w-full sm:w-72">
        <Search size={16} className="absolute left-3 top-1/2 -translate-y-1/2 text-slate-400" />
        <input
          className="input pl-9"
          placeholder="Search by order #, customer, notes…"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
      </div>

      <div className="card overflow-x-auto">
        <table className="table-base">
          <thead>
            <tr>
              <th>Order</th>
              <th>Customer</th>
              <th>Date</th>
              <th>Items</th>
              <th>Total</th>
              <th>Status</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {filtered.map((o) => (
              <tr key={o.id} className="cursor-pointer hover:bg-slate-50" onClick={() => setSelected(o)}>
                <td className="font-mono text-xs text-slate-500">#{o.id.slice(0, 8).toUpperCase()}</td>
                <td>{o.customerName}</td>
                <td>{formatDateTime(o.orderDate)}</td>
                <td>{o.items.length}</td>
                <td className="font-medium">{formatCurrency(o.totalAmount)}</td>
                <td>
                  <span className={`rounded-full px-2 py-0.5 text-xs font-medium ${o.isPaid ? 'bg-brand-50 text-brand-700' : 'bg-amber-50 text-amber-700'}`}>
                    {o.isPaid ? 'Paid' : 'Unpaid'}
                  </span>
                </td>
                <td>
                  {!o.isPaid && (
                    <button
                      className="flex items-center gap-1 text-xs text-brand-700 hover:underline"
                      onClick={(e) => {
                        e.stopPropagation()
                        handleMarkPaid(o)
                      }}
                    >
                      <CheckCircle2 size={14} /> Mark paid
                    </button>
                  )}
                </td>
              </tr>
            ))}
            {filtered.length === 0 && (
              <tr>
                <td colSpan={7} className="py-8 text-center text-slate-400">No orders found.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <Modal open={!!selected} title={`Order #${selected?.id.slice(0, 8).toUpperCase() || ''}`} onClose={() => setSelected(null)}>
        {selected && (
          <div className="space-y-4 text-sm">
            <div className="grid grid-cols-1 gap-2 sm:grid-cols-2">
              <div>
                <p className="text-xs text-slate-400">Customer</p>
                <p className="font-medium">{selected.customerName}</p>
              </div>
              <div>
                <p className="text-xs text-slate-400">Date</p>
                <p className="font-medium">{formatDateTime(selected.orderDate)}</p>
              </div>
              <div>
                <p className="text-xs text-slate-400">Notes</p>
                <p className="font-medium">{selected.notes || '—'}</p>
              </div>
              <div>
                <p className="text-xs text-slate-400">Remarks</p>
                <p className="font-medium">{selected.remarks || '—'}</p>
              </div>
            </div>
            <table className="table-base">
              <thead>
                <tr>
                  <th>Product</th>
                  <th>Qty</th>
                  <th>Unit price</th>
                  <th>Total</th>
                </tr>
              </thead>
              <tbody>
                {selected.items.map((i, idx) => (
                  <tr key={idx}>
                    <td>{i.productName}</td>
                    <td>{i.quantity}</td>
                    <td>{formatCurrency(i.unitPrice)}</td>
                    <td>{formatCurrency(i.totalPrice)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
            <div className="flex items-center justify-between border-t border-slate-200 pt-3">
              <span className={`rounded-full px-2 py-0.5 text-xs font-medium ${selected.isPaid ? 'bg-brand-50 text-brand-700' : 'bg-amber-50 text-amber-700'}`}>
                {selected.isPaid ? 'Paid' : 'Unpaid'}
              </span>
              <span className="text-lg font-semibold">{formatCurrency(selected.totalAmount)}</span>
            </div>
            {!selected.isPaid && (
              <button className="btn-primary w-full" onClick={() => handleMarkPaid(selected)}>
                Mark as paid
              </button>
            )}
          </div>
        )}
      </Modal>
    </div>
  )
}
