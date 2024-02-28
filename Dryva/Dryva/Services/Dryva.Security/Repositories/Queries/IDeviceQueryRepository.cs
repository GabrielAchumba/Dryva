using Dryva.Security.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Repositories.Queries
{
    public interface IDeviceQueryRepository
    {
        Task<DeviceAccountDTO> GetDevice(Guid id);
        Task<DeviceAccountDTO> GetDevice(int terminal);
        Task<DeviceAccountDTO> GetDevice(string serialNumber);
    }
}
