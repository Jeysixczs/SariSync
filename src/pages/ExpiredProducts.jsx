import { useEffect, useMemo, useState } from 'react'
import { subscribeProducts, getExpired, getCriticallyExpiring } from '../services/productService'
import { formatCurrency, formatDate } from '../utils/format'

export default function ExpiredProducts() {
  const [products, setProducts] = useState([])
  const [tab, setTab] = useState('expired')

  useEffect(() => subscribeProducts(setProducts), [])

  const expired = useMemo(() => getExpired(products), [products])
  const critical = useMemo(() => getCriticallyExpiring(products), [products])

  const list = tab === 'expired' ? expired : critical

  return (
    <div className="space-y-4">
      <div className="flex gap-2 overflow-x-auto border-b border-slate-200">
        <button
          onClick={() => setTab('expired')}
          className={`shrink-0 whitespace-nowrap px-4 py-2 text-sm font-medium ${tab === 'expired' ? 'border-b-2 border-red-600 text-red-700' : 'text-slate-500 hover:text-slate-700'}`}
        >
          Expired ({expired.length})
        </button>
        <button
          onClick={() => setTab('critical')}
          className={`shrink-0 whitespace-nowrap px-4 py-2 text-sm font-medium ${tab === 'critical' ? 'border-b-2 border-amber-600 text-amber-700' : 'text-slate-500 hover:text-slate-700'}`}
        >
          Expiring within 30 days ({critical.length})
        </button>
      </div>

      <div className="card overflow-x-auto">
        <table className="table-base">
          <thead>
            <tr>
              <th>Product</th>
              <th>Category</th>
              <th>Stock</th>
              <th>Selling price</th>
              <th>Expiry date</th>
            </tr>
          </thead>
          <tbody>
            {list.map((p) => (
              <tr key={p.id}>
                <td className="font-medium text-slate-700">{p.name}</td>
                <td>{p.category}</td>
                <td>{p.stock}</td>
                <td>{formatCurrency(p.sellingPrice)}</td>
                <td className={tab === 'expired' ? 'font-medium text-red-600' : 'font-medium text-amber-600'}>
                  {formatDate(p.dateExpired)}
                </td>
              </tr>
            ))}
            {list.length === 0 && (
              <tr><td colSpan={5} className="py-8 text-center text-slate-400">Nothing here.</td></tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  )
}
