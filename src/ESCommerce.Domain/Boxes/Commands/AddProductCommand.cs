using ESCommerce.Domain.Boxes.Events;
using ESCommerce.Domain.Core.Model;
using ESCommerce.Domain.Products;
using Marten;

namespace ESCommerce.Domain.Boxes.Commands
{
    public record AddProductCommand(Guid BoxId, Guid ProductId) : ICommand;

    public class AddProductCommandHandler() : ICommandHandler<AddProductCommand>
    {
        public async Task Handle(IDocumentSession session, AddProductCommand command)
        {
            var stream = await session.Events.FetchForWriting<Box>(command.BoxId);

            stream.AppendOne(new ProductAdded(command.ProductId));
        }
    }
}
