using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Orders
{
    public class DeliveryAddress
    {
        public string street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string? Complement { get; set; } 
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public string? Reference { get; set; }
    }
}
