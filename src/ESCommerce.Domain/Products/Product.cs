using ESCommerce.Domain.Core.Model;
using ESCommerce.Domain.Products.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Products
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<Variation> Variantions { get; set; } = new List<Variation>();

        public void Apply(ProductCreated productCreated)
        {
            Name = productCreated.Name;
        }

        public void Apply(ImageAdded imageAdded)
        {
            ImageUrl = imageAdded.ImageUrl;
        }

        public void Apply(VariationAdded variationAdded)
        {
            Variantions.Add(variationAdded.Variation);
        }

        public bool IsValid(string name)
        {
            if(string.IsNullOrEmpty(Name)) return false;
            return true;
        }
    }
}
