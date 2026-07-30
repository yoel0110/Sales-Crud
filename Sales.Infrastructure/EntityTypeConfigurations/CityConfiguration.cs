using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .ToTable("Cities");

            builder
                .HasKey(c => c.CityId)
                .HasName("PK_Cities")
                .IsClustered();

        }
    }
}
