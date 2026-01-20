using ESCommerce.Domain.Boxes.Events;
using ESCommerce.Domain.Core.Model;
using Marten;

namespace ESCommerce.Domain.Boxes.Commands
{
    public record AddShippingLabelCommand(Guid BoxId, ShippingLabel Label) : ICommand;

    public class AddShippingLabelCommandHandler() : ICommandHandler<AddShippingLabelCommand>
    {
        public async Task Handle(IDocumentSession session, AddShippingLabelCommand command)
        {
            var stream = await session.Events.FetchForWriting<Box>(command.BoxId);
            var box = stream.Aggregate;

            if (command.Label.IsValid())
                stream.AppendOne(new ShippingLabelAdded(command.Label));
            else
                stream.AppendOne(new FailedToAddShippingLabel(FailedToAddShippingLabel.FailReason.InvalidShippingLabel));
        }
    }
}
