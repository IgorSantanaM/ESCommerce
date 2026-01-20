using ESCommerce.Domain.Boxes.Events;
using ESCommerce.Domain.Core.Model;
using Marten;
using NetTopologySuite.Operation.Buffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Boxes.Commands
{
    public record CreateBoxCommand(Guid BoxId, int DesiredNumberOfSpots) : ICommand;

    public class CreateBoxCommandHandler() : ICommandHandler<CreateBoxCommand>
    {
        public async Task Handle(IDocumentSession session, CreateBoxCommand command)
        {
            var stream = await session.Events.FetchForWriting<Box>(command.BoxId);

            stream.AppendOne(new BoxCreated(command.DesiredNumberOfSpots));
        }
    }
}
