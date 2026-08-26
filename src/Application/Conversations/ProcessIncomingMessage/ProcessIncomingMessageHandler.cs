using Application.Abstractions.Persistence;
using Domain.Conversations;
using Domain.Customers;

namespace Application.Conversations.ProcessIncomingMessage
{
    public class ProcessIncomingMessageHandler
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IConversationMessageRepository _conversationMessageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessIncomingMessageHandler(
            IRestaurantRepository restaurantRepository,
            ICustomerRepository customerRepository,
            IConversationRepository conversationRepository,
            IConversationMessageRepository conversationMessageRepository,
            IUnitOfWork unitOfWork)
        {
            _restaurantRepository = restaurantRepository;
            _customerRepository = customerRepository;
            _conversationRepository = conversationRepository;
            _conversationMessageRepository = conversationMessageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(ProcessIncomingMessageCommand command, CancellationToken cancellationToken = default)
        {
            var messageAlreadyExists = await _conversationMessageRepository.ExistsByExternalMessageIdAsync
                (command.ExternalMessageId, cancellationToken);

            if (messageAlreadyExists)
            {
                // Message already processed 
                return;
            }

            var restaurant = await _restaurantRepository.GetByWhatsAppNumberAsync(command.RestaurantWhatsAppNumber, cancellationToken);

            if (restaurant is null)
            {
                throw new InvalidOperationException("Restaurant not found for the informed WhatsApp number.");
            }

            if (!restaurant.IsActive)
            {
                return;
            }

            var customer = await _customerRepository.GetByRestaurantAndWhatsAppNumberAsync
                (restaurant.Id, command.CustomerWhatsAppNumber, cancellationToken);

            if (customer is null)
            {
                customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    RestaurantId = restaurant.Id,
                    WhatsAppNumber = command.CustomerWhatsAppNumber,
                    IsActive = true,
                    CreatedAt = command.ReceivedAt
                };

                await _customerRepository.AddAsync(customer, cancellationToken);

            }
            if (!customer.IsActive)
            {
                return;
            }

            var conversation = await _conversationRepository.GetLatestByRestaurantAndCustomerAsync
                (restaurant.Id, customer.Id, cancellationToken);

            if (conversation is null || conversation.State is ConversationState.Completed or ConversationState.Cancelled)
            {
                conversation = new Conversation
                {
                    Id = Guid.NewGuid(),
                    RestaurantId = restaurant.Id,
                    CustomerId = customer.Id,
                    CurrentOrderId = null,
                    State = ConversationState.Started,
                    CreatedAt = command.ReceivedAt,
                    LastInteractionAt = command.ReceivedAt
                };

                await _conversationRepository.AddAsync(conversation, cancellationToken);
            }
            else
            {
                conversation.LastInteractionAt = command.ReceivedAt;
            }

            var message = new ConversationMessage
            {
                Id = Guid.NewGuid(),
                ConversationId = conversation.Id,
                ExternalMessageId = command.ExternalMessageId,
                Direction = MessageDirection.Inbound,
                Type = command.MessageType,
                Content = command.Content,
                CreatedAt = command.ReceivedAt
            };

            await _conversationMessageRepository.AddAsync(message, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
