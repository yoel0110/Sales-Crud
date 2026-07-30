
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class OrderConfiguration: IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Orders");

            builder
                .HasKey(o => o.OrderId)
                .HasName("PK_Orders")
                .IsClustered();

            builder
                .HasOne(o => o.Customer)
                .WithMany(cust => cust.Orders)
                .HasForeignKey(o => o.CustomerId)
                .IsRequired()
                .HasConstraintName("FK_Orders_Customers");

            builder
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(o => o.OrderId)
                .IsRequired()
                .HasConstraintName("FK_Orders_Customers");

        }
    }
}
