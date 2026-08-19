using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Printing
{
    public class PrintJob
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid OrderId { get; set; }
        public PrintJobStatus Status { get; set; }
        public int AttemptCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PrintedAt { get; set; }
        public string? LastError { get; set; }
    }
}
