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
        public string ConnectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";


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
    }
}
