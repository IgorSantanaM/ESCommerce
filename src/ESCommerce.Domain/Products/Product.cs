using ESCommerce.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Products
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<Variantion> Variantions { get; set; } = new List<Variantion>();
    }
}
