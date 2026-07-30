using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
 
namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
                .ToTable("Order_Details");

            builder
                .HasKey(od => od.OrderId)
                .HasName(name: "PK_OrderDetails")
                .IsClustered();

            builder
                .HasMany(od => od.Products)
                .WithOne(p => p.OrderDetail)
                .HasForeignKey(p => p.ProductId)
                .IsRequired()
                .HasConstraintName("FK_Details_Products");

            builder
                .Property(od => od.Quantity)
                .IsRequired();

            builder
                .Property(od => od.TotalPrice)
                .HasColumnType("DECIMAL(10, 2)")
                .IsRequired();

        }
    }
}
