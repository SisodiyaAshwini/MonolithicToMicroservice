using BookStore.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.ProductService.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {  }

        public ProductContext()
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
