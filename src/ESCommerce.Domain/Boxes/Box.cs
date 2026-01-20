using ESCommerce.Domain.Boxes.Events;
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
        public ICollection<int> ProductIds{ get; set; } = new List<int>();
        public ShippingLabel? ShippingLabel { get; set; }
        public bool IsClosed { get; set; }
        public bool IsSent { get; set; }

        public void Apply(BoxCreated boxCreated)
        {
            Capacity = boxCreated.DesiredNumberOfSpots;
        }
            
        public void Apply(ShippingLabelAdded shippingLabelAdded)
        {
            ShippingLabel = shippingLabelAdded.ShippingLabel;
        }

        public void Apply(ProductAdded productAdded)
        {
            ProductIds.Add(productAdded.ProductId);
        }

        public void Apply(BoxClosed boxClosed)
        {
            IsClosed = true;
        }
        public void Apply(BoxSent boxSent)
        {
            IsSent = true;  
        }
    }
}
