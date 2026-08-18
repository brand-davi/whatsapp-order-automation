using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Orders
{
    public enum OrderStatus
    {
        Draft = 1,
        AwaitingConfirmation = 2,
        Confirmed = 3,
        Cancelled = 4,
        Completed = 5
    }
}
