using MediatR;
using System;

namespace Dryva.Devices.Application.Commands
{
    public class DeleteDeviceCommand : IRequest<int>
    {
        public Guid Id { get; }

        public DeleteDeviceCommand( Guid id)
        {
            Id = id;
        }
    }
}
