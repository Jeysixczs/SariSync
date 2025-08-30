using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SariSariStore.Core.Model;
using SariSariStore.WebApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SariSariStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly SariSariStoreContext DbContext;

        public ProductController(SariSariStoreContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await DbContext.Products.ToListAsync();
        }


        //get image by id
        [HttpGet("{id}/image")]
        public async Task<IActionResult> GetProductImage(int id)
        {
            var product = await DbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }


            if (string.IsNullOrEmpty(product.Image))
            {
                return NotFound("This product doesn't have an associated image");
            }


            if (!System.IO.File.Exists(product.Image))
            {
                return NotFound("Image file not found");
            }

            var imageFileStream = System.IO.File.OpenRead(product.Image);
            return File(imageFileStream, "image/jpeg");
        }


    }
}
