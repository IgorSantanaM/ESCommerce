using ESCommerce.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Events
{
    public record ProductAdded(Guid ProductId);

    public record ProductFailedToAdd(ProductFailedToAdd.FailReason Reason)
    {
        public enum FailReason
        {
            InvalidProduct
        }
    }
}
