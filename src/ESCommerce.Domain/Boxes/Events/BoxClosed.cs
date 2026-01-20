using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Events
{
    public record BoxClosed();

    public record BoxFailedToClose(BoxFailedToClose.FailReason Reason)
    {
        public enum FailReason
        {
            BoxAlreadySent = 0,
            BoxIsNotValid = 1
        }
    }
}
