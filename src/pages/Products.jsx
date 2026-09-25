import { useEffect, useMemo, useState } from 'react'
import { Pencil, Plus, Search, Trash2 } from 'lucide-react'
import Modal from '../components/Modal'
import ConfirmDialog from '../components/ConfirmDialog'
import {
  subscribeProducts,
  addProduct,
  updateProduct,
  deleteProduct,
  getCategories,
  searchProducts,
} from '../services/productService'
import { subscribeSuppliers } from '../services/supplierService'
import { formatCurrency, formatDate } from '../utils/format'

const emptyForm = {
  name: '',
  description: '',
  category: '',
  price: '',
  sellingPrice: '',
  stock: '',
  dateExpired: '',
  supplierId: '',
  supplierPayment: '',
}

export default function Products() {
  const [products, setProducts] = useState([])
  const [suppliers, setSuppliers] = useState([])
  const [search, setSearch] = useState('')
  const [category, setCategory] = useState('')
  const [modalOpen, setModalOpen] = useState(false)
  const [editing, setEditing] = useState(null)
  const [form, setForm] = useState(emptyForm)
  const [imageFile, setImageFile] = useState(null)
  const [saving, setSaving] = useState(false)
  const [error, setError] = useState('')
  const [toDelete, setToDelete] = useState(null)

  useEffect(() => subscribeProducts(setProducts), [])
  useEffect(() => subscribeSuppliers(setSuppliers), [])

  const categories = useMemo(() => getCategories(products), [products])

  const filtered = useMemo(() => {
    let result = searchProducts(products, search)
    if (category) result = result.filter((p) => p.category === category)
    return result
  }, [products, search, category])

  function openAdd() {
    setEditing(null)
    setForm(emptyForm)
    setImageFile(null)
    setError('')
    setModalOpen(true)
  }

  function openEdit(product) {
    setEditing(product)
    setForm({
      name: product.name,
      description: product.description || '',
      category: product.category,
      price: product.price,
      sellingPrice: product.sellingPrice,
      stock: product.stock,
      dateExpired: product.dateExpired ? product.dateExpired.toISOString().slice(0, 10) : '',
      supplierId: product.supplierId || '',
      supplierPayment: product.supplierPayment || '',
    })
    setImageFile(null)
    setError('')
    setModalOpen(true)
  }

  async function handleSubmit(e) {
    e.preventDefault()
    setSaving(true)
    setError('')
    try {
      const supplier = suppliers.find((s) => s.id === form.supplierId)
      const payload = { ...form, supplierName: supplier?.supplierName || '' }
      if (editing) {
        await updateProduct(editing.id, payload, imageFile)
      } else {
        await addProduct(payload, imageFile)
      }
      setModalOpen(false)
    } catch (err) {
      setError(err.message || 'Something went wrong.')
    } finally {
      setSaving(false)
    }
  }

  async function handleDelete() {
    if (!toDelete) return
    await deleteProduct(toDelete.id)
    setToDelete(null)
  }

  return (
    <div className="space-y-4">
      <div className="flex flex-wrap items-center justify-between gap-3">
        <div className="flex flex-1 flex-wrap gap-2">
          <div className="relative w-full sm:w-64">
            <Search size={16} className="absolute left-3 top-1/2 -translate-y-1/2 text-slate-400" />
            <input
              className="input pl-9"
              placeholder="Search name, category, description…"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
          </div>
          <select className="input w-full sm:w-44" value={category} onChange={(e) => setCategory(e.target.value)}>
            <option value="">All categories</option>
            {categories.map((c) => (
              <option key={c} value={c}>{c}</option>
            ))}
          </select>
        </div>
        <button className="btn-primary" onClick={openAdd}>
          <Plus size={16} /> Add product
        </button>
      </div>

      <div className="card overflow-x-auto">
        <table className="table-base">
          <thead>
            <tr>
              <th>Product</th>
              <th>Category</th>
              <th>Stock</th>
              <th>Price / Selling</th>
              <th>Expiry</th>
              <th>Supplier</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {filtered.map((p) => (
              <tr key={p.id}>
                <td>
                  <div className="flex items-center gap-3">
                    {p.imageUrl ? (
                      <img src={p.imageUrl} alt={p.name} className="h-9 w-9 rounded-lg object-cover" />
                    ) : (
                      <div className="h-9 w-9 rounded-lg bg-slate-100" />
                    )}
                    <div>
                      <p className="font-medium text-slate-700">{p.name}</p>
                      <p className="text-xs text-slate-400">{p.description}</p>
                    </div>
                  </div>
                </td>
                <td>{p.category}</td>
                <td>
                  <span className={p.stock < 10 ? 'font-semibold text-amber-600' : ''}>{p.stock}</span>
                </td>
                <td>
                  {formatCurrency(p.price)} / {formatCurrency(p.sellingPrice)}
                </td>
                <td>{p.dateExpired ? formatDate(p.dateExpired) : '—'}</td>
                <td>{p.supplierName || '—'}</td>
                <td>
                  <div className="flex justify-end gap-2">
                    <button className="rounded-lg p-1.5 text-slate-500 hover:bg-slate-100" onClick={() => openEdit(p)}>
                      <Pencil size={16} />
                    </button>
                    <button className="rounded-lg p-1.5 text-red-500 hover:bg-red-50" onClick={() => setToDelete(p)}>
                      <Trash2 size={16} />
                    </button>
                  </div>
                </td>
              </tr>
            ))}
            {filtered.length === 0 && (
              <tr>
                <td colSpan={7} className="py-8 text-center text-slate-400">
                  No products found.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <Modal open={modalOpen} title={editing ? 'Edit product' : 'Add product'} onClose={() => setModalOpen(false)} width="max-w-2xl">
        <form onSubmit={handleSubmit} className="space-y-4">
          {error && <div className="rounded-lg bg-red-50 px-3 py-2 text-sm text-red-600">{error}</div>}
          <div className="grid grid-cols-1 gap-4 sm:grid-cols-2">
            <div>
              <label className="label">Name</label>
              <input required className="input" value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} />
            </div>
            <div>
              <label className="label">Category</label>
              <input required className="input" value={form.category} onChange={(e) => setForm({ ...form, category: e.target.value })} />
            </div>
          </div>
          <div>
            <label className="label">Description</label>
            <textarea className="input" rows={2} value={form.description} onChange={(e) => setForm({ ...form, description: e.target.value })} />
          </div>
          <div className="grid grid-cols-1 gap-4 sm:grid-cols-3">
            <div>
              <label className="label">Cost price</label>
              <input required type="number" step="0.01" className="input" value={form.price} onChange={(e) => setForm({ ...form, price: e.target.value })} />
            </div>
            <div>
              <label className="label">Selling price</label>
              <input required type="number" step="0.01" className="input" value={form.sellingPrice} onChange={(e) => setForm({ ...form, sellingPrice: e.target.value })} />
            </div>
            <div>
              <label className="label">Stock</label>
              <input required type="number" className="input" value={form.stock} onChange={(e) => setForm({ ...form, stock: e.target.value })} />
            </div>
          </div>
          <div className="grid grid-cols-1 gap-4 sm:grid-cols-2">
            <div>
              <label className="label">Expiry date (optional)</label>
              <input type="date" className="input" value={form.dateExpired} onChange={(e) => setForm({ ...form, dateExpired: e.target.value })} />
            </div>
            <div>
              <label className="label">Supplier</label>
              <select className="input" value={form.supplierId} onChange={(e) => setForm({ ...form, supplierId: e.target.value })}>
                <option value="">None</option>
                {suppliers.map((s) => (
                  <option key={s.id} value={s.id}>{s.supplierName}</option>
                ))}
              </select>
            </div>
          </div>
          <div className="grid grid-cols-1 gap-4 sm:grid-cols-2">
            <div>
              <label className="label">Payment to supplier</label>
              <input type="number" step="0.01" className="input" value={form.supplierPayment} onChange={(e) => setForm({ ...form, supplierPayment: e.target.value })} />
            </div>
            <div>
              <label className="label">Product image</label>
              <input type="file" accept="image/*" className="input" onChange={(e) => setImageFile(e.target.files?.[0] || null)} />
            </div>
          </div>
          <div className="flex justify-end gap-2 pt-2">
            <button type="button" className="btn-secondary" onClick={() => setModalOpen(false)}>Cancel</button>
            <button type="submit" disabled={saving} className="btn-primary">
              {saving ? 'Saving…' : 'Save product'}
            </button>
          </div>
        </form>
      </Modal>

      <ConfirmDialog
        open={!!toDelete}
        title="Remove product"
        message={`This will remove "${toDelete?.name}" from your active inventory.`}
        onCancel={() => setToDelete(null)}
        onConfirm={handleDelete}
      />
    </div>
  )
}
