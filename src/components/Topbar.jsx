import { LogOut } from 'lucide-react'
import { useAuth } from '../contexts/AuthContext'

export default function Topbar({ title }) {
  const { user, logout } = useAuth()

  return (
    <header className="flex items-center justify-between border-b border-slate-200 bg-white px-6 py-4">
      <h1 className="text-xl font-semibold text-slate-800">{title}</h1>
      <div className="flex items-center gap-3">
        <span className="text-sm text-slate-500">{user?.email}</span>
        <button
          onClick={logout}
          className="btn-secondary"
        >
          <LogOut size={16} />
          Sign out
        </button>
      </div>
    </header>
  )
}
