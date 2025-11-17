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
    [Table("tbl_Suppliers")]
    public class Supplier
    {
        public string ConnectionString = ConnectionHelper.GetConnectionString();
        [Key]
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string ContactPerson { get; set; }

        public string? PhoneNumber { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }= true;

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
   
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> sup = new List<Supplier>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Select distinct * from tbl_suppliers where IsActive = 1", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                                SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty,
                                ContactPerson = reader["ContactPerson"]?.ToString() ?? string.Empty,
                                PhoneNumber = reader["PhoneNumber"]?.ToString() ?? string.Empty,
                                Address = reader["Address"]?.ToString() ?? string.Empty,
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"])



                            };
                            sup.Add(supplier);
                        }
                    }
                }


            }
            return sup;
        }




        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_suppliers WHERE SupplierID = @SupplierID AND IsActive = 1", con))
                {
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplier = new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                                SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty,
                                ContactPerson = reader["ContactPerson"]?.ToString() ?? string.Empty,
                                PhoneNumber = reader["PhoneNumber"]?.ToString() ?? string.Empty,
                                Address = reader["Address"]?.ToString() ?? string.Empty,
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return supplier;
        }

        public string GetSupplierNameByProduct(int productId)
        {
            string connectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";

            string query = @"
        SELECT s.SupplierName 
        FROM tbl_suppliers s
        INNER JOIN tbl_product p ON s.SupplierID = p.SupplierID
        WHERE p.ProductID = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    connection.Open();

                    object result = command.ExecuteScalar();

                    return (result != null && result != DBNull.Value) ? result.ToString() : null;
                }
            }
        }
        public void AddSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbl_suppliers (SupplierName, ContactPerson, PhoneNumber, Address, CreatedDate) VALUES (@SupplierName, @ContactPerson, @PhoneNumber, @Address, @CreatedDate)", con))
                {
                    cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName ?? string.Empty);
                    cmd.Parameters.AddWithValue("@ContactPerson", supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@PhoneNumber", supplier.PhoneNumber ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@CreatedDate", supplier.CreatedDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_suppliers SET SupplierName = @SupplierName, ContactPerson = @ContactPerson, PhoneNumber = @PhoneNumber, Address = @Address WHERE SupplierID = @SupplierID", con))
                {
                    cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName ?? string.Empty);
                    cmd.Parameters.AddWithValue("@ContactPerson", supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@PhoneNumber", supplier.PhoneNumber ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(" UPDATE tbl_suppliers set isActive = 0 where SupplierID = @SupplierID", con))
                {
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                    cmd.ExecuteNonQuery();
                }
            }


        }


        public List<Supplier> GetSupplierName()
        {
            List<Supplier> sup = new List<Supplier>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT DISTINCT SupplierName, SupplierID FROM tbl_suppliers WHERE IsActive = 1 ORDER BY SupplierName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                                SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty
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
