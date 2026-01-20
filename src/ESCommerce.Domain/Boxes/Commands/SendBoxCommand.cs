using ESCommerce.Domain.Boxes.Events;
using ESCommerce.Domain.Core.Model;
using Marten;

namespace ESCommerce.Domain.Boxes.Commands
{
    public record SendBoxCommand(Guid BoxId) : ICommand;

    public class SendBoxCommandHandler() : ICommandHandler<SendBoxCommand>
    {
        public async Task Handle(IDocumentSession session, SendBoxCommand command)
        {
            var stream = await session.Events.FetchForWriting<Box>(command.BoxId);
            var box = stream.Aggregate;

            if (box!.IsClosed)
                stream.AppendOne(new BoxSent());
            else
                stream.AppendOne(new BoxFailedToSend(BoxFailedToSend.FailReason.BoxIsOpen));
        }
    }
}
