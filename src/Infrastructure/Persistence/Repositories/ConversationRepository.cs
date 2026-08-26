using Application.Abstractions.Persistence;
using Domain.Conversations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AppDbContext _dbContext;

        public ConversationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Conversation?> GetLatestByRestaurantAndCustomerAsync(
            Guid restaurantId,
            Guid customerId,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Conversations
                .Where(conversation =>
                    conversation.RestaurantId == restaurantId &&
                    conversation.CustomerId == customerId)
                .OrderByDescending(
                    conversation => conversation.LastInteractionAt)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(
            Conversation conversation,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Conversations.AddAsync(
                conversation,
                cancellationToken);
        }
    }
}