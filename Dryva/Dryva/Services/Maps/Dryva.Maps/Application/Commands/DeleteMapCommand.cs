using MediatR;
using System;

namespace Dryva.Maps.Application.Commands
{
    public class DeleteMapCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteMapCommand( Guid id)
        {
            Id = id;
        }
    }
}
