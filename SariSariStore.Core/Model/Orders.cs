using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;


namespace SariSariStore.Core.Model
{
    [Table("tbl_Order")]
    public class Orders
    {
        //send Order to the database
        public string ConnectionString = ConnectionHelper.GetConnectionString();
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
                using (SqlCommand cmd = new("SELECT * FROM tbl_Order order by OrderID desc", con))
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
                                IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                            };
                            orderList.Add(order);
                        }
                    }
                }
            }
            return orderList;
        }

        public int CreateOrder(Orders order, List<OrderItems> orderItems)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                       
                        string orderQuery = @"INSERT INTO tbl_Order 
                                    (CustomerName, Notes, Remarks, OrderDate, IsPaid, TotalAmount) 
                                    OUTPUT INSERTED.OrderID 
                                    VALUES (@CustomerName, @Notes, @Remarks, @OrderDate, @IsPaid, @TotalAmount)";

                        int orderId;
                        using (SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction))
                        {
                            orderCmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                            orderCmd.Parameters.AddWithValue("@Notes", order.Notes ?? "");
                            orderCmd.Parameters.AddWithValue("@Remarks", order.Remarks ?? "");
                            orderCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                            orderCmd.Parameters.AddWithValue("@IsPaid", order.IsPaid);
                            orderCmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

                            orderId = (int)orderCmd.ExecuteScalar();
                        }

                        // Insert order details with calculated TotalPrice
                        string detailQuery = @"INSERT INTO tbl_OrderDetails 
                                     (OrderID, ProductID, Quantity, UnitPrice, TotalPrice) 
                                     VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice, @TotalPrice)";

                        foreach (var item in orderItems)
                        {
                            using (SqlCommand detailCmd = new SqlCommand(detailQuery, con, transaction))
                            {
                                detailCmd.Parameters.AddWithValue("@OrderID", orderId);
                                detailCmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                                detailCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                detailCmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                                detailCmd.Parameters.AddWithValue("@TotalPrice", item.Quantity * item.UnitPrice);

                                detailCmd.ExecuteNonQuery();
                            }

                            // Update product stock
                     
                        }

                        transaction.Commit();
                        return orderId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public Orders? GetOrderWithDetails(int orderId)
        {
            Orders? order = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Get order 
                string orderQuery = "SELECT * FROM tbl_Order WHERE OrderID = @OrderID";
                using (SqlCommand orderCmd = new SqlCommand(orderQuery, con))
                {
                    orderCmd.Parameters.AddWithValue("@OrderID", orderId);
                    con.Open();
                    using (var reader = orderCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Orders
                            {
                                OrderID = Convert.ToInt32(reader["OrderID"]),
                                CustomerName = reader["CustomerName"]?.ToString() ?? string.Empty,
                                Notes = reader["Notes"]?.ToString() ?? string.Empty,
                                Remarks = reader["Remarks"]?.ToString() ?? string.Empty,
                                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                                IsPaid = Convert.ToBoolean(reader["IsPaid"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                Items = new List<OrderItems>()
                            };
                        }
                    }
                }
                //for order items
                if (order != null)
                {
                    //Get order items
                    string itemsQuery = @"SELECT od.*, p.Name as ProductName 
                                        FROM tbl_OrderDetails od 
                                        INNER JOIN tbl_Product p ON od.ProductID = p.ProductID 
                                        WHERE od.OrderID = @OrderID";
                    using (SqlCommand itemsCmd = new SqlCommand(itemsQuery, con))
                    {
                        itemsCmd.Parameters.AddWithValue("@OrderID", orderId);
                        using (SqlDataReader reader = itemsCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderItems item = new OrderItems
                                {
                                    OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                                    OrderID = Convert.ToInt32(reader["OrderID"]),
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                              
                                };
                                order.Items.Add(item);
                            }
                        }
                    }
                }
            }
            return order;
        }

        public Products GetProductForCart(int productId)
        {
            Products product = null;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT ProductID, Name, SellingPrice, Stock 
                        FROM tbl_Product 
                        WHERE ProductID = @ProductID AND Stock > 0";

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
                                SellingPrice = Convert.ToDecimal(reader["SellingPrice"]),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };
                        }
                    }
                }
            }
            return product;
        }
        // Add this method to your Orders class in SariSariStore.Core.Model
        public bool ProcessOrder(Orders order, List<OrderItems> orderItems)
        {
            try
            {
                // Create the order and get the OrderID
                int orderId = CreateOrder(order, orderItems);

                if (orderId > 0)
                {
                    // Update product stock for each item
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            try
                            {
                                foreach (var item in orderItems)
                                {
                                    // Update product stock
                                    string updateStockQuery = @"UPDATE tbl_Product 
                                                      SET Stock = Stock - @Quantity 
                                                      WHERE ProductID = @ProductID AND Stock >= @Quantity";

                                    using (SqlCommand updateCmd = new SqlCommand(updateStockQuery, con, transaction))
                                    {
                                        updateCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                        updateCmd.Parameters.AddWithValue("@ProductID", item.ProductID);

                                        int rowsAffected = updateCmd.ExecuteNonQuery();
                                        if (rowsAffected == 0)
                                        {
                                            throw new Exception($"Insufficient stock for product ID: {item.ProductID}");
                                        }
                                    }
                                }
                                transaction.Commit();

                                // Set the OrderID for the receipt
                                order.OrderID = orderId;
                                return true;
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing order: {ex.Message}", ex);
            }
        }
        //method to search orders
        public List<Orders> SearchOrders(string searchTerm)
        {
            List<Orders> orderList = new List<Orders>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT * FROM tbl_Order 
                               WHERE OrderID Like @Search OR
                               CustomerName LIKE @Search 
                                  OR Notes LIKE @Search 
                                  OR Remarks LIKE @Search
                               ORDER BY OrderDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");
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
                                IsPaid = Convert.ToBoolean(reader["IsPaid"]),
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
   
