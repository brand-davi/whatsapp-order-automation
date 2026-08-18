using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Orders
{

    public class Order
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public OrderType? Type { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public List<OrderItem> Items { get; set; } = [];

        public DeliveryAddress? DeliveryAddress { get; set; }

        public decimal Subtotal => Items.Sum(item => item.TotalPrice);

        public decimal? DeliveryFee { get; set; }

        public decimal? Total => DeliveryFee.HasValue ? Subtotal + DeliveryFee.Value: null;

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ConfirmedAt { get; set; }

        public bool? NeedsChange { get; set; }
        public decimal? ChangeForAmount => 
            NeedsChange == true && 
            ChangeForAmount.HasValue && 
            Total.HasValue 
            ? ChangeForAmount.Value - Total.Value 
            : null;
    }
}