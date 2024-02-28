using Dryva.Devices.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Queries
{
    public interface IRouteQueryRepository
    {
        Task<RouteDTO> GetRoute(Guid id);
        Task<IEnumerable<RouteDTO>> GetRoutes();
    }
}