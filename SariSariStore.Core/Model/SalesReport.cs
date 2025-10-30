using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    [Table("tbl_SalesReport")]
    public class SalesReport
    {
        public string ConnectionString = @"Data Source=DESKTOP-ECKGUHL\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";


        public int ReportID { get; set; }
        
        public string ReportMonth { get; set; } = string.Empty;
        public int ReportYear { get; set; }

        public decimal TotalSales { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetProfit { get; set; }
        public DateTime DateGenerated { get; set; }

        

        public List<SalesReport> SalesReports()
        {
            List<SalesReport> salesReports = new List<SalesReport>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_SalesReport", con);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SalesReport salesreport = new SalesReport
                        {
                            ReportID = Convert.ToInt32(reader["ReportID"]),
                            ReportMonth = reader["ReportMonth"].ToString() ?? string.Empty,
                            ReportYear = Convert.ToInt32(reader["ReportYear"]),
                            TotalSales = Convert.ToDecimal(reader["TotalSales"]),
                            TotalExpenses = Convert.ToDecimal(reader["TotalExpenses"]),
                            NetProfit = Convert.ToDecimal(reader["NetProfit"]),
                            DateGenerated = Convert.ToDateTime(reader["DateGenerated"])

                        };
                        salesReports.Add(salesreport);
                    }
                }

                con.Close();
            }
            return salesReports;
        }

        public List<SalesReport> GetSalesReportsMonth()
        {
           
            List<SalesReport> month = new List<SalesReport>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT s.ReportID, s.ReportMonth, s.ReportYear, s.TotalSales AS ReportedSales, ISNULL(o.TotalSales, 0) AS ActualSalesFromOrders, s.TotalExpenses,    s.NetProfit, s.DateGenerated\r\nFROM tbl_SalesReport s\r\nLEFT JOIN (\r\n    SELECT \r\n        DATENAME(MONTH, OrderDate) AS ReportMonth, YEAR(OrderDate) AS ReportYear, SUM(TotalAmount) AS TotalSales FROM tbl_Order GROUP BY YEAR(OrderDate), DATENAME(MONTH, OrderDate)) o ON s.ReportMonth = o.ReportMonth AND s.ReportYear = o.ReportYear ORDER BY s.ReportYear, s.ReportID;", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesReport mth = new SalesReport
                            {

                                ReportYear = Convert.ToInt32(reader["ReportYear"]),
                                TotalSales = Convert.ToDecimal(reader["TotalSales"]),
                            };
                            month.Add(mth);
                        }
                    }
                }

            }

            return month;

        }


        public List<SalesReport> GetSalesReportsYear(int value)
        {
            List<SalesReport> yearReports = new List<SalesReport>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string query = @"
            SELECT 
                YEAR(OrderDate) AS ReportYear, 
                SUM(TotalAmount) AS TotalSales
            FROM tbl_Order
            WHERE YEAR(OrderDate) = @Value
            GROUP BY YEAR(OrderDate)
            ORDER BY ReportYear";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Value", value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesReport sr = new SalesReport
                            {
                                ReportYear = Convert.ToInt32(reader["ReportYear"]),
                                TotalSales = Convert.ToDecimal(reader["TotalSales"])
                            };

                            yearReports.Add(sr);
                        }
                    }
                }
            }

            return yearReports;
        }

        public List<SalesReport> Monthly(string month, int yr)
        {
            List<SalesReport> reports = new List<SalesReport>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                string query = "SELECT * FROM tbl_SalesReport WHERE ReportMonth = @month AND ReportYear = @yr;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@yr", yr);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesReport sr = new SalesReport
                            {
                                ReportID = Convert.ToInt32(reader["ReportID"]),
                                ReportMonth = reader["ReportMonth"].ToString() ?? string.Empty,
                                ReportYear = Convert.ToInt32(reader["ReportYear"]),
                                TotalSales = Convert.ToDecimal(reader["TotalSales"]),
                                TotalExpenses = Convert.ToDecimal(reader["TotalExpenses"]),
                                NetProfit = Convert.ToDecimal(reader["NetProfit"]),
                                DateGenerated = Convert.ToDateTime(reader["DateGenerated"])
                            };

                            reports.Add(sr);
                        }
                    }
                }
            }

            return reports;
        }





    }
}
    
