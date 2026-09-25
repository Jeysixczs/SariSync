import { useEffect, useMemo, useState } from 'react'
import { subscribeOrders } from '../services/orderService'
import {
  buildProductSalesReport,
  buildDailySalesReport,
  buildMonthlySalesReport,
  filterOrdersByDateRange,
} from '../services/reportService'
import { formatCurrency, formatDate } from '../utils/format'

const TABS = [
  { id: 'products', label: 'Sales by product' },
  { id: 'daily', label: 'Daily sales' },
  { id: 'monthly', label: 'Monthly sales' },
  { id: 'range', label: 'Date range' },
]

const MONTH_NAMES = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

export default function Reports() {
  const [orders, setOrders] = useState([])
  const [tab, setTab] = useState('products')
  const [startDate, setStartDate] = useState('')
  const [endDate, setEndDate] = useState('')

  useEffect(() => subscribeOrders(setOrders), [])

  const productReport = useMemo(() => buildProductSalesReport(orders), [orders])
  const dailyReport = useMemo(() => buildDailySalesReport(orders), [orders])
  const monthlyReport = useMemo(() => buildMonthlySalesReport(orders), [orders])

  const rangeOrders = useMemo(() => {
    if (!startDate || !endDate) return []
    return filterOrdersByDateRange(orders, startDate, endDate)
  }, [orders, startDate, endDate])

  const rangeTotal = useMemo(() => rangeOrders.reduce((sum, o) => sum + o.totalAmount, 0), [rangeOrders])

  return (
    <div className="space-y-4">
      <div className="flex gap-2 border-b border-slate-200">
        {TABS.map((t) => (
          <button
            key={t.id}
            onClick={() => setTab(t.id)}
            className={`px-4 py-2 text-sm font-medium ${
              tab === t.id ? 'border-b-2 border-brand-600 text-brand-700' : 'text-slate-500 hover:text-slate-700'
            }`}
          >
            {t.label}
          </button>
        ))}
      </div>

      {tab === 'products' && (
        <div className="card overflow-x-auto">
          <table className="table-base">
            <thead>
              <tr>
                <th>Product</th>
                <th>Qty sold</th>
                <th>Unit price</th>
                <th>Revenue</th>
                <th>Orders</th>
              </tr>
            </thead>
            <tbody>
              {productReport.map((r) => (
                <tr key={r.productId}>
                  <td>{r.productName}</td>
                  <td>{r.totalQuantitySold}</td>
                  <td>{formatCurrency(r.unitPrice)}</td>
                  <td className="font-medium">{formatCurrency(r.totalRevenue)}</td>
                  <td>{r.numberOfOrders}</td>
                </tr>
              ))}
              {productReport.length === 0 && (
                <tr><td colSpan={5} className="py-8 text-center text-slate-400">No sales yet.</td></tr>
              )}
            </tbody>
          </table>
        </div>
      )}

      {tab === 'daily' && (
        <div className="card overflow-x-auto">
          <table className="table-base">
            <thead>
              <tr>
                <th>Date</th>
                <th>Orders</th>
                <th>Total sales</th>
                <th>Average order</th>
              </tr>
            </thead>
            <tbody>
              {dailyReport.map((r) => (
                <tr key={r.date}>
                  <td>{formatDate(r.date)}</td>
                  <td>{r.numberOfOrders}</td>
                  <td className="font-medium">{formatCurrency(r.dailySales)}</td>
                  <td>{formatCurrency(r.avgSales)}</td>
                </tr>
              ))}
              {dailyReport.length === 0 && (
                <tr><td colSpan={4} className="py-8 text-center text-slate-400">No sales yet.</td></tr>
              )}
            </tbody>
          </table>
        </div>
      )}

      {tab === 'monthly' && (
        <div className="card overflow-x-auto">
          <table className="table-base">
            <thead>
              <tr>
                <th>Month</th>
                <th>Orders</th>
                <th>Total sales</th>
                <th>Average order</th>
              </tr>
            </thead>
            <tbody>
              {monthlyReport.map((r) => (
                <tr key={r.key}>
                  <td>{MONTH_NAMES[r.month - 1]} {r.year}</td>
                  <td>{r.totalOrders}</td>
                  <td className="font-medium">{formatCurrency(r.monthlySales)}</td>
                  <td>{formatCurrency(r.avgOrderMonthly)}</td>
                </tr>
              ))}
              {monthlyReport.length === 0 && (
                <tr><td colSpan={4} className="py-8 text-center text-slate-400">No sales yet.</td></tr>
              )}
            </tbody>
          </table>
        </div>
      )}

      {tab === 'range' && (
        <div className="space-y-4">
          <div className="card flex flex-wrap items-end gap-3 p-4">
            <div>
              <label className="label">Start date</label>
              <input type="date" className="input" value={startDate} onChange={(e) => setStartDate(e.target.value)} />
            </div>
            <div>
              <label className="label">End date</label>
              <input type="date" className="input" value={endDate} onChange={(e) => setEndDate(e.target.value)} />
            </div>
            {startDate && endDate && (
              <p className="pb-2 text-sm text-slate-500">
                {rangeOrders.length} orders · total {formatCurrency(rangeTotal)}
              </p>
            )}
          </div>
          <div className="card overflow-x-auto">
            <table className="table-base">
              <thead>
                <tr>
                  <th>Date</th>
                  <th>Customer</th>
                  <th>Product</th>
                  <th>Qty</th>
                  <th>Unit price</th>
                  <th>Order total</th>
                </tr>
              </thead>
              <tbody>
                {rangeOrders.flatMap((o) =>
                  o.items.map((i, idx) => (
                    <tr key={`${o.id}-${idx}`}>
                      <td>{formatDate(o.orderDate)}</td>
                      <td>{o.customerName}</td>
                      <td>{i.productName}</td>
                      <td>{i.quantity}</td>
                      <td>{formatCurrency(i.unitPrice)}</td>
                      <td>{formatCurrency(o.totalAmount)}</td>
                    </tr>
                  ))
                )}
                {(!startDate || !endDate) && (
                  <tr><td colSpan={6} className="py-8 text-center text-slate-400">Pick a start and end date.</td></tr>
                )}
                {startDate && endDate && rangeOrders.length === 0 && (
                  <tr><td colSpan={6} className="py-8 text-center text-slate-400">No orders in this range.</td></tr>
                )}
              </tbody>
            </table>
          </div>
        </div>
      )}
    </div>
  )
}
