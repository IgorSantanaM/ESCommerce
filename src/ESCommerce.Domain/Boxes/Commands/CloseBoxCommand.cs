using ESCommerce.Domain.Boxes.Events;
using ESCommerce.Domain.Core.Model;
using Marten;

namespace ESCommerce.Domain.Boxes.Commands
{
    public record CloseBoxCommand(Guid BoxId) : ICommand;

    public class CloseBoxCommandHandler() : ICommandHandler<CloseBoxCommand>
    {
        public async Task Handle(IDocumentSession session, CloseBoxCommand command)
        {
            var stream = await session.Events.FetchForWriting<Box>(command.BoxId);

            var box = stream.Aggregate;

            if (box!.ProductIds.Any())
                stream.AppendOne(new BoxClosed());

            else if (box!.IsSent)
                stream.AppendOne(new BoxFailedToClose(BoxFailedToClose.FailReason.BoxAlreadySent));
            else
                stream.AppendOne(new BoxFailedToClose(BoxFailedToClose.FailReason.BoxIsEmpty));
        }
    }
}
