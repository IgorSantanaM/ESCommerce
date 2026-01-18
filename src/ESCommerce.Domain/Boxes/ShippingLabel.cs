using ESCommerce.Domain.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace ESCommerce.Domain.Boxes
{
    public record ShippingLabel(Carrier Carrier, string TrackingCode)
    {
        public bool IsValid() =>
            Carrier switch
            {
                Carrier.UPS => TrackingCode.StartsWith("ABC"),
                Carrier.FedEx => TrackingCode.StartsWith("DEF"),
                Carrier.BPost => TrackingCode.StartsWith("GHI"),
                _ => throw new DomainException("Tracking code doesn't exist."),
            };
    }
}