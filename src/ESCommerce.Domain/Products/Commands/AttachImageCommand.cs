using ESCommerce.Domain.Core.Model;
using ESCommerce.Domain.Products.Events;
using Marten;

namespace ESCommerce.Domain.Products.Commands
{
    public record AttachImageCommand(Guid ProductId, string ImageUrl) : ICommand;

    public class AttachImageCommandHandler() : ICommandHandler<AttachImageCommand>
    {
        public async Task Handle(IDocumentSession session, AttachImageCommand command)
        {
            var stream = await session.Events.FetchForWriting<Product>(command.ProductId);
            var product = stream.Aggregate;

            stream.AppendOne(new ImageAdded(command.ImageUrl));
        }
    }
}
