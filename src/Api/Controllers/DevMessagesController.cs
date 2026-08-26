using Application.Conversations.ProcessIncomingMessage;
using Domain.Conversations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/dev/messages")]
    public class DevMessagesController : ControllerBase
    {
        private readonly ProcessIncomingMessageHandler _handler;

        public DevMessagesController(
            ProcessIncomingMessageHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            DevIncomingMessageRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ProcessIncomingMessageCommand
            {
                RestaurantWhatsAppNumber = request.RestaurantWhatsAppNumber,
                CustomerWhatsAppNumber = request.CustomerWhatsAppNumber,
                ExternalMessageId = request.ExternalMessageId,
                MessageType = request.MessageType,
                Content = request.Content,
                ReceivedAt = DateTime.UtcNow
            };

            await _handler.HandleAsync(
                command,
                cancellationToken);

            return NoContent();
        }
    }

    public class DevIncomingMessageRequest
    {
        public string RestaurantWhatsAppNumber { get; set; }
            = string.Empty;

        public string CustomerWhatsAppNumber { get; set; }
            = string.Empty;

        public string ExternalMessageId { get; set; }
            = string.Empty;

        public MessageType MessageType { get; set; }

        public string? Content { get; set; }
    }
}