using Domain.Customers;
using Domain.Orders;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(order => order.Id);

            builder.Ignore(order => order.Subtotal);

            builder.Ignore(order => order.Total);

            builder.Ignore(order => order.ChangeAmount);

            builder.Property(order => order.Status)
                .IsRequired();

            builder.Property(order => order.DeliveryFee)
                .HasPrecision(10, 2);

            builder.Property(order => order.ChangeForAmount)
                .HasPrecision(10, 2);

            builder.Property(order => order.Notes)
                .HasMaxLength(1000);

            builder.Property(order => order.CreatedAt)
                .IsRequired();

            builder.ComplexProperty(
                order => order.DeliveryAddress,
                address =>
                {
                    address.Property(a => a.Street)
                        .HasColumnName("DeliveryStreet")
                        .HasMaxLength(200)
                        .IsRequired();

                    address.Property(a => a.Number)
                        .HasColumnName("DeliveryNumber")
                        .HasMaxLength(30)
                        .IsRequired();

                    address.Property(a => a.Complement)
                        .HasColumnName("DeliveryComplement")
                        .HasMaxLength(150);

                    address.Property(a => a.Neighborhood)
                        .HasColumnName("DeliveryNeighborhood")
                        .HasMaxLength(150)
                        .IsRequired();

                    address.Property(a => a.City)
                        .HasColumnName("DeliveryCity")
                        .HasMaxLength(150)
                        .IsRequired();

                    address.Property(a => a.State)
                        .HasColumnName("DeliveryState")
                        .HasMaxLength(2)
                        .IsRequired();

                    address.Property(a => a.PostalCode)
                        .HasColumnName("DeliveryPostalCode")
                        .HasMaxLength(10);

                    address.Property(a => a.Reference)
                        .HasColumnName("DeliveryReference")
                        .HasMaxLength(250);
                });

            builder.HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(order => order.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(order => order.Items)
                .WithOne()
                .HasForeignKey(item => item.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}