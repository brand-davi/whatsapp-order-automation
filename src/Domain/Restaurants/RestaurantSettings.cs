using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Restaurants
{
    public class RestaurantSettings
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public bool AutomationEnabled { get; set; } = false;
    }
}
