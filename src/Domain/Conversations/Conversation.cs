using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conversations
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? CurrentOrderId { get; set; }
        public ConversationState State { get; set; } = ConversationState.Started;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastInteractionAt { get; set; }
    }
}
