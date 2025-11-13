using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SariSariStore.Core.Model;
using SariSariStore.Core.Services;
using SariSariStore.Core.Services.Interface;
using SariSariStore.WebApi.Data;

namespace SariSariStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SariSariStoreContext _context;
        private readonly OrderService _orderService;
       public OrderService orderService = new OrderService();
        public OrderController(SariSariStoreContext context)
        {
            _context = context;
            _orderService = new OrderService();
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            if (orderDto == null || orderDto.Items == null || !orderDto.Items.Any())
            {
                return BadRequest("Invalid order data.");
            }

            try
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                decimal totalAmount = 0;
                var productUpdates = new List<(int ProductId, int Quantity)>();

                // Calculate total and validate products first
                foreach (var itemDto in orderDto.Items)
                {
                    var product = await _context.Products
                        .FirstOrDefaultAsync(p => p.ProductID == itemDto.ProductID && p.Stock >= itemDto.Quantity);

                    if (product == null)
                    {
                        return BadRequest($"Product with ID {itemDto.ProductID} not found or insufficient stock.");
                    }

                    var unitPrice = product.SellingPrice;
                    var itemTotal = itemDto.Quantity * unitPrice;
                    totalAmount += itemTotal;
                    productUpdates.Add((product.ProductID, itemDto.Quantity));
                }

                
                var orderSql = @"
            INSERT INTO tbl_Order (CustomerName, Notes, Remarks, IsPaid, OrderDate, TotalAmount) 
            VALUES (@CustomerName, @Notes, @Remarks, @IsPaid, @OrderDate, @TotalAmount);
            SELECT CAST(SCOPE_IDENTITY() as int);";

                var orderId = (await _context.Database.SqlQueryRaw<int>(orderSql,
                    new SqlParameter("@CustomerName", orderDto.CustomerName),
                    new SqlParameter("@Notes", orderDto.Notes ?? ""),
                    new SqlParameter("@Remarks", orderDto.Remarks ?? ""),
                    new SqlParameter("@IsPaid", orderDto.IsPaid),
                    new SqlParameter("@OrderDate", DateTime.UtcNow),
                    new SqlParameter("@TotalAmount", totalAmount)
                ).ToListAsync()).FirstOrDefault();

            
                foreach (var itemDto in orderDto.Items)
                {
                    var product = await _context.Products.FindAsync(itemDto.ProductID);
                    var unitPrice = product.SellingPrice;
                    var itemTotal = itemDto.Quantity * unitPrice;

                    var detailSql = @"
                INSERT INTO tbl_OrderDetails (OrderID, ProductID, Quantity, UnitPrice, TotalPrice) 
                VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice, @TotalPrice)";

                    await _context.Database.ExecuteSqlRawAsync(detailSql,
                        new SqlParameter("@OrderID", orderId),
                        new SqlParameter("@ProductID", itemDto.ProductID),
                        new SqlParameter("@Quantity", itemDto.Quantity),
                        new SqlParameter("@UnitPrice", unitPrice),
                        new SqlParameter("@TotalPrice", itemTotal));

                    // Update stock using raw SQL
                    var updateStockSql = @"
                UPDATE tbl_Product 
                SET Stock = Stock - @Quantity 
                WHERE ProductID = @ProductID";

                    await _context.Database.ExecuteSqlRawAsync(updateStockSql,
                        new SqlParameter("@Quantity", itemDto.Quantity),
                        new SqlParameter("@ProductID", itemDto.ProductID));
                }

                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Order created successfully",
                    orderId = orderId,
                    totalAmount = totalAmount
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating order: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDto>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new OrderResponseDto
                {
                    OrderID = o.OrderID,
                    CustomerName = o.CustomerName,
                    Notes = o.Notes,
                    Remarks = o.Remarks,
                    OrderDate = o.OrderDate,
                    IsPaid = o.IsPaid,
                    TotalAmount = o.TotalAmount,
                    Items = o.Items.Select(i => new OrderItemResponseDto
                    {
                        OrderDetailID = i.OrderDetailID,
                        ProductID = i.ProductID,


                        ProductName = _context.Products
                                .Where(p => p.ProductID == i.ProductID)
                                .Select(p => p.Name)
                                .FirstOrDefault() ?? "Unknown Product",

                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        TotalPrice = i.TotalPrice
                    }).ToList()
                })
                .ToListAsync();

            return Ok(orders);
        }

        [HttpPut("DeleteOrder/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                var order = await _context.Orders.FindAsync(orderId);
                if (order == null)
                {
                    return NotFound($"Order with ID {orderId} not found.");
                }
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Order deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting order: {ex.Message}");
            }
        }

    }
}