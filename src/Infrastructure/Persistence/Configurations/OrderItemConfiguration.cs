using Domain.Catalog;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration
        : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.ItemName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(item => item.VariantName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(item => item.UnitPrice)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(item => item.Quantity)
                .IsRequired();

            builder.Property(item => item.Notes)
                .HasMaxLength(500);

            builder.Ignore(item => item.TotalPrice);

            builder.HasOne<MenuItem>()
                .WithMany()
                .HasForeignKey(item => item.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<MenuItemVariant>()
                .WithMany()
                .HasForeignKey(item => item.MenuItemVariantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}