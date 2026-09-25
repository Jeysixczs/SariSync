import { useEffect, useState } from 'react'
import { Outlet, useLocation } from 'react-router-dom'
import Sidebar from './Sidebar'
import Topbar from './Topbar'

const titles = {
  '/': 'Dashboard',
  '/pos': 'Point of Sale',
  '/products': 'Products',
  '/suppliers': 'Suppliers',
  '/orders': 'Order History',
  '/reports': 'Reports',
  '/expired': 'Expired / Expiring Products',
}

export default function Layout() {
  const { pathname } = useLocation()
  const title = titles[pathname] || 'SariSync'
  const [mobileNavOpen, setMobileNavOpen] = useState(false)

  // Close the mobile drawer automatically whenever the route changes
  useEffect(() => {
    setMobileNavOpen(false)
  }, [pathname])

  return (
    <div className="flex h-screen overflow-hidden">
      <Sidebar mobileOpen={mobileNavOpen} onClose={() => setMobileNavOpen(false)} />
      <div className="flex flex-1 flex-col overflow-hidden">
        <Topbar title={title} onMenuClick={() => setMobileNavOpen(true)} />
        <main className="flex-1 overflow-y-auto p-4 sm:p-6">
          <Outlet />
        </main>
      </div>
    </div>
  )
}
