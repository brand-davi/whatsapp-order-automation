using Domain.Conversations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ConversationMessageConfiguration
        : IEntityTypeConfiguration<ConversationMessage>
    {
        public void Configure(EntityTypeBuilder<ConversationMessage> builder)
        {
            builder.ToTable("ConversationMessages");

            builder.HasKey(message => message.Id);

            builder.Property(message => message.ExternalMessageId)
                .HasMaxLength(255);

            builder.Property(message => message.Direction)
                .IsRequired();

            builder.Property(message => message.Type)
                .IsRequired();

            builder.Property(message => message.Content);

            builder.Property(message => message.CreatedAt)
                .IsRequired();

            builder.HasIndex(message => message.ExternalMessageId)
                .IsUnique();

            builder.HasOne<Conversation>()
                .WithMany()
                .HasForeignKey(message => message.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}