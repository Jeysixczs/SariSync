using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    [Table("tbl_Supplier")]
    public class Supplier
    {
        public string ConnectionString = @"Data Source=DESKTOP-ECKGUHL\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";
        [Key]
        public int SupplierID { get; set; }
        public string ? SupplierName { get; set; } 
        public int ProductID { get; set; }
       
        public string ? ProductName { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> sup = new List<Supplier>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Select * from tbl_Supplier", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                                SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty,
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"]?.ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Category = reader["Category"]?.ToString()?? string.Empty,
                                                           
                            };
                            sup.Add(supplier);
                        }
                    }
                }


            }
            return sup;
        }
        

    }
}
