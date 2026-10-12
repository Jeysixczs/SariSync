// All reports are derived client-side from the orders list (Firestore has no
// server-side GROUP BY), mirroring the SQL aggregate queries in
// SalesReport.cs / DateRangeReportProperties / Daily & MonthlySalesReportProperties.

export function buildProductSalesReport(orders) {
  const map = new Map()
  for (const order of orders) {
    for (const item of order.items || []) {
      const key = item.productId
      if (!map.has(key)) {
        map.set(key, {
          productId: item.productId,
          productName: item.productName,
          totalQuantitySold: 0,
          unitPrice: item.unitPrice,
          totalRevenue: 0,
          orderIds: new Set(),
        })
      }
      const row = map.get(key)
      row.totalQuantitySold += item.quantity
      row.totalRevenue += item.quantity * item.unitPrice
      row.orderIds.add(order.id)
    }
  }
  return [...map.values()]
    .map((r) => ({ ...r, numberOfOrders: r.orderIds.size, orderIds: undefined }))
    .sort((a, b) => b.totalRevenue - a.totalRevenue)
}

export function buildDailySalesReport(orders) {
  const map = new Map()
  for (const order of orders) {
    if (!order.orderDate) continue
    const key = order.orderDate.toISOString().slice(0, 10)
    if (!map.has(key)) map.set(key, { date: key, numberOfOrders: 0, dailySales: 0 })
    const row = map.get(key)
    row.numberOfOrders += 1
    row.dailySales += order.totalAmount
  }
  return [...map.values()]
    .map((r) => ({ ...r, avgSales: r.numberOfOrders ? r.dailySales / r.numberOfOrders : 0 }))
    .sort((a, b) => (a.date < b.date ? 1 : -1))
}

export function buildMonthlySalesReport(orders) {
  const map = new Map()
  for (const order of orders) {
    if (!order.orderDate) continue
    const key = `${order.orderDate.getFullYear()}-${String(order.orderDate.getMonth() + 1).padStart(2, '0')}`
    if (!map.has(key)) {
      map.set(key, {
        key,
        year: order.orderDate.getFullYear(),
        month: order.orderDate.getMonth() + 1,
        totalOrders: 0,
        monthlySales: 0,
      })
    }
    const row = map.get(key)
    row.totalOrders += 1
    row.monthlySales += order.totalAmount
  }
  return [...map.values()]
    .map((r) => ({ ...r, avgOrderMonthly: r.totalOrders ? r.monthlySales / r.totalOrders : 0 }))
    .sort((a, b) => (a.key < b.key ? 1 : -1))
}

export function filterOrdersByDateRange(orders, startDate, endDate) {
  const start = new Date(startDate)
  const end = new Date(endDate)
  end.setHours(23, 59, 59, 999)
  return orders.filter((o) => o.orderDate && o.orderDate >= start && o.orderDate <= end)
}

export function filterOrdersBySpecificDate(orders, date) {
  const d = new Date(date)
  const key = d.toDateString()
  return orders.filter((o) => o.orderDate && o.orderDate.toDateString() === key)
}
