using Dryva.Devices.DTOs;
using MediatR;

namespace Dryva.Devices.Application.Commands
{
    public class InsertRouteCommand : IRequest<RouteDTO>
    {
        public NewRouteDTO Model { get; }

        public InsertRouteCommand(NewRouteDTO model)
        {
            Model = model;
        }
    }
}
