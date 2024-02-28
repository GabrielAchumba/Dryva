using Dryva.Devices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Queries
{
    public class GetDeviceByRouteIdQuery : IRequest<DetailsDTO>
    {
        public Guid RouteId { get;  }
        public GetDeviceByRouteIdQuery(Guid routeId)
        {
            RouteId = routeId;
        }
    }
}
