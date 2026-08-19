using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Catalog
{
    public class MenuCategory
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
