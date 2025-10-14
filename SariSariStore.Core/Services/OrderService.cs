using Microsoft.Data.SqlClient;
using SariSariStore.Core.Model;
using SariSariStore.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Services
{
    public class OrderService : IOrderService
    {
        public string ConnectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            List<Orders> orders = new List<Orders>();



            return orders;
        }

        public async Task<Dictionary<string, decimal>> GetMonthlyComparisonAsync(int year)
        {
            var monthlyIncome = new Dictionary<string, decimal>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT MONTH(OrderDate) as Month, 
                                       SUM(oi.Quantity * oi.Price) as MonthlyIncome
                               FROM tbl_Order o
                               INNER JOIN tbl_OrderItems oi ON o.Id = oi.OrderId
                               WHERE YEAR(OrderDate) = @Year AND o.IsPaid = 1
                               GROUP BY MONTH(OrderDate)
                               ORDER BY MONTH(OrderDate)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Year", year);

                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int month = Convert.ToInt32(reader["Month"]);
                            decimal income = Convert.ToDecimal(reader["MonthlyIncome"]);
                            monthlyIncome.Add(month.ToString("00"), income);
                        }
                    }
                }
            }
            return monthlyIncome;
        }

        public async Task<decimal> GetMonthlyIncomeAsync(int year, int month)
        {
            decimal totalIncome = 0;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT SUM(oi.Quantity * oi.Price) as TotalIncome
                               FROM tbl_Order o
                               INNER JOIN tbl_OrderItems oi ON o.Id = oi.OrderId
                               WHERE YEAR(o.OrderDate) = @Year AND MONTH(o.OrderDate) = @Month
                               AND o.IsPaid = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Month", month);

                    await con.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();

                    if (result != DBNull.Value && result != null)
                    {
                        totalIncome = Convert.ToDecimal(result);
                    }
                }
            }
            return totalIncome;
        }

        public async Task<List<Orders>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var orders = new List<Orders>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                // Fixed: Specify columns explicitly to avoid conflicts
                string query = @"SELECT 
                                    o.Id as OrderId, 
                                    o.OrderDate, 
                                    o.IsPaid,
                                    oi.Id as ItemId,
                                    oi.OrderId,
                                    oi.ProductId,
                                    oi.ProductName,
                                    oi.Quantity,
                                    oi.Price
                               FROM tbl_Order o
                               LEFT JOIN tbl_OrderItems oi ON o.Id = oi.OrderId
                               WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                               ORDER BY o.OrderDate DESC, o.Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Date.AddDays(1).AddSeconds(-1));

                    await con.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Orders currentOrder = null;

                        while (await reader.ReadAsync())
                        {
                            int orderId = Convert.ToInt32(reader["OrderId"]);

                            if (currentOrder == null || currentOrder.OrderID != orderId)
                            {
                                if (currentOrder != null)
                                    orders.Add(currentOrder);

                                currentOrder = new Orders
                                {
                                    OrderID = orderId,
                                    OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                                    IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                                    Items = new List<OrderItems>()
                                };
                            }

                            // Check if there are order items (LEFT JOIN might return NULLs)
                            if (reader["ItemId"] != DBNull.Value)
                            {
                                var orderItem = new OrderItems
                                {

                                    OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                                    OrderID = Convert.ToInt32(reader["OrderID"]),
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                   
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                                };
                                currentOrder.Items.Add(orderItem);
                            }
                        }

                        if (currentOrder != null)
                            orders.Add(currentOrder);
                    }
                }
            }
            return orders;
        }
    }
}

