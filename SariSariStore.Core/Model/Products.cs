using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace SariSariStore.Core.Model
{
    [Table("tbl_Product")]
    public class Products
    {
        public string ConnectionString = ConnectionHelper.GetConnectionString();
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
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = string.Empty;



        public List<Products> GetAllProducts()
        {
            List<Products> productsList = new List<Products>();

            using (SqlConnection con = new(ConnectionString))
            {
                using (SqlCommand cmd = new("SELECT tbl_Product.*, tbl_suppliers.SupplierName FROM tbl_Product LEFT JOIN tbl_suppliers ON tbl_Product.SupplierID = tbl_suppliers.SupplierID WHERE tbl_Product.IsActive = 1", con))
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
                                DateExpired = Convert.ToDateTime(reader["DateExpired"]),
                                SupplierID = Convert.ToInt32(reader["SupplierID"]),
                                SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty

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

            // Validate SupplierID exists
            if (product.SupplierID > 0 && !SupplierExists(product.SupplierID))
            {
                throw new Exception($"Supplier with ID {product.SupplierID} does not exist.");
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO tbl_Product 
            (Name, Description, Category, Price, SellingPrice, Stock, ImagePath, DateAdded, DateExpired, SupplierID)
            OUTPUT INSERTED.ProductID
            VALUES (@Name, @Description, @Category, @Price, @SellingPrice, @Stock, @ImagePath, GETDATE(), @DateExpired, @SupplierID)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateExpired", product.DateExpired);

                    // Handle SupplierID properly - use DBNull.Value if 0
                    if (product.SupplierID > 0)
                    {
                        command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SupplierID", DBNull.Value);
                    }

                    return (int)command.ExecuteScalar();
                }
            }
        }

        // Add this method to check if supplier exists
        private bool SupplierExists(int supplierId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM tbl_suppliers WHERE SupplierID = @SupplierID AND IsActive = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", supplierId);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        public string GetSupplierNameByProduct(int productId)
        {
            string supplierName = null;
            string connectionString = ConnectionHelper.GetConnectionString();

            string query = @"
        SELECT tbl_suppliers.SupplierName 
        FROM tbl_Product 
        INNER JOIN tbl_suppliers ON tbl_Product.SupplierID = tbl_suppliers.SupplierID
        WHERE tbl_Product.SupplierID = @SupplierID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierID", productId);
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        supplierName = result.ToString();
                    }
                }
            }

            return supplierName;
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
                    command.Parameters.AddWithValue("@SupplierID", product.SupplierID);


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
                                DateExpired = Convert.ToDateTime(reader["DateExpired"]),
                                SupplierID = Convert.ToInt32(reader["SupplierID"])
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
                            DateExpired = Convert.ToDateTime(reader["DateExpired"]),
                            SupplierName = GetSupplierNameByProduct(Convert.ToInt32(reader["SupplierID"]))
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
                string query = "SELECT TOP 10 Name, Description, Category, Price, SellingPrice, Stock, DateAdded,tbl_suppliers.SupplierName FROM tbl_Product LEFT JOIN tbl_suppliers ON tbl_Product.SupplierID = tbl_suppliers.SupplierID WHERE tbl_Product.IsActive = 1 ORDER BY DateAdded DESC\r\n";
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
                            SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty

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
                using (SqlCommand cmd = new("SELECT tbl_Product.*, tbl_suppliers.SupplierName FROM tbl_Product LEFT JOIN tbl_suppliers ON tbl_Product.SupplierID = tbl_suppliers.SupplierID WHERE Category = @Category AND tbl_Product.IsActive = 1", con))
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
                                DateExpired = Convert.ToDateTime(reader["DateExpired"]),
                                SupplierName = reader["SupplierName"]?.ToString() ?? string.Empty

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