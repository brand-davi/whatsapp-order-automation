using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace Domain.Conversations
{
    public class ConversationMessage
    {
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public string? ExternalMessageId { get; set; }
        public MessageDirection Direction { get; set; }
        public MessageType Type { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
