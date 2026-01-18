using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Events
{
    public record BoxCreated(int DesiredNumberOfSpots);

    public record BoxFailedToCreate(BoxFailedToCreate.FailReason Reason)
    {
        public enum FailReason
        {
            InvalidCapacity
        }
    }
}
