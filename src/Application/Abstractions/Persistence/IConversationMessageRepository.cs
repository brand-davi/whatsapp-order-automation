using Domain.Conversations;

namespace Application.Abstractions.Persistence
{
    public interface IConversationMessageRepository
    {
        Task<bool> ExistsByExternalMessageIdAsync(string externalMessageId, CancellationToken cancellationToken = default);

        Task AddAsync(ConversationMessage message, CancellationToken cancellationToken = default);
    }
}
