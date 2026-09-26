import { NavLink } from 'react-router-dom'
import {
  LayoutDashboard,
  Package,
  ShoppingCart,
  History,
  Truck,
  BarChart3,
  AlertTriangle,
  X,
} from 'lucide-react'

const links = [
  { to: '/', label: 'Dashboard', icon: LayoutDashboard },
  { to: '/pos', label: 'Point of Sale', icon: ShoppingCart },
  { to: '/products', label: 'Products', icon: Package },
  { to: '/suppliers', label: 'Suppliers', icon: Truck },
  { to: '/orders', label: 'Order History', icon: History },
  { to: '/reports', label: 'Reports', icon: BarChart3 },
  { to: '/expired', label: 'Expired / Expiring', icon: AlertTriangle },
]

function SidebarContent({ onNavigate }) {
  return (
    <>
      <div className="flex items-center gap-2 px-5 py-5">
        <div className="flex h-9 w-9 shrink-0 items-center justify-center rounded-lg bg-brand-600 font-bold text-white">
          S
        </div>
        <span className="text-lg font-semibold text-slate-800">SariSync</span>
      </div>
      <nav className="flex-1 space-y-1 px-3">
        {links.map(({ to, label, icon: Icon }) => (
          <NavLink
            key={to}
            to={to}
            end={to === '/'}
            onClick={onNavigate}
            className={({ isActive }) =>
              `flex items-center gap-3 rounded-lg px-3 py-2.5 text-sm font-medium transition-colors ${
                isActive
                  ? 'bg-brand-50 text-brand-700'
                  : 'text-slate-600 hover:bg-slate-100'
              }`
            }
          >
            <Icon size={18} />
            {label}
          </NavLink>
        ))}
      </nav>
      <div className="px-5 py-4 text-xs text-slate-400">SariSync Admin · Web</div>
    </>
  )
}

export default function Sidebar({ mobileOpen = false, onClose }) {
  return (
    <>
      {/* Desktop: static sidebar, always visible */}
      <aside className="hidden w-60 flex-col border-r border-slate-200 bg-white md:flex">
        <SidebarContent />
      </aside>

      {/* Mobile: slide-in drawer + backdrop, only rendered when open */}
      {mobileOpen && (
        <div className="fixed inset-0 z-40 md:hidden">
          <div
            className="absolute inset-0 bg-black/40"
            onClick={onClose}
            aria-hidden="true"
          />
          <aside className="relative flex h-full w-64 max-w-[80vw] flex-col bg-white shadow-xl">
            <button
              onClick={onClose}
              className="absolute right-3 top-4 rounded-full p-2 text-slate-400 hover:bg-slate-100 hover:text-slate-600"
              aria-label="Close menu"
            >
              <X size={18} />
            </button>
            <SidebarContent onNavigate={onClose} />
          </aside>
        </div>
      )}
    </>
  )
}
