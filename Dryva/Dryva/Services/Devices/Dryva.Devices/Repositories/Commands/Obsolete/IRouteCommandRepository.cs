using Dryva.Devices.DTOs;
using System;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Commands
{
    public interface IRouteCommandRepository
    {
        Task<int> Delete(Guid id);
        Task<int> Insert(RouteDTO routeDTO);
        Task<int> Update(RouteDTO routeDTO);
    }
}