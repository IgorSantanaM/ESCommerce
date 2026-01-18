using ESCommerce.Domain.Core.Model;
using ESCommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes
{
    public class Box : Entity<Guid>, IAggregateRoot
    {
        public int Capacity { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ShippingLabel? ShippingLabel { get; set; }
        public bool IsClosed { get; set; }
        public bool IsSent { get; set; }
    }
}
