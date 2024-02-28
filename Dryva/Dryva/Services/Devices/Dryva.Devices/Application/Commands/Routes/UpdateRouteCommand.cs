using Dryva.Devices.DTOs;
using MediatR;
using System;

namespace Dryva.Devices.Application.Commands
{
    public class UpdateRouteCommand : IRequest<RouteDTO>
    {
        public NewRouteDTO Model { get; }
        public Guid Id { get; }

        public UpdateRouteCommand(NewRouteDTO model, Guid id)
        {
            Model = model;
            Id = id;
        }
    }
}
