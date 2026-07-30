using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Infrastructure.EntityTypeConfigurations;

namespace Sales.Infrastructure.Context
{
    public class SalesCrudAppDbContext: DbContext
    {
        public SalesCrudAppDbContext(DbContextOptions<SalesCrudAppDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
