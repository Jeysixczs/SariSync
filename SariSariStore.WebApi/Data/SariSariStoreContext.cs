using Microsoft.EntityFrameworkCore;
using SariSariStore.Core.Model;

namespace SariSariStore.WebApi.Data
{
    public class SariSariStoreContext : DbContext
    {
        
        public SariSariStoreContext(DbContextOptions<SariSariStoreContext> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }


    }
}
