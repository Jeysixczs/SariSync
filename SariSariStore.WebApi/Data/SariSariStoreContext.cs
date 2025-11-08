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
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map to correct table names
            modelBuilder.Entity<Products>().ToTable("tbl_Product");
            modelBuilder.Entity<Supplier>().ToTable("tbl_suppliers");
            modelBuilder.Entity<Orders>().ToTable("tbl_Order");
            modelBuilder.Entity<OrderItems>().ToTable("tbl_OrderDetails");

            // Configure Products entity
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(p => p.ProductID);
                entity.Property(p => p.ProductID).HasColumnName("ProductID");
                entity.Property(p => p.SupplierID).HasColumnName("SupplierID");

                // Configure relationship with Supplier
                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Supplier entity
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(s => s.SupplierID);
                entity.Property(s => s.SupplierID).HasColumnName("SupplierID");
                entity.Property(s => s.SupplierName).HasColumnName("SupplierName");
                entity.Property(s => s.IsActive).HasDefaultValue(true);
            });

            // Configure Orders entity
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(o => o.OrderID);
                entity.Property(o => o.OrderID).HasColumnName("OrderID");

                // Configure relationship with OrderItems
                entity.HasMany(o => o.Items)
                    .WithOne()
                    .HasForeignKey(oi => oi.OrderID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure OrderItems entity
            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(oi => oi.OrderDetailID);
                entity.Property(oi => oi.OrderDetailID).HasColumnName("OrderDetailID");
                entity.Property(oi => oi.OrderID).HasColumnName("OrderID");
                entity.Property(oi => oi.ProductID).HasColumnName("ProductID");

                // Configure computed property for TotalPrice if needed
                entity.Property(oi => oi.TotalPrice)
                    .HasComputedColumnSql("Quantity * UnitPrice", stored: true);
            });
        }
    }
}