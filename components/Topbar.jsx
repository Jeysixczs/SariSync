import { LogOut, Menu } from 'lucide-react'
import { useAuth } from '../contexts/AuthContext'

export default function Topbar({ title, onMenuClick }) {
  const { user, logout } = useAuth()

  return (
    <header className="flex items-center justify-between gap-3 border-b border-slate-200 bg-white px-4 py-4 sm:px-6">
      <div className="flex min-w-0 items-center gap-3">
        <button
          onClick={onMenuClick}
          className="rounded-lg p-1.5 text-slate-500 hover:bg-slate-100 md:hidden"
          aria-label="Open menu"
        >
          <Menu size={22} />
        </button>
        <h1 className="truncate text-lg font-semibold text-slate-800 sm:text-xl">{title}</h1>
      </div>
      <div className="flex shrink-0 items-center gap-2 sm:gap-3">
        <span className="hidden max-w-[160px] truncate text-sm text-slate-500 sm:inline md:max-w-none">
          {user?.email}
        </span>
        <button
          onClick={logout}
          className="btn-secondary px-2.5 sm:px-4"
        >
          <LogOut size={16} />
          <span className="hidden sm:inline">Sign out</span>
        </button>
      </div>
    </header>
  )
}
