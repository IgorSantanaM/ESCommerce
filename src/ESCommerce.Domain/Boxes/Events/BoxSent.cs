using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Events
{
    public record BoxSent();

    public record BoxFailedToSend(BoxFailedToSend.FailReason Reason) 
    {
        public enum FailReason
        {
            BoxIsOpen = 0,
            BoxIsInvalid = 1
        }
    }
}
