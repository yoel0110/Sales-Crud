using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.EntityTypeConfigurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("Customers");

            builder
                .HasKey(cust => cust.CustomerId)
                .HasName("PK_Customers")
                .IsClustered();

            builder
                .HasOne(cust => cust.Country)
                .WithMany(coun => coun.Customers)
                .HasForeignKey(cu => cu.CountryId)
                .IsRequired()
                .HasConstraintName("FK_Customers_Countries");

            builder
                .HasOne(cust => cust.City)
                .WithMany(ct => ct.Customers)
                .HasForeignKey(cust => cust.CityId)
                .IsRequired()
                .HasConstraintName("FK_Customers_Cities");
        }
    }
}
