using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable("Products");

            builder
                .HasKey(p => p.ProductId)
                .HasName(name: "PK_Products")
                .IsClustered();

            builder
                .Property(p => p.ProductName)
                .HasMaxLength(150)
                .IsUnicode(unicode: false)
                .IsRequired();

            builder
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId)
                 .HasConstraintName("FK_Products_Categories");

            builder
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(10, 2")
                .IsRequired();

            builder
                .Property(p => p.Stock)
                .IsRequired();
        }
    }
}
