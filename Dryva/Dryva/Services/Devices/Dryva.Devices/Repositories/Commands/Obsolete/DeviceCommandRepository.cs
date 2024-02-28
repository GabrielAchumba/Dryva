using AutoMapper;
using Dapper;
using Dryva.Devices.DTOs;
using Dryva.Devices.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Commands
{
    public class DeviceCommandRepository : IDeviceCommandRepository
    {
        private readonly DevicesDbContext context;
        private readonly IMapper mapper;

        public DeviceCommandRepository(DevicesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Insert(DeviceDTO deviceDTO)
        {
            var device = mapper.Map<DeviceDTO, Device>(deviceDTO);
            device.CreatedOn = DateTime.Now;

            context.Devices.Add(device);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Insert(DeviceTrailDTO deviceTrailDTO)
        {
            var trail = mapper.Map<DeviceTrailDTO, DeviceTrail>(deviceTrailDTO);
            var device = new Device { Id = deviceTrailDTO.DeviceId ?? Guid.Empty };

            context.DeviceTrails.Add(trail);
            context.Attach(device);
            mapper.Map(deviceTrailDTO, device);

            return await context.SaveChangesAsync();
        }

        public async Task<int> Insert(EntryTransitLogDTO transitLogDTO)
        {
            var transitLog = mapper.Map<EntryTransitLogDTO, EntryTransitLog>(transitLogDTO);

            context.EntryTransitLogs.Add(transitLog);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Insert(ExitTransitLogDTO transitLogDTO)
        {
            var transitLog = mapper.Map<ExitTransitLogDTO, ExitTransitLog>(transitLogDTO);

            context.ExitTransitLogs.Add(transitLog);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(DeviceDTO deviceDTO)
        {
            var device = new Device();
            device.Id = deviceDTO.Id;

            context.Attach(device);
            mapper.Map(deviceDTO, device);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateDeviceRoute(RouteDTO dto)
        {
            using (var connection = new SqlConnection(Startup.ConnectionString))
            {
                await connection.OpenAsync();
                string cmd = $"Update Devices Set [Source]=@Source," +
                    $"[Destination]=@Destination Where [RouteId]=@Id";
               
                var result = await connection.ExecuteAsync(cmd, dto);
                return result;
            }
        }
        public async Task<int> Delete(Guid id)
        {
            var device = new Device { Id = id };

            context.Attach(device);
            context.Devices.Remove(device);
            return await context.SaveChangesAsync();
        }

    }
}
