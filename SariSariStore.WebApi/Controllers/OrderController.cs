using Microsoft.AspNetCore.Mvc;
using SariSariStore.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using SariSariStore.Core.Model;

namespace SariSariStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SariSariStoreContext DbContext;

        public OrderController(SariSariStoreContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrderItems()
        {
            return await DbContext.Orders.Include(o => o.Items).ToListAsync();



        }
    }
}
