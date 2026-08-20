using Domain.Catalog;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems");

            builder.HasKey(item => item.Id);

            builder.Property(item=> item.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(item=> item.Description)
                .HasMaxLength(500);

            builder.Property(item => item.IsActive)
                .IsRequired();

            builder.Property(item => item.IsAvailable)
                .IsRequired();

            builder.HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(item => item.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<MenuCategory>()
                .WithMany()
                .HasForeignKey(item => item.MenuCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
