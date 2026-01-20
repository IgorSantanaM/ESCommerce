using ESCommerce.Domain.Core.Model;
using Marten;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain
{
    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        public Task Handle(IDocumentSession session, TCommand command);
    }
}
