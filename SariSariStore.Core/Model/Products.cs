using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System;


namespace SariSariStore.Core.Model
{
    [Table("tbl_Products")]
    public class Products
    {
        public string ConnectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=db_SariSync;Integrated Security=True;Trust Server Certificate=True";
        private readonly string _imageBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");


        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }




        public List<Products> GetAllProducts()
        {
            List<Products> productsList = new List<Products>();

            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Products", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products product = new Products
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString(),
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                Image = reader["Image"]?.ToString()
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
                    string query = @"INSERT INTO tbl_Products (Name, Description, Category, Price, Stock, Image) 
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
                string finalImagePath = product.Image ?? string.Empty;

                // Handle new image if provided
                if (!string.IsNullOrEmpty(newImageFilePath) && File.Exists(newImageFilePath))
                {
                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(product.Image) && File.Exists(product.Image))
                    {
                        File.Delete(product.Image);
                    }

                    // Save new image
                    finalImagePath = SaveImage(newImageFilePath);
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE tbl_Products
                                     SET Name = @Name, Description = @Description, Category = @Category, 
                                         Price = @Price, Stock = @Stock, Image = @Image 
                                     WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", product.Id);
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

                if (product != null && !string.IsNullOrEmpty(product.Image) && File.Exists(product.Image))
                {
                    File.Delete(product.Image);
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM tbl_Products WHERE Id = @Id";
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
                using (SqlCommand cmd = new("SELECT * FROM tbl_Products WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Products
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString(),
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                Image = reader["Image"]?.ToString()
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