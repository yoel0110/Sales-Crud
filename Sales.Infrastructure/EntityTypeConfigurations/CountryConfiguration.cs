using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .ToTable("Countries");

            builder
                .HasKey(c => c.CountryId)
                .HasName("PK_Countries")
                .IsClustered();
 
        }
    }
}
