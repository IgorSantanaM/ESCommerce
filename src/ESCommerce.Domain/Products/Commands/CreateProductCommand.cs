using ESCommerce.Domain.Core.Model;
using ESCommerce.Domain.Products.Events;
using Marten;

namespace ESCommerce.Domain.Products.Commands
{
    public record CreateProductCommand(Guid ProductId, string ProductName) : ICommand;

    public class CreateProductCommandHandler() : ICommandHandler<CreateProductCommand>
    {
        public async Task Handle(IDocumentSession session, CreateProductCommand command)
        {
            var stream = await session.Events.FetchForWriting<Product>(command.ProductId);

            stream.AppendOne(new ProductCreated(command.ProductName));
        }
    }
}
