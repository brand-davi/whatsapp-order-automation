using Domain.Catalog;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class MenuCategoryConfiguration : IEntityTypeConfiguration<MenuCategory>
    {
        public void Configure(EntityTypeBuilder<MenuCategory> builder)
        {
            builder.ToTable("MenuCategories");

            builder.HasKey(category => category.Id);

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(category => category.DisplayOrder)
                .IsRequired();

            builder.Property(category => category.IsActive) 
                .IsRequired();

            builder.HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(category => category.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
