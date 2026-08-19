using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Conversations
{
    public enum ConversationState
    {
        Started = 1,
        CollectingOrder = 2,
        AwaitingConfirmation = 3,
        Completed = 4,
        Canceled = 5
    }
}
