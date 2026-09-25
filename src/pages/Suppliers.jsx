import { useEffect, useState } from 'react'
import { Pencil, Plus, Trash2 } from 'lucide-react'
import Modal from '../components/Modal'
import ConfirmDialog from '../components/ConfirmDialog'
import {
  subscribeSuppliers,
  addSupplier,
  updateSupplier,
  deleteSupplier,
} from '../services/supplierService'
import { formatDate } from '../utils/format'

const emptyForm = { supplierName: '', contactPerson: '', phoneNumber: '', address: '' }

export default function Suppliers() {
  const [suppliers, setSuppliers] = useState([])
  const [modalOpen, setModalOpen] = useState(false)
  const [editing, setEditing] = useState(null)
  const [form, setForm] = useState(emptyForm)
  const [saving, setSaving] = useState(false)
  const [toDelete, setToDelete] = useState(null)

  useEffect(() => subscribeSuppliers(setSuppliers), [])

  function openAdd() {
    setEditing(null)
    setForm(emptyForm)
    setModalOpen(true)
  }

  function openEdit(supplier) {
    setEditing(supplier)
    setForm({
      supplierName: supplier.supplierName,
      contactPerson: supplier.contactPerson,
      phoneNumber: supplier.phoneNumber,
      address: supplier.address,
    })
    setModalOpen(true)
  }

  async function handleSubmit(e) {
    e.preventDefault()
    setSaving(true)
    try {
      if (editing) {
        await updateSupplier(editing.id, form)
      } else {
        await addSupplier(form)
      }
      setModalOpen(false)
    } finally {
      setSaving(false)
    }
  }

  async function handleDelete() {
    if (!toDelete) return
    await deleteSupplier(toDelete.id)
    setToDelete(null)
  }

  return (
    <div className="space-y-4">
      <div className="flex items-center justify-between">
        <p className="text-sm text-slate-500">{suppliers.length} active suppliers</p>
        <button className="btn-primary" onClick={openAdd}>
          <Plus size={16} /> Add supplier
        </button>
      </div>

      <div className="card overflow-x-auto">
        <table className="table-base">
          <thead>
            <tr>
              <th>Supplier</th>
              <th>Contact person</th>
              <th>Phone</th>
              <th>Address</th>
              <th>Added</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {suppliers.map((s) => (
              <tr key={s.id}>
                <td className="font-medium text-slate-700">{s.supplierName}</td>
                <td>{s.contactPerson}</td>
                <td>{s.phoneNumber}</td>
                <td>{s.address}</td>
                <td>{formatDate(s.createdDate)}</td>
                <td>
                  <div className="flex justify-end gap-2">
                    <button className="rounded-lg p-1.5 text-slate-500 hover:bg-slate-100" onClick={() => openEdit(s)}>
                      <Pencil size={16} />
                    </button>
                    <button className="rounded-lg p-1.5 text-red-500 hover:bg-red-50" onClick={() => setToDelete(s)}>
                      <Trash2 size={16} />
                    </button>
                  </div>
                </td>
              </tr>
            ))}
            {suppliers.length === 0 && (
              <tr>
                <td colSpan={6} className="py-8 text-center text-slate-400">No suppliers yet.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <Modal open={modalOpen} title={editing ? 'Edit supplier' : 'Add supplier'} onClose={() => setModalOpen(false)}>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="label">Supplier name</label>
            <input required className="input" value={form.supplierName} onChange={(e) => setForm({ ...form, supplierName: e.target.value })} />
          </div>
          <div>
            <label className="label">Contact person</label>
            <input required className="input" value={form.contactPerson} onChange={(e) => setForm({ ...form, contactPerson: e.target.value })} />
          </div>
          <div>
            <label className="label">Phone number</label>
            <input className="input" value={form.phoneNumber} onChange={(e) => setForm({ ...form, phoneNumber: e.target.value })} />
          </div>
          <div>
            <label className="label">Address</label>
            <textarea className="input" rows={2} value={form.address} onChange={(e) => setForm({ ...form, address: e.target.value })} />
          </div>
          <div className="flex justify-end gap-2 pt-2">
            <button type="button" className="btn-secondary" onClick={() => setModalOpen(false)}>Cancel</button>
            <button type="submit" disabled={saving} className="btn-primary">{saving ? 'Saving…' : 'Save supplier'}</button>
          </div>
        </form>
      </Modal>

      <ConfirmDialog
        open={!!toDelete}
        title="Remove supplier"
        message={`This will remove "${toDelete?.supplierName}" from your active suppliers.`}
        onCancel={() => setToDelete(null)}
        onConfirm={handleDelete}
      />
    </div>
  )
}
