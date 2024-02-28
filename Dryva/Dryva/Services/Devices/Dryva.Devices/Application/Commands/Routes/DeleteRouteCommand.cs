using MediatR;
using System;

namespace Dryva.Devices.Application.Commands
{
    public class DeleteRouteCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteRouteCommand( Guid id)
        {
            Id = id;
        }
    }
}
