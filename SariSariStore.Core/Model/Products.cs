using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.IO;


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
        public DateTime? DateExpired { get; set; }




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
                                ImagePath = reader["ImagePath"]?.ToString(),
                                DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                                DateExpired = Convert.ToDateTime(reader["DateExpired"])
                            };
                            productsList.Add(product);
                        }
                    }
                }
            }
            return productsList;
        }

        public int AddProduct(Products product, string imagePath)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO tbl_Product 
                         (Name, Description, Category, Price, Stock, ImagePath, DateAdded, DateExpired)
                         OUTPUT INSERTED.ProductID
                         VALUES (@Name, @Description, @Category, @Price, @Stock, @ImagePath, GETDATE(), @DateExpired)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateExpired", product.DateExpired ?? (object)DBNull.Value);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void UpdateProduct(Products product, string imagePath)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = @"UPDATE tbl_Product 
                         SET Name = @Name, Description = @Description, Category = @Category, 
                             Price = @Price, Stock = @Stock, ImagePath = @ImagePath,
                             DateExpired = @DateExpired
                         WHERE ProductID = @ProductID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateExpired", product.DateExpired ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteProduct(int productId)
        {
            try
            {
               
                Products product = GetProductById(productId);

                if (product != null && !string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                {
                    File.Delete(product.ImagePath);
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM tbl_Product WHERE ProductID = @ProductID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productId);
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
         
            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Product WHERE ProductID = @ProductID", con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", id);
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
                                ImagePath = reader["ImagePath"]?.ToString(),
                                DateExpired = Convert.ToDateTime(reader["DateExpired"])
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

        public List<Products> SearchProduct(string searchTerm)
        {
            List<Products> products = new List<Products>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
           
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Product WHERE Name LIKE @Search OR Category LIKE @Search OR Description LIKE @Search", con);
                cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

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
                            ImagePath = reader["ImagePath"]?.ToString(),
                            DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                            DateExpired = Convert.ToDateTime(reader["DateExpired"])
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public List<Products> GetStockProducts(string stockLevel)
        {
            List<Products> stockProducts = new List<Products>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = string.Empty;

             
                switch (stockLevel.ToLower())
                {
                    case "low":
                        query = "SELECT ProductID, Name, Category, Stock FROM tbl_Product WHERE Stock < 10";
                        break;
                    case "medium":
                        query = "SELECT ProductID, Name, Category, Stock FROM tbl_Product WHERE Stock BETWEEN 10 AND 50";
                        break;
                    case "high":
                        query = "SELECT ProductID, Name, Category, Stock FROM tbl_Product WHERE Stock > 50";
                        break;
                    
                }

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products
                        {
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                            Name = reader["Name"]?.ToString() ?? string.Empty,
                           
                            Category = reader["Category"]?.ToString() ?? string.Empty,
                           
                            Stock = Convert.ToInt32(reader["Stock"]),
                           
                        };
                        stockProducts.Add(product);
                    }
                }
            }

            return stockProducts;
        }

        public List<Products> Gettop10Products()
        {
            List<Products> topProducts = new List<Products>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "select top 10 Name, Description, Category, Price, Stock, DateAdded from tbl_Product order by DateAdded desc";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products
                        {
                           
                            Name = reader["Name"]?.ToString() ?? string.Empty,
                            Description = reader["Description"]?.ToString(),
                            Category = reader["Category"]?.ToString() ?? string.Empty,
                            Price = Convert.ToDecimal(reader["Price"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                        };
                        topProducts.Add(product);
                    }
                }
            }
            return topProducts;
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