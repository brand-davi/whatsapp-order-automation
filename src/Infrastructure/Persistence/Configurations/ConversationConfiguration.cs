using Domain.Conversations;
using Domain.Customers;
using Domain.Orders;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ConversationConfiguration
        : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversations");

            builder.HasKey(conversation => conversation.Id);

            builder.Property(conversation => conversation.State)
                .IsRequired();

            builder.Property(conversation => conversation.CreatedAt)
                .IsRequired();

            builder.Property(conversation => conversation.LastInteractionAt)
                .IsRequired();

            builder.HasOne<Restaurant>()
                .WithMany()
                .HasForeignKey(conversation => conversation.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(conversation => conversation.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Order>()
                .WithOne()
                .HasForeignKey<Conversation>(
                    conversation => conversation.CurrentOrderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}