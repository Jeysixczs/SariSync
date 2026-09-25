import { useEffect, useMemo, useState } from 'react'
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
import { subscribeProducts, getExpired, getCriticallyExpiring, getStockLevel } from '../services/productService'
import { subscribeOrders } from '../services/orderService'
import { buildDailySalesReport } from '../services/reportService'
import { formatCurrency, formatDate } from '../utils/format'

export default function Dashboard() {
  const [products, setProducts] = useState([])
  const [orders, setOrders] = useState([])

  useEffect(() => subscribeProducts(setProducts), [])
  useEffect(() => subscribeOrders(setOrders), [])

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
      <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 lg:grid-cols-5">
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
                <Tooltip formatter={(v) => formatCurrency(v)} />
                <Bar dataKey="sales" fill="#2f8058" radius={[4, 4, 0, 0]} />
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
              <li key={o.id} className="flex items-center justify-between text-sm">
                <div>
                  <p className="font-medium text-slate-700">{o.customerName}</p>
                  <p className="text-xs text-slate-400">{formatDate(o.orderDate)}</p>
                </div>
                <span className="font-semibold text-slate-700">{formatCurrency(o.totalAmount)}</span>
              </li>
            ))}
            {orders.length === 0 && <p className="text-sm text-slate-400">No orders yet.</p>}
          </ul>
        </div>
      </div>

      <div className="card p-5">
        <h3 className="mb-4 font-semibold text-slate-700">Recently added products</h3>
        <div className="overflow-x-auto">
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
