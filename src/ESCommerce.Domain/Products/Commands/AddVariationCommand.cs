using ESCommerce.Domain.Core.Model;
using ESCommerce.Domain.Products.Events;
using Marten;

namespace ESCommerce.Domain.Products.Commands
{
    public record AddVariationCommand(Guid ProductId, Variation Variation) : ICommand;

    public class AddVariationCommandHandler : ICommandHandler<AddVariationCommand>
    {
        public async Task Handle(IDocumentSession session, AddVariationCommand command)
        {
            var stream = await session.Events.FetchForWriting<Product>(command.ProductId);

            if (command.Variation.IsValid(command.Variation.Name, command.Variation.Category, command.Variation.SKU))
                stream.AppendOne(new VariationAdded(command.Variation));

            else
                stream.AppendOne(new FailedToAddVariation(FailedToAddVariation.FailReason.InvalidVariation));
        }
    }
}
