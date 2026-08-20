using Domain.Customers;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(customer =>  customer.Id);

            builder.Property(customer => customer.WhatsAppNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(customer => customer.Name).HasMaxLength(150);

            builder.Property(customer => customer.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(customer => customer.CreatedAt).IsRequired();

            builder.HasIndex(customer => new
            {
                customer.RestaurantId,
                customer.WhatsAppNumber
            }).IsUnique();

            builder.HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(customer => customer.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
