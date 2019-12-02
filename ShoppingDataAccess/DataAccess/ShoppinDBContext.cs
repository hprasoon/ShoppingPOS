using Microsoft.EntityFrameworkCore;
using ShoppingDataAccess.Models;

namespace ShoppingDataAccess.DataAccess
{
    public class ShoppinDBContext : DbContext
    {
        public ShoppinDBContext(DbContextOptions<ShoppinDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Inventory>().ToTable("Inventory");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}