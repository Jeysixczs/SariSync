import { useMemo, useState } from 'react'
import { getExpired, getCriticallyExpiring } from '../services/productService'
import { formatCurrency, formatDate } from '../utils/format'
import { useData } from '../contexts/DataContext'

export default function ExpiredProducts() {
  const { products } = useData()
  const [tab, setTab] = useState('expired')

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

      <div className="card">
        {/* Mobile: stacked cards, no horizontal scroll */}
        <div className="divide-y divide-slate-100 md:hidden">
          {list.map((p) => (
            <div key={p.id} className="p-4">
              <div className="flex items-start justify-between gap-2">
                <p className="font-medium text-slate-700">{p.name}</p>
                <span className={`shrink-0 text-sm font-medium ${tab === 'expired' ? 'text-red-600' : 'text-amber-600'}`}>
                  {formatDate(p.dateExpired)}
                </span>
              </div>
              <p className="mt-1 text-xs text-slate-500">
                {p.category || '—'} · Stock {p.stock} · {formatCurrency(p.sellingPrice)}
              </p>
            </div>
          ))}
          {list.length === 0 && <p className="py-8 text-center text-sm text-slate-400">Nothing here.</p>}
        </div>

        {/* Desktop: table */}
        <div className="hidden overflow-x-auto md:block">
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
    </div>
  )
}
