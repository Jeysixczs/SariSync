import { useMemo, useState } from 'react'
import {
  buildProductSalesReport,
  buildDailySalesReport,
  buildMonthlySalesReport,
  filterOrdersByDateRange,
} from '../services/reportService'
import { formatCurrency, formatDate } from '../utils/format'
import { useData } from '../contexts/DataContext'

const TABS = [
  { id: 'products', label: 'Sales by product' },
  { id: 'daily', label: 'Daily sales' },
  { id: 'monthly', label: 'Monthly sales' },
  { id: 'range', label: 'Date range' },
]

const MONTH_NAMES = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

function EmptyState({ children }) {
  return <p className="py-10 text-center text-sm text-slate-400">{children}</p>
}

function MobileRow({ children }) {
  return <div className="p-4">{children}</div>
}

export default function Reports() {
  const { orders } = useData()
  const [tab, setTab] = useState('products')
  const [startDate, setStartDate] = useState('')
  const [endDate, setEndDate] = useState('')

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
      {/* Tab bar: horizontally scrollable pill strip, never wraps/overflows on narrow phones */}
      <div className="-mx-1 flex gap-1 overflow-x-auto px-1 pb-1">
        {TABS.map((t) => (
          <button
            key={t.id}
            onClick={() => setTab(t.id)}
            className={`shrink-0 whitespace-nowrap rounded-full px-4 py-2 text-sm font-medium transition-colors ${
              tab === t.id
                ? 'bg-brand-600 text-white shadow-sm'
                : 'bg-slate-100 text-slate-600 hover:bg-slate-200'
            }`}
          >
            {t.label}
          </button>
        ))}
      </div>

      {tab === 'products' && (
        <div className="table-card">
          {/* Mobile: stacked list, one clear row per product, wraps cleanly at any width */}
          <div className="divide-y divide-slate-100 md:hidden">
            {productReport.map((r) => (
              <MobileRow key={r.productId}>
                <div className="flex items-start justify-between gap-3">
                  <p className="font-medium text-slate-800">{r.productName}</p>
                  <p className="shrink-0 font-semibold text-slate-800">{formatCurrency(r.totalRevenue)}</p>
                </div>
                <div className="mt-1.5 flex flex-wrap gap-x-4 gap-y-1 text-xs text-slate-500">
                  <span>Qty sold <span className="font-medium text-slate-700">{r.totalQuantitySold}</span></span>
                  <span>Unit price <span className="font-medium text-slate-700">{formatCurrency(r.unitPrice)}</span></span>
                  <span>Orders <span className="font-medium text-slate-700">{r.numberOfOrders}</span></span>
                </div>
              </MobileRow>
            ))}
            {productReport.length === 0 && <EmptyState>No sales yet.</EmptyState>}
          </div>

          {/* Desktop / tablet: sticky-header table inside a clipped, scrollable frame */}
          <div className="hidden md:block">
            <div className="table-scroll">
              <table className="table-base">
                <thead>
                  <tr>
                    <th>Product</th>
                    <th className="text-right">Qty sold</th>
                    <th className="text-right">Unit price</th>
                    <th className="text-right">Revenue</th>
                    <th className="text-right">Orders</th>
                  </tr>
                </thead>
                <tbody>
                  {productReport.map((r) => (
                    <tr key={r.productId}>
                      <td className="font-medium text-slate-700">{r.productName}</td>
                      <td className="text-right">{r.totalQuantitySold}</td>
                      <td className="text-right">{formatCurrency(r.unitPrice)}</td>
                      <td className="text-right font-medium text-slate-800">{formatCurrency(r.totalRevenue)}</td>
                      <td className="text-right">{r.numberOfOrders}</td>
                    </tr>
                  ))}
                  {productReport.length === 0 && (
                    <tr><td colSpan={5}><EmptyState>No sales yet.</EmptyState></td></tr>
                  )}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      )}

      {tab === 'daily' && (
        <div className="table-card">
          <div className="divide-y divide-slate-100 md:hidden">
            {dailyReport.map((r) => (
              <MobileRow key={r.date}>
                <div className="flex items-center justify-between gap-3">
                  <div>
                    <p className="font-medium text-slate-800">{formatDate(r.date)}</p>
                    <p className="mt-0.5 text-xs text-slate-500">
                      {r.numberOfOrders} orders · avg {formatCurrency(r.avgSales)}
                    </p>
                  </div>
                  <span className="shrink-0 font-semibold text-slate-800">{formatCurrency(r.dailySales)}</span>
                </div>
              </MobileRow>
            ))}
            {dailyReport.length === 0 && <EmptyState>No sales yet.</EmptyState>}
          </div>
          <div className="hidden md:block">
            <div className="table-scroll">
              <table className="table-base">
                <thead>
                  <tr>
                    <th>Date</th>
                    <th className="text-right">Orders</th>
                    <th className="text-right">Total sales</th>
                    <th className="text-right">Average order</th>
                  </tr>
                </thead>
                <tbody>
                  {dailyReport.map((r) => (
                    <tr key={r.date}>
                      <td className="font-medium text-slate-700">{formatDate(r.date)}</td>
                      <td className="text-right">{r.numberOfOrders}</td>
                      <td className="text-right font-medium text-slate-800">{formatCurrency(r.dailySales)}</td>
                      <td className="text-right">{formatCurrency(r.avgSales)}</td>
                    </tr>
                  ))}
                  {dailyReport.length === 0 && (
                    <tr><td colSpan={4}><EmptyState>No sales yet.</EmptyState></td></tr>
                  )}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      )}

      {tab === 'monthly' && (
        <div className="table-card">
          <div className="divide-y divide-slate-100 md:hidden">
            {monthlyReport.map((r) => (
              <MobileRow key={r.key}>
                <div className="flex items-center justify-between gap-3">
                  <div>
                    <p className="font-medium text-slate-800">{MONTH_NAMES[r.month - 1]} {r.year}</p>
                    <p className="mt-0.5 text-xs text-slate-500">
                      {r.totalOrders} orders · avg {formatCurrency(r.avgOrderMonthly)}
                    </p>
                  </div>
                  <span className="shrink-0 font-semibold text-slate-800">{formatCurrency(r.monthlySales)}</span>
                </div>
              </MobileRow>
            ))}
            {monthlyReport.length === 0 && <EmptyState>No sales yet.</EmptyState>}
          </div>
          <div className="hidden md:block">
            <div className="table-scroll">
              <table className="table-base">
                <thead>
                  <tr>
                    <th>Month</th>
                    <th className="text-right">Orders</th>
                    <th className="text-right">Total sales</th>
                    <th className="text-right">Average order</th>
                  </tr>
                </thead>
                <tbody>
                  {monthlyReport.map((r) => (
                    <tr key={r.key}>
                      <td className="font-medium text-slate-700">{MONTH_NAMES[r.month - 1]} {r.year}</td>
                      <td className="text-right">{r.totalOrders}</td>
                      <td className="text-right font-medium text-slate-800">{formatCurrency(r.monthlySales)}</td>
                      <td className="text-right">{formatCurrency(r.avgOrderMonthly)}</td>
                    </tr>
                  ))}
                  {monthlyReport.length === 0 && (
                    <tr><td colSpan={4}><EmptyState>No sales yet.</EmptyState></td></tr>
                  )}
                </tbody>
              </table>
            </div>
          </div>
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
                {rangeOrders.length} orders · total <span className="font-medium text-slate-700">{formatCurrency(rangeTotal)}</span>
              </p>
            )}
          </div>

          <div className="table-card">
            <div className="divide-y divide-slate-100 md:hidden">
              {rangeOrders.flatMap((o) =>
                o.items.map((i, idx) => (
                  <MobileRow key={`${o.id}-${idx}`}>
                    <div className="flex items-start justify-between gap-3">
                      <p className="font-medium text-slate-800">{i.productName}</p>
                      <span className="shrink-0 font-semibold text-slate-800">{formatCurrency(o.totalAmount)}</span>
                    </div>
                    <p className="mt-1 text-xs text-slate-500">
                      {formatDate(o.orderDate)} · {o.customerName} · {i.quantity} × {formatCurrency(i.unitPrice)}
                    </p>
                  </MobileRow>
                ))
              )}
              {(!startDate || !endDate) && <EmptyState>Pick a start and end date.</EmptyState>}
              {startDate && endDate && rangeOrders.length === 0 && <EmptyState>No orders in this range.</EmptyState>}
            </div>
            <div className="hidden md:block">
              <div className="table-scroll">
                <table className="table-base">
                  <thead>
                    <tr>
                      <th>Date</th>
                      <th>Customer</th>
                      <th>Product</th>
                      <th className="text-right">Qty</th>
                      <th className="text-right">Unit price</th>
                      <th className="text-right">Order total</th>
                    </tr>
                  </thead>
                  <tbody>
                    {rangeOrders.flatMap((o) =>
                      o.items.map((i, idx) => (
                        <tr key={`${o.id}-${idx}`}>
                          <td>{formatDate(o.orderDate)}</td>
                          <td>{o.customerName}</td>
                          <td className="font-medium text-slate-700">{i.productName}</td>
                          <td className="text-right">{i.quantity}</td>
                          <td className="text-right">{formatCurrency(i.unitPrice)}</td>
                          <td className="text-right font-medium text-slate-800">{formatCurrency(o.totalAmount)}</td>
                        </tr>
                      ))
                    )}
                    {(!startDate || !endDate) && (
                      <tr><td colSpan={6}><EmptyState>Pick a start and end date.</EmptyState></td></tr>
                    )}
                    {startDate && endDate && rangeOrders.length === 0 && (
                      <tr><td colSpan={6}><EmptyState>No orders in this range.</EmptyState></td></tr>
                    )}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  )
}
