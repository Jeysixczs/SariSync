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
        public string ConnectionString = @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private readonly string _imageBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductImages");

        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }
        public string? ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateExpired { get; set; }




        public List<Products> GetAllProducts()
        {
            List<Products> productsList = new List<Products>();

            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Product WHERE IsActive = 1", con))
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
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
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
            if (CheckDuplicateProduct(product.Name))
            {
                throw new Exception("A product with the same name already exists.");
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO tbl_Product 
                         (Name, Description, Category, Price, SellingPrice, Stock, ImagePath, DateAdded, DateExpired)
                         OUTPUT INSERTED.ProductID
                         VALUES (@Name, @Description, @Category, @Price, @SellingPrice, @Stock, @ImagePath, GETDATE(), @DateExpired)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateExpired", product.DateExpired ?? (object)DBNull.Value);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void UpdateProduct(Products product, string imagePath)
        {
            //
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Build query dynamically based on whether imagePath is provided
                string query = @"UPDATE tbl_Product 
                        SET Name = @Name, 
                            Description = @Description, 
                            Category = @Category, 
                            Price = @Price, 
                            SellingPrice = @SellingPrice,
                            Stock = @Stock, 
                            DateExpired = @DateExpired
                        {0}
                        WHERE ProductID = @ProductID";

                // Add ImagePath to query only if a new image is provided
                string imageClause = "";
                if (!string.IsNullOrEmpty(imagePath))
                {
                    imageClause = ", ImagePath = @ImagePath";
                }

                query = string.Format(query, imageClause);

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@DateExpired", product.DateExpired);

                    // Only add image parameter if a new image is provided
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                // Use UPDATE instead of DELETE to soft delete
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_Product SET IsActive = 0 WHERE ProductID = @ProductID", con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Products? GetProductById(int productId)
        {
            Products? product = null;


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM tbl_Product WHERE ProductID = @ProductID AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Products
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString(),
                                Category = reader["Category"]?.ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ImagePath = reader["ImagePath"]?.ToString(),
                                DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                                DateExpired = Convert.ToDateTime(reader["DateExpired"])
                            };
                        }
                    }
                }
            }
            return product;
        }

        public List<Products> SearchProduct(string searchTerm)
        {
            List<Products> products = new List<Products>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Product WHERE (Name LIKE @Search OR Category LIKE @Search OR Description LIKE @Search) AND IsActive = 1 ", con);
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
                            SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
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
                        query = "SELECT ProductID, Name, Category, Stock FROM tbl_Product WHERE Stock < 10 AND IsActive = 1";
                        break;
                    case "medium":
                        query = "SELECT ProductID, Name, Category, Stock FROM tbl_Product WHERE Stock BETWEEN 10 AND 50 AND IsActive = 1";
                        break;
                    case "high":
                        query = "SELECT ProductID, Name, Category, Stock FROM tbl_Product WHERE Stock > 50 AND IsActive = 1";
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
                string query = "select top 10 Name, Description, Category, Price, SellingPrice, Stock, DateAdded from tbl_Product WHERE IsActive = 1 order by DateAdded desc";
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
                            SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
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
        public bool CheckDuplicateProduct(string productName, int excludeProductId = 0)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM tbl_Product WHERE Name = @Name AND IsActive = 1 AND ProductID != @ExcludeProductId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);
                    cmd.Parameters.AddWithValue("@ExcludeProductID", excludeProductId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public Products? GetProductForOrder(int productId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT ProductID, Name, SellingPrice, Stock FROM tbl_Product WHERE ProductID = @ProductID AND IsActive = 1 AND Stock > 0";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Products
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Products> SearchProductsForOrder(string searchTerm)
        {
            List<Products> products = new List<Products>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT ProductID, Name, SellingPrice, Stock 
                           FROM tbl_Product 
                           WHERE (Name LIKE @Search OR Category LIKE @Search) 
                           AND IsActive = 1 
                           AND Stock > 0
                           ORDER BY Name";
                SqlCommand cmd = new SqlCommand(query, con);
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
                            SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                            Stock = Convert.ToInt32(reader["Stock"])
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Products> GetCategorys()
        {
            List<Products> categories = new List<Products>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT DISTINCT Category FROM tbl_Product WHERE IsActive = 1 ORDER BY Category";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products category = new Products
                            {
                                Category = reader["Category"]?.ToString() ?? string.Empty
                            };
                            categories.Add(category);
                        }
                    }
                }
            }
            return categories;
        }

        public object GetProductsByCategory(string? selectedCategory)
        {
            List<Products> productsList = new List<Products>();
            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT * FROM tbl_Product WHERE Category = @Category AND IsActive = 1", con))
                {
                    cmd.Parameters.AddWithValue("@Category", selectedCategory ?? string.Empty);
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
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
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

        public List<Products> GetExpiredProducts()
        {
            List<Products> expiredProducts = new List<Products>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM tbl_Product WHERE DateExpired < GETDATE() AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
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
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ImagePath = reader["ImagePath"]?.ToString(),
                                DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                                DateExpired = Convert.ToDateTime(reader["DateExpired"])
                            };
                            expiredProducts.Add(product);
                        }
                    }
                }
            }
            return expiredProducts;
        }

        public string DisplayExpiredProducts()
        {


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM tbl_Product WHERE DateExpired < GETDATE() AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int expiredCount = (int)cmd.ExecuteScalar();
                   
                    return expiredCount.ToString();
                }
            }

            
        
        }

        public string DisplayCriticalExpiredProducts()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM tbl_Product WHERE DateExpired < DATEADD(day, 30, GETDATE()) AND DateExpired >= GETDATE() AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int criticalExpiredCount = (int)cmd.ExecuteScalar();
                    return criticalExpiredCount.ToString();

                }
            }
        }

        public List<Products> GetCriticalExpiredProducts()
        {
            List<Products> criticalExpiredProducts = new List<Products>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM tbl_Product WHERE DateExpired < DATEADD(day, 30, GETDATE()) AND DateExpired >= GETDATE() AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
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
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                                Stock = Convert.ToInt32(reader["Stock"]),
                                ImagePath = reader["ImagePath"]?.ToString(),
                                DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                                DateExpired = Convert.ToDateTime(reader["DateExpired"])
                            };
                            criticalExpiredProducts.Add(product);
                        }
                    }
                }
            }
            return criticalExpiredProducts;
        }

        public void DeleteMultipleProducts(List<int> productIds)
        {
            if (productIds == null || productIds.Count == 0)
                return;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                // Create DataTable for table-valued parameter
                DataTable productIdTable = new DataTable();
                productIdTable.Columns.Add("ProductID", typeof(int));

                foreach (int productId in productIds)
                {
                    productIdTable.Rows.Add(productId);
                }

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE tbl_Product SET IsActive = 0 WHERE ProductID IN (SELECT ProductID FROM @ProductIDs)", con))
                {
                    SqlParameter param = cmd.Parameters.AddWithValue("@ProductIDs", productIdTable);
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.ProductIDList";

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}