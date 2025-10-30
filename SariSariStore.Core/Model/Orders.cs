using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace SariSariStore.Core.Model
{
    [Table("tbl_Order")]
    public class Orders
    {
        //send Order to the database
        public string ConnectionString = @"Data Source=DESKTOP-ECKGUHL\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        [Key]
        public int OrderID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }

        public List<OrderItems> Items { get; set; } = new List<OrderItems>();

        public bool IsPaid { get; set; }

        public decimal TotalAmount { get; set; }

        public List<Orders> GetAllOrders()
        {
            List<Orders> orderList = new List<Orders>();
            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Order", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders order = new Orders
                            {
                                
                                OrderID = Convert.ToInt32(reader["OrderID"]),
                                CustomerName = reader["CustomerName"]?.ToString() ?? string.Empty,
                                Notes = reader["Notes"]?.ToString() ?? string.Empty,
                                Remarks = reader["Remarks"]?.ToString() ?? string.Empty,
                                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                              //  IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                            };
                            orderList.Add(order);
                        }
                    }
                }
            }
            return orderList;
        }
    }
}
   
