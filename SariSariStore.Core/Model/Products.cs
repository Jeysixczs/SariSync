using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System;
using System.ComponentModel.DataAnnotations;


namespace SariSariStore.Core.Model
{
    [Table("tbl_Product")]
    public class Products
    {
        public string ConnectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True";
        private readonly string _imageBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");

        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImagePath { get; set; }
        public DateTime DateAdded { get; set; }




        public List<Products> GetAllProducts()
        {
            List<Products> productsList = new List<Products>();

            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Product", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products product = new Products
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString(),
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ImagePath = reader["ImagePath"]?.ToString()
                            };
                            productsList.Add(product);
                        }
                    }
                }
            }
            return productsList;
        }

        public int AddProduct(Products product, string imageFilePath)
        {
            try
            {
                string finalImagePath = string.Empty;

                if (!string.IsNullOrEmpty(imageFilePath) && File.Exists(imageFilePath))
                {
                    finalImagePath = SaveImage(imageFilePath);
                }

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string query = @"INSERT INTO tbl_Product (Name, Description, Category, Price, Stock, Image) 
                                   VALUES (@Name, @Description, @Category, @Price, @Stock, @Image);
                                   SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Description", product.Description);
                        cmd.Parameters.AddWithValue("@Category", product.Category);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Stock", product.Stock);
                        cmd.Parameters.AddWithValue("@Image", (object)finalImagePath ?? DBNull.Value);

                        con.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding product: {ex.Message}", ex);
            }
        }

        public void UpdateProduct(Products product, string newImageFilePath)
        {
            try
            {
                string finalImagePath = product.ImagePath ?? string.Empty;

                // Handle new image if provided
                if (!string.IsNullOrEmpty(newImageFilePath) && File.Exists(newImageFilePath))
                {
                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                    {
                        File.Delete(product.ImagePath);
                    }

                    // Save new image
                    finalImagePath = SaveImage(newImageFilePath);
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE tbl_Product
                                     SET Name = @Name, Description = @Description, Category = @Category, 
                                         Price = @Price, Stock = @Stock, Image = @Image 
                                     WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", product.ProductID);
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@Category", product.Category);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Stock", product.Stock);
                        command.Parameters.AddWithValue("@Image", (object)finalImagePath ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}", ex);
            }
        }


        public void DeleteProduct(int productId)
        {
            try
            {
                // First get the product to delete associated image
                Products product = GetProductById(productId);

                if (product != null && !string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                {
                    File.Delete(product.ImagePath);
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM tbl_Product WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", productId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}", ex);
            }
        }


        public Products GetProductById(int id)
        {
            // find product by id if exists else message not found
            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Product WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Products
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString(),
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ImagePath = reader["ImagePath"]?.ToString()
                            };
                        }
                        else
                        {
                            throw new Exception("Product not found.");
                        }
                    }
                }
            }

        }

        public string SaveImage(string imagePath)
        {
            try
            {
                if (!Directory.Exists(_imageBasePath))
                {
                    Directory.CreateDirectory(_imageBasePath);
                }

                string extension = Path.GetExtension(imagePath);
                string fileName = $"{Guid.NewGuid()}{extension}";
                string destPath = Path.Combine(_imageBasePath, fileName);

                File.Copy(imagePath, destPath, true);
                return destPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving image: {ex.Message}", ex);
            }
        }
    }
}