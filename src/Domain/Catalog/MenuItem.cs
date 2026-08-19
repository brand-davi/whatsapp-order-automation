using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Catalog
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid MenuCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsAvailable { get; set; } = true;
    }
}
