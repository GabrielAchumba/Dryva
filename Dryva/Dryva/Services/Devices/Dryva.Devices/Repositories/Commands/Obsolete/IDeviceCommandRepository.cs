using Dryva.Devices.DTOs;
using System;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Commands
{
    public interface IDeviceCommandRepository
    {
        Task<int> Delete(Guid id);
        Task<int> Insert(DeviceDTO deviceDTO);
        Task<int> Insert(DeviceTrailDTO deviceTrailDTO);
        Task<int> Insert(EntryTransitLogDTO transitLogDTO);
        Task<int> Insert(ExitTransitLogDTO transitLogDTO);
        Task<int> Update(DeviceDTO deviceDTO);
        Task<int> UpdateDeviceRoute(RouteDTO dto);
    }
}