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

  return (
    <div className="flex h-screen overflow-hidden">
      <Sidebar />
      <div className="flex flex-1 flex-col overflow-hidden">
        <Topbar title={title} />
        <main className="flex-1 overflow-y-auto p-6">
          <Outlet />
        </main>
      </div>
    </div>
  )
}
