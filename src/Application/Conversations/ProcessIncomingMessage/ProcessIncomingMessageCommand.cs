using Domain.Conversations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Conversations.ProcessIncomingMessage
{
    public class ProcessIncomingMessageCommand
    {
        public string RestaurantWhatsAppNumber { get; set; } = string.Empty;

        public string CustomerWhatsAppNumber { get; set; } = string.Empty;

        public string ExternalMessageId { get; set; } = string.Empty;

        public MessageType MessageType { get; set; }

        public string? Content { get; set; }
        
        public DateTime ReceivedAt { get; set; }
    }
}
