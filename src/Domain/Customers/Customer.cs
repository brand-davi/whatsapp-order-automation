using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public string WhatsAppNumber { get; set; } = string.Empty;
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
