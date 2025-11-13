using Microsoft.Data.SqlClient;
using SariSariStore.Core.Model;
using System.Data;

namespace SariSariStore.Core.Services
{
    public class OrderService
    {
        private readonly string _connectionString;

        public OrderService()
        {
            _connectionString = ConnectionHelper.GetConnectionString();
        }

        public int CreateOrder(Orders order, List<OrderItems> orderItems)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Validate stock before proceeding
                        foreach (var item in orderItems)
                        {
                            if (!HasSufficientStock(item.ProductID, item.Quantity, con, transaction))
                            {
                                throw new Exception($"Insufficient stock for product ID {item.ProductID}");
                            }
                        }

                        // Insert order without OUTPUT clause
                        string orderQuery = @"INSERT INTO tbl_Order 
                                    (CustomerName, Notes, Remarks, OrderDate, IsPaid, TotalAmount) 
                                    VALUES (@CustomerName, @Notes, @Remarks, @OrderDate, @IsPaid, @TotalAmount);
                                    SELECT SCOPE_IDENTITY();";

                        int orderId;
                        using (SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction))
                        {
                            orderCmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                            orderCmd.Parameters.AddWithValue("@Notes", order.Notes ?? "");
                            orderCmd.Parameters.AddWithValue("@Remarks", order.Remarks ?? "");
                            orderCmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                            orderCmd.Parameters.AddWithValue("@IsPaid", order.IsPaid);
                            orderCmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

                            orderId = Convert.ToInt32(orderCmd.ExecuteScalar());
                        }

                        // Insert order details
                        string detailQuery = @"INSERT INTO tbl_OrderDetails 
                                     (OrderID, ProductID, Quantity, UnitPrice, TotalPrice, ProductName) 
                                     VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice, @TotalPrice, @ProductName)";

                        foreach (var item in orderItems)
                        {
                            // Get product name for the order detail
                            string productName = GetProductNameById(item.ProductID, con, transaction);

                            using (SqlCommand detailCmd = new SqlCommand(detailQuery, con, transaction))
                            {
                                detailCmd.Parameters.AddWithValue("@OrderID", orderId);
                                detailCmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                                detailCmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                detailCmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                                detailCmd.Parameters.AddWithValue("@TotalPrice", item.Quantity * item.UnitPrice);
                                detailCmd.Parameters.AddWithValue("@ProductName", productName);

                                detailCmd.ExecuteNonQuery();
                            }

                            // Update product stock
                            UpdateProductStock(item.ProductID, item.Quantity, con, transaction);
                        }

                        transaction.Commit();
                        return orderId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Order creation failed: {ex.Message}", ex);
                    }
                }
            }
        }

        private bool HasSufficientStock(int productId, int quantity, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT Stock FROM tbl_Product WHERE ProductID = @ProductID AND IsActive = 1";

            using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return false;

                int currentStock = Convert.ToInt32(result);
                return currentStock >= quantity;
            }
        }

        private void UpdateProductStock(int productId, int quantity, SqlConnection connection, SqlTransaction transaction)
        {
            string updateQuery = "UPDATE tbl_Product SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.ExecuteNonQuery();
            }
        }

        public string GetProductNameById(int productId, SqlConnection connection = null, SqlTransaction transaction = null)
        {
            bool shouldCloseConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(_connectionString);
                    connection.Open();
                    shouldCloseConnection = true;
                }

                string query = "SELECT Name FROM tbl_Product WHERE ProductID = @ProductID AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    var result = cmd.ExecuteScalar();

                    return result?.ToString() ?? "Unknown Product";
                }
            }
            finally
            {
                if (shouldCloseConnection && connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public Orders GetOrderWithDetails(int orderId)
        {
            Orders order = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                // Get order 
                string orderQuery = "SELECT * FROM tbl_Order WHERE OrderID = @OrderID";
                using (SqlCommand orderCmd = new SqlCommand(orderQuery, con))
                {
                    orderCmd.Parameters.AddWithValue("@OrderID", orderId);
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

                // Get order items
                if (order != null)
                {
                    string itemsQuery = @"SELECT od.*, p.Name as ProductName 
                                        FROM tbl_OrderDetails od 
                                        INNER JOIN tbl_Product p ON od.ProductID = p.ProductID 
                                        WHERE od.OrderID = @OrderID
                                        ORDER BY od.OrderDetailID";
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
                                    ProductName = reader["ProductName"]?.ToString() ?? "Unknown Product",
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                               
                                };
                                order.Items.Add(item);
                            }
                        }
                    }
                }
            }
            return order;
        }

        public List<Orders> GetAllOrders()
        {
            var orders = new List<Orders>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = @"SELECT o.*, 
                                (SELECT COUNT(*) FROM tbl_OrderDetails od WHERE od.OrderID = o.OrderID) as ItemCount
                                FROM tbl_Order o 
                                ORDER BY o.OrderDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Orders
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
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public bool DeleteOrder(int orderId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // First, restore product stock
                        string getItemsQuery = "SELECT ProductID, Quantity FROM tbl_OrderDetails WHERE OrderID = @OrderID";
                        var itemsToRestore = new List<(int ProductID, int Quantity)>();

                        using (SqlCommand getCmd = new SqlCommand(getItemsQuery, con, transaction))
                        {
                            getCmd.Parameters.AddWithValue("@OrderID", orderId);
                            using (SqlDataReader reader = getCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    itemsToRestore.Add((
                                        Convert.ToInt32(reader["ProductID"]),
                                        Convert.ToInt32(reader["Quantity"])
                                    ));
                                }
                            }
                        }

                        // Restore stock for each product
                        foreach (var (productId, quantity) in itemsToRestore)
                        {
                            UpdateProductStock(productId, -quantity, con, transaction); // Negative quantity to add back
                        }

                        // Delete order details
                        string deleteDetailsQuery = "DELETE FROM tbl_OrderDetails WHERE OrderID = @OrderID";
                        using (SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, con, transaction))
                        {
                            deleteDetailsCmd.Parameters.AddWithValue("@OrderID", orderId);
                            deleteDetailsCmd.ExecuteNonQuery();
                        }

                        // Delete order
                        string deleteOrderQuery = "DELETE FROM tbl_Order WHERE OrderID = @OrderID";
                        using (SqlCommand deleteOrderCmd = new SqlCommand(deleteOrderQuery, con, transaction))
                        {
                            deleteOrderCmd.Parameters.AddWithValue("@OrderID", orderId);
                            int affectedRows = deleteOrderCmd.ExecuteNonQuery();

                            transaction.Commit();
                            return affectedRows > 0;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}