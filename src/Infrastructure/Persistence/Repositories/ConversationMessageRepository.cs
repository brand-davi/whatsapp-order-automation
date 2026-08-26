using Application.Abstractions.Persistence;
using Domain.Conversations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ConversationMessageRepository
        : IConversationMessageRepository
    {
        private readonly AppDbContext _dbContext;

        public ConversationMessageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsByExternalMessageIdAsync(string externalMessageId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.ConversationMessages
                .AnyAsync(message => message.ExternalMessageId == externalMessageId, cancellationToken);
        }

        public async Task AddAsync(ConversationMessage message, CancellationToken cancellationToken = default)
        {
            await _dbContext.ConversationMessages.AddAsync(message, cancellationToken);
        }
    }
}