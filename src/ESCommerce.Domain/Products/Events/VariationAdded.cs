using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Products.Events
{
    public record VariationAdded(Variation Variation);

    public record FailedToAddVariation(FailedToAddVariation.FailReason Reason)
    {
        public enum FailReason
        {
            InvalidVariation
        }
    }
}