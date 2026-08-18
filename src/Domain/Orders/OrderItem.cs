using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Orders
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuItemId { get; set; }
        public Guid MenuItemVariantId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string VariantName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public string? Notes { get; set; }
    }
}
