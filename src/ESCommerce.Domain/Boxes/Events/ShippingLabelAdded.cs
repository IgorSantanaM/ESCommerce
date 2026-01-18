using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Events
{
    public record ShippingLabelAddedO(ShippingLabel ShippingLabel);

    public record FailedToAddShippingLabel(FailedToAddShippingLabel.FailReason Reason)
    {
        public enum FailReason
        {
            InvalidShippingLabel
        }
    }
}
