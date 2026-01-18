using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Products.Events
{
    public record ImageAdded(string ImageUrl);

    public record FailedToAddImage(FailedToAddImage.FailReason Reason)
    {
        public enum FailReason
        {
            ImageNotFound
        }
    }
}
