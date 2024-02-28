using Dryva.Devices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Application.Queries
{
    public class GetRouteByIdQuery : IRequest<RouteDTO>
    {
        public Guid Id { get;  }
        public GetRouteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
