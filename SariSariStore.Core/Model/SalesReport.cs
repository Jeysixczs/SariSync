using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using SariSariStore.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{

    public class SalesReport
    {
        public string ConnectionString = ConnectionHelper.GetConnectionString();


        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal TotalQuantitySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalRevenue { get; set; }
        public int NumberOrder { get; set; }



        public List<SalesReport> DisplayReport()
        {
            List<SalesReport> salesReports = new List<SalesReport>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                                SELECT 
                                    od.ProductID,
                                    p.Name AS ProductName,
                                    p.Category AS ProductCategory,
                                    SUM(od.Quantity) AS TotalQuantitySold,
                                    od.UnitPrice,
                                    SUM(od.Quantity * od.UnitPrice) AS TotalRevenue,
                                    COUNT(DISTINCT o.OrderID) AS NumberOfOrders
                                FROM tbl_order o 
                                INNER JOIN tbl_orderdetails od ON o.OrderID = od.OrderID
                                INNER JOIN tbl_product p ON od.ProductID = p.ProductID
                                WHERE p.IsActive = 1
                                GROUP BY od.ProductID, p.Name, p.Category, od.UnitPrice
                                ORDER BY TotalRevenue DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesReport report = new SalesReport
                            {
                                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : "Unknown",
                                Category = reader["ProductCategory"] != DBNull.Value ? reader["ProductCategory"].ToString() : "Uncategorized",
                                TotalQuantitySold = reader["TotalQuantitySold"] != DBNull.Value ? Convert.ToDecimal(reader["TotalQuantitySold"]) : 0,
                                UnitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["UnitPrice"]) : 0,
                                TotalRevenue = reader["TotalRevenue"] != DBNull.Value ? Convert.ToDecimal(reader["TotalRevenue"]) : 0,
                                NumberOrder = reader["NumberOfOrders"] != DBNull.Value ? Convert.ToInt32(reader["NumberOfOrders"]) : 0
                            };
                            salesReports.Add(report);
                        }
                    }
                }
            }
            return salesReports;
        }
    }

    public class DateRangeReportProperties
    {

        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal OrderTotal { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
       

        public List<DateRangeReportProperties> GetSalesReportsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<DateRangeReportProperties> salesReports = new List<DateRangeReportProperties>();

            using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                conn.Open();
                string query = @"
                   SELECT 
                            o.OrderID,
                            o.OrderDate,
                            o.CustomerName,
                            o.TotalAmount AS OrderTotal,
                            p.Name AS ProductName,
                            p.Category,
                            od.Quantity,
                            od.UnitPrice AS UnitPrice
                        FROM tbl_order o
                        INNER JOIN tbl_OrderDetails od ON o.OrderID = od.OrderID
                        INNER JOIN tbl_Product p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                        ORDER BY o.OrderID, p.Name;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateRangeReportProperties report = new DateRangeReportProperties
                            {
                                OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString()),
                                CustomerName = reader["CustomerName"].ToString(),
                                OrderTotal = Convert.ToDecimal(reader["OrderTotal"]),
                                ProductName = reader["ProductName"].ToString(),
                                Category = reader["Category"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                            
                            };
                            salesReports.Add(report);
                        }
                    }
                }
            }
            return salesReports;
        }


        public List<DateRangeReportProperties> DisplaySpecificDateOrder(DateTime specidate)
        {
            List<DateRangeReportProperties> specificdate = new List<DateRangeReportProperties>();

            using (SqlConnection con = new SqlConnection(ConnectionHelper.GetConnectionString()))
            {
                string query = @"SELECT 
                            o.OrderID,
                            o.OrderDate,
                            o.CustomerName,
                            o.TotalAmount AS OrderTotal,
                            p.Name AS ProductName,
                            p.Category, 
                            od.Quantity,
                            od.UnitPrice AS UnitPrice 
                         FROM tbl_order o 
                         INNER JOIN tbl_OrderDetails od ON o.OrderID = od.OrderID 
                         INNER JOIN tbl_Product p ON od.ProductID = p.ProductID 
                         WHERE CAST(o.OrderDate AS DATE) = CAST(@dtpDate AS DATE) 
                         ORDER BY o.OrderID, p.Name";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@dtpDate", SqlDbType.DateTime).Value = specidate;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateRangeReportProperties report = new DateRangeReportProperties
                            {
                                OrderDate = reader["OrderDate"] as DateTime? ?? DateTime.MinValue,
                                CustomerName = reader["CustomerName"] as string ?? string.Empty,
                                OrderTotal = reader["OrderTotal"] as decimal? ?? 0m,
                                ProductName = reader["ProductName"] as string ?? string.Empty,
                                Category = reader["Category"] as string ?? string.Empty,
                                Quantity = reader["Quantity"] as int? ?? 0,
                                UnitPrice = reader["UnitPrice"] as decimal? ?? 0m
                            };
                            specificdate.Add(report);
                        }
                    }
                }
            }
            return specificdate;
        }


    }

    public class DailySalesReportProperties
    {

        public string ConnectionString = ConnectionHelper.GetConnectionString();
        public DateTime Orderdate { get; set; }
        public int Numoforderdaily { get; set; }
        public decimal DailySales { get; set; }
        public decimal AvgSales { get; set; }

        public List<DailySalesReportProperties> DisplayReportDaily()
        {
            List<DailySalesReportProperties> salesReports = new List<DailySalesReportProperties>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        CAST(OrderDate AS DATE) AS OrderDate,
                        COUNT(OrderID) AS NumberOfOrders,
                        SUM(TotalAmount) AS DailySales,
                        AVG(TotalAmount) AS AvgOrderValue
                    FROM tbl_Order
                    GROUP BY CAST(OrderDate AS DATE)
                    ORDER BY OrderDate DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DailySalesReportProperties report = new DailySalesReportProperties
                            {
                                Orderdate = Convert.ToDateTime(reader["OrderDate"]),
                                Numoforderdaily = Convert.ToInt32(reader["NumberOfOrders"]),
                                DailySales = Convert.ToDecimal(reader["DailySales"]),
                                AvgSales = Convert.ToDecimal(reader["AvgOrderValue"])

                            };
                            salesReports.Add(report);
                        }
                    }
                }
            }
            return salesReports;
        }

    }

    public class MonthlySalesReportProperties
    {
        public string ConnectionString = ConnectionHelper.GetConnectionString();
        public int OrderYear { get; set; }
        public int OrderMonth { get; set; }
        public decimal TotalOrder { get; set; }
        public decimal MonthlySales { get; set; }
        public decimal AvgOrderMonthly { get; set; }
        public List<MonthlySalesReportProperties> DisplayReportMonthly()
        {
            List<MonthlySalesReportProperties> salesReports = new List<MonthlySalesReportProperties>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                                                SELECT 
                                YEAR(OrderDate) AS OrderYear,
                                MONTH(OrderDate) AS OrderMonth,
                                COUNT(OrderID) AS TotalOrders,
                                SUM(TotalAmount) AS MonthlySales,
                                AVG(TotalAmount) AS AvgOrderValue
                            FROM tbl_Order
                            GROUP BY YEAR(OrderDate), MONTH(OrderDate)
                            ORDER BY OrderYear DESC, OrderMonth DESC;
                            ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MonthlySalesReportProperties report = new MonthlySalesReportProperties
                            {
                                OrderYear = Convert.ToInt32(reader["OrderYear"]),
                                OrderMonth = Convert.ToInt32(reader["OrderMonth"]),
                                TotalOrder = Convert.ToDecimal(reader["TotalOrders"]),
                                MonthlySales = Convert.ToDecimal(reader["MonthlySales"]),
                                AvgOrderMonthly = Convert.ToDecimal(reader["AvgOrderValue"])
                            };
                            salesReports.Add(report);
                        }
                    }
                }
            }
            return salesReports;
        }
    }
}


