using Domain.Orders;
using Domain.Printing;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class PrintJobConfiguration
        : IEntityTypeConfiguration<PrintJob>
    {
        public void Configure(EntityTypeBuilder<PrintJob> builder)
        {
            builder.ToTable("PrintJobs");

            builder.HasKey(printJob => printJob.Id);

            builder.Property(printJob => printJob.Status)
                .IsRequired();

            builder.Property(printJob => printJob.AttemptCount)
                .IsRequired();

            builder.Property(printJob => printJob.CreatedAt)
                .IsRequired();

            builder.Property(printJob => printJob.LastError)
                .HasMaxLength(2000);

            builder.HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(printJob => printJob.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Order>()
                .WithMany()
                .HasForeignKey(printJob => printJob.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}