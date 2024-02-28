using Dryva.Devices.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Queries
{
    public interface IDeviceQueryRepository
    {
        Task<DetailsDTO> GetDevice(Guid id);
        Task<DetailsDTO> GetDevice(int terminal);
        Task<IEnumerable<DetailsDTO>> GetDevices();
        Task<IEnumerable<DetailsDTO>> GetDevices(Guid routeId);
        Task<IEnumerable<DeviceTrailDTO>> GetDeviceTrails(int terminal);
        Task<IEnumerable<TransitLogDetailsDTO>> GetTransitLogsByCsn(int csn);
        Task<IEnumerable<TransitLogDetailsDTO>> GetTransitLogsByCsnAndTime(int csn, DateTime? from = null, DateTime? to = null);
    }
}