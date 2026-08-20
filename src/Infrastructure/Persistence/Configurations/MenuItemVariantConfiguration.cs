using Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class MenuItemVariantConfiguration : IEntityTypeConfiguration<MenuItemVariant>
    {
        public void Configure(EntityTypeBuilder<MenuItemVariant> builder)
        {
            builder.ToTable("MenuItemVariants");

            builder.HasKey(variant => variant.Id);

            builder.Property(variant => variant.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(variant => variant.Price)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(variant => variant.DisplayOrder)
                .IsRequired();

            builder.Property(variant => variant.IsActive)
                .IsRequired();

            builder.Property(variant => variant.IsAvailable)
                .IsRequired();

            builder.HasOne<MenuItem>()
                .WithMany()
                .HasForeignKey(variant => variant.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
