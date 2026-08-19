using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Restaurants
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string WhatsAppNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
