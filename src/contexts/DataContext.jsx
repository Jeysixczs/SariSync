import { createContext, useContext, useEffect, useState } from 'react'
import { subscribeProducts } from '../services/productService'
import { subscribeSuppliers } from '../services/supplierService'
import { subscribeOrders } from '../services/orderService'

const DataContext = createContext(null)

// Mounted once inside Layout (which stays mounted across every nested route
// change), instead of each page opening its own onSnapshot listener. Firestore
// bills a read for every matching document each time a listener is (re)opened,
// so one shared subscription per collection — reused by every page instead of
// re-subscribed on every navigation — is the single biggest lever for staying
// inside the Spark (free) plan's daily read quota.
export function DataProvider({ children }) {
  const [products, setProducts] = useState([])
  const [productsLoading, setProductsLoading] = useState(true)
  const [suppliers, setSuppliers] = useState([])
  const [suppliersLoading, setSuppliersLoading] = useState(true)
  const [orders, setOrders] = useState([])
  const [ordersLoading, setOrdersLoading] = useState(true)

  useEffect(() => {
    const unsub = subscribeProducts((data) => {
      setProducts(data)
      setProductsLoading(false)
    })
    return unsub
  }, [])

  useEffect(() => {
    const unsub = subscribeSuppliers((data) => {
      setSuppliers(data)
      setSuppliersLoading(false)
    })
    return unsub
  }, [])

  useEffect(() => {
    const unsub = subscribeOrders((data) => {
      setOrders(data)
      setOrdersLoading(false)
    })
    return unsub
  }, [])

  return (
    <DataContext.Provider
      value={{
        products,
        productsLoading,
        suppliers,
        suppliersLoading,
        orders,
        ordersLoading,
      }}
    >
      {children}
    </DataContext.Provider>
  )
}

export function useData() {
  return useContext(DataContext)
}
