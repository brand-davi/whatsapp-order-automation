using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Catalog
{
    public class MenuItemVariant
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsAvailable { get; set; }
    }
}
