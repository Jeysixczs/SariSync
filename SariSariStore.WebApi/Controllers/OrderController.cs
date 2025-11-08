using Microsoft.AspNetCore.Mvc;
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
                // Validate products and calculate total amount
                decimal totalAmount = 0;
                var orderItemsList = new List<OrderItems>();

                foreach (var itemDto in orderDto.Items)
                {
                    // Get product with current price and stock using EF
                    var product = await _context.Products
                        .FirstOrDefaultAsync(p => p.ProductID == itemDto.ProductID && p.Stock >= itemDto.Quantity);

                    if (product == null)
                    {
                        return BadRequest($"Product with ID {itemDto.ProductID} not found or insufficient stock.");
                    }

                    // Use current selling price from product
                    var unitPrice = product.SellingPrice;
                    var itemTotal = itemDto.Quantity * unitPrice;
                    totalAmount += itemTotal;

                   
                    // Create order item
                    var orderItem = new OrderItems
                    {
                        ProductID = itemDto.ProductID,
                        ProductName = orderService.GetProductNameById(product.ProductID),
                        
                        Quantity = itemDto.Quantity,
                        UnitPrice = unitPrice,
                        TotalPrice = itemTotal
                    };

                    orderItemsList.Add(orderItem);
                }

                // Create order entity
                var order = new Orders
                {
                    CustomerName = orderDto.CustomerName,
                    Notes = orderDto.Notes ?? "",
                    Remarks = orderDto.Remarks ?? "",
                    IsPaid = orderDto.IsPaid,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = totalAmount
                };

                // Use the service to create order with raw SQL (bypassing EF triggers issue)
                int orderId = _orderService.CreateOrder(order, orderItemsList);

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