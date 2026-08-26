using Domain.Conversations;

namespace Application.Abstractions.Persistence
{
    public interface IConversationRepository
    {
        Task<Conversation?> GetLatestByRestaurantAndCustomerAsync(
            Guid restaurantId, Guid customerId, CancellationToken cancellationToken = default);

        Task AddAsync(Conversation conversation, CancellationToken cancellationToken = default);
    }
}
