namespace Domain.Conversations
{
    public enum ConversationState
    {
        Started = 1,
        CollectingOrder = 2,
        AwaitingConfirmation = 3,
        Completed = 4,
        Cancelled = 5
    }
}
