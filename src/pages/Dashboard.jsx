import { useMemo } from 'react'
import {
  Package,
  AlertTriangle,
  CalendarX,
  ShoppingCart,
  Wallet,
} from 'lucide-react'
import {
  Bar,
  BarChart,
  CartesianGrid,
  ResponsiveContainer,
  Tooltip,
  XAxis,
  YAxis,
} from 'recharts'
import StatCard from '../components/StatCard'
import { getExpired, getCriticallyExpiring, getStockLevel } from '../services/productService'
import { buildDailySalesReport } from '../services/reportService'
import { formatCurrency, formatDate } from '../utils/format'
import { useData } from '../contexts/DataContext'

export default function Dashboard() {
  const { products, orders } = useData()

  const expiredCount = useMemo(() => getExpired(products).length, [products])
  const criticalCount = useMemo(() => getCriticallyExpiring(products).length, [products])
  const lowStockCount = useMemo(() => getStockLevel(products, 'low').length, [products])

  const todaySales = useMemo(() => {
    const today = new Date().toDateString()
    return orders
      .filter((o) => o.orderDate && o.orderDate.toDateString() === today)
      .reduce((sum, o) => sum + o.totalAmount, 0)
  }, [orders])

  const topProducts = useMemo(
    () => [...products].sort((a, b) => (b.dateAdded || 0) - (a.dateAdded || 0)).slice(0, 10),
    [products]
  )

  const dailyChartData = useMemo(() => {
    const report = buildDailySalesReport(orders).slice(0, 7).reverse()
    return report.map((r) => ({ date: r.date.slice(5), sales: Math.round(r.dailySales) }))
  }, [orders])

  return (
    <div className="space-y-6">
      <div className="grid grid-cols-2 gap-3 sm:gap-4 lg:grid-cols-3 xl:grid-cols-5">
        <StatCard icon={Package} label="Active products" value={products.length} tone="brand" />
        <StatCard icon={AlertTriangle} label="Low stock (<10)" value={lowStockCount} tone="amber" />
        <StatCard icon={CalendarX} label="Expired products" value={expiredCount} tone="red" />
        <StatCard icon={AlertTriangle} label="Expiring in 30 days" value={criticalCount} tone="amber" />
        <StatCard icon={Wallet} label="Today's sales" value={formatCurrency(todaySales)} tone="brand" />
      </div>

      <div className="grid grid-cols-1 gap-6 lg:grid-cols-3">
        <div className="card p-5 lg:col-span-2">
          <h3 className="mb-4 font-semibold text-slate-700">Sales, last 7 days</h3>
          <div className="h-64">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={dailyChartData}>
                <CartesianGrid strokeDasharray="3 3" vertical={false} />
                <XAxis dataKey="date" tick={{ fontSize: 12 }} />
                <YAxis tick={{ fontSize: 12 }} />
                <Tooltip cursor={false} formatter={(v) => formatCurrency(v)} />
                <Bar
                  dataKey="sales"
                  fill="#2f8058"
                  radius={[4, 4, 0, 0]}
                  activeBar={{ fill: '#256b48', radius: [4, 4, 0, 0], stroke: 'none' }}
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="card p-5">
          <h3 className="mb-4 flex items-center gap-2 font-semibold text-slate-700">
            <ShoppingCart size={16} /> Recent orders
          </h3>
          <ul className="space-y-3">
            {orders.slice(0, 6).map((o) => (
              <li key={o.id} className="flex items-center justify-between gap-3 text-sm">
                <div className="min-w-0">
                  <p className="truncate font-medium text-slate-700">{o.customerName}</p>
                  <p className="text-xs text-slate-400">{formatDate(o.orderDate)}</p>
                </div>
                <span className="shrink-0 font-semibold text-slate-700">{formatCurrency(o.totalAmount)}</span>
              </li>
            ))}
            {orders.length === 0 && <p className="text-sm text-slate-400">No orders yet.</p>}
          </ul>
        </div>
      </div>

      <div className="card p-5">
        <h3 className="mb-4 font-semibold text-slate-700">Recently added products</h3>
        {/* Mobile: stacked cards, no horizontal scroll */}
        <div className="divide-y divide-slate-100 md:hidden">
          {topProducts.map((p) => (
            <div key={p.id} className="flex items-center justify-between gap-2 py-3 text-sm">
              <div className="min-w-0">
                <p className="truncate font-medium text-slate-700">{p.name}</p>
                <p className="text-xs text-slate-400">{p.category || '—'} · Stock {p.stock} · {p.supplierName || '—'}</p>
              </div>
              <span className="shrink-0 font-medium text-slate-700">{formatCurrency(p.sellingPrice)}</span>
            </div>
          ))}
          {topProducts.length === 0 && <p className="py-6 text-center text-slate-400">No products yet.</p>}
        </div>

        {/* Desktop: table */}
        <div className="hidden overflow-x-auto md:block">
          <table className="table-base">
            <thead>
              <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Stock</th>
                <th>Selling price</th>
                <th>Supplier</th>
              </tr>
            </thead>
            <tbody>
              {topProducts.map((p) => (
                <tr key={p.id}>
                  <td>{p.name}</td>
                  <td>{p.category}</td>
                  <td>{p.stock}</td>
                  <td>{formatCurrency(p.sellingPrice)}</td>
                  <td>{p.supplierName || '—'}</td>
                </tr>
              ))}
              {topProducts.length === 0 && (
                <tr>
                  <td colSpan={5} className="py-6 text-center text-slate-400">
                    No products yet.
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}
