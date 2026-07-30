using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Categories");

            builder
                .HasKey(c => c.CategoryId)
                .HasName(name: "PK_Categories")
                .IsClustered();
        }
    }
}
