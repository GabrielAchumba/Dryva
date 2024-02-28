using AutoMapper;
using Dapper;
using Dryva.Devices.DTOs;
using Dryva.Devices.Helpers;
using Dryva.Devices.Models;
using Dryva.Devices.Repositories.Commands;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.Repositories.Queries
{
    public class DeviceQueryRepository : IDeviceQueryRepository
    {
        private readonly string connectionString;
        private readonly DevicesDbContext context;
        private readonly IMapper mapper;
        public DeviceQueryRepository(DevicesDbContext context, IMapper mapper)
        {
            connectionString = Startup.ConnectionString;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DetailsDTO>> GetDevices()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DetailsDTO>(d => new
                {
                    d.Id,
                    d.Course,
                    d.EW,
                    d.Latitude,
                    d.Longitude,
                    d.ModifiedOn,
                    d.NS,
                    d.SerialNumber,
                    d.Speed,
                    d.Terminal,
                    d.RouteId,
                    d.Source,
                    d.Destination
                });
                var model = await connection.QueryAsync<DetailsDTO>(builder.Query);
                return model;
            }
        }

        public async Task<IEnumerable<DetailsDTO>> GetDevices(Guid routeId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DetailsDTO>(d => new
                {
                    d.Id,
                    d.Course,
                    d.EW,
                    d.Latitude,
                    d.Longitude,
                    d.ModifiedOn,
                    d.NS,
                    d.SerialNumber,
                    d.Speed,
                    d.Terminal,
                    d.RouteId,
                    d.Source,
                    d.Destination
                }).Where(p => p.RouteId == routeId);
                var model = await connection.QueryAsync<DetailsDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        public async Task<DetailsDTO> GetDevice(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DetailsDTO>(d => new
                {
                    d.Id,
                    d.Course,
                    d.EW,
                    d.Latitude,
                    d.Longitude,
                    d.ModifiedOn,
                    d.NS,
                    d.SerialNumber,
                    d.Speed,
                    d.Terminal,
                    d.RouteId,
                    d.Source,
                    d.Destination
                }).Where(d => d.Id == id);
                var model = await connection.QueryFirstOrDefaultAsync<DetailsDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        public async Task<DetailsDTO> GetDevice(int terminal)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DetailsDTO>(d => new
                {
                    d.Id,
                    d.Course,
                    d.EW,
                    d.Latitude,
                    d.Longitude,
                    d.ModifiedOn,
                    d.NS,
                    d.SerialNumber,
                    d.Speed,
                    d.Terminal,
                    d.RouteId,
                    d.Source,
                    d.Destination
                }).Where(d => d.Terminal == terminal);
                var model = await connection.QueryFirstOrDefaultAsync<DetailsDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        public async Task<IEnumerable<DeviceTrailDTO>> GetDeviceTrails(int terminal)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<DeviceTrail, DeviceTrailDTO>(d => new
                {
                    d.Course,
                    d.DeviceId,
                    d.EW,
                    d.GpsModifiedOn,
                    d.Latitude,
                    d.Longitude,
                    d.NS,
                    d.Speed,
                    d.Terminal
                }).Where(d => d.Terminal == terminal);
                var model = await connection.QueryAsync<DeviceTrailDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        public async Task<IEnumerable<TransitLogDetailsDTO>> GetTransitLogsByCsn(int csn)
        {
            return await GetTransitLogsByCsnAndTime(csn, null, null);
        }

        public async Task<IEnumerable<TransitLogDetailsDTO>> GetTransitLogsByCsnAndTime(int csn,
            DateTime? from = null, DateTime? to = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var entryBuilder = context.Select<EntryTransitLog, TransitLogDTO>(d => new
                {
                    d.Csn,
                    d.EW,
                    d.Latitude,
                    d.LogId,
                    d.Longitude,
                    d.NS,
                    d.Terminal,
                    d.Time
                }).Where(d => d.Csn == csn);
                var exitBuilder = context.Select<EntryTransitLog, TransitLogDTO>(d => new
                {
                    d.Csn,
                    d.EW,
                    d.Latitude,
                    d.LogId,
                    d.Longitude,
                    d.NS,
                    d.Terminal,
                    d.Time
                }).Where(d => d.Csn == csn);

                if (from != null)
                    entryBuilder = entryBuilder.Where(d => d.Time >= from);

                if (to != null)
                    entryBuilder = entryBuilder.Where(d => d.Time <= to);

                if (from != null)
                    exitBuilder = exitBuilder.Where(d => d.Time >= from);

                if (to != null)
                    exitBuilder = exitBuilder.Where(d => d.Time <= to);

                var entryLogs = await connection.QueryAsync<TransitLogDTO>(entryBuilder.Query, (object)entryBuilder.Parameters);
                var exitLogs = await connection.QueryAsync<TransitLogDTO>(exitBuilder.Query, (object)exitBuilder.Parameters);
                var logs = entryLogs.LeftOuterJoin(exitLogs, nl => nl.LogId, xl => xl.LogId, (nl, xl) =>
                {
                    return new TransitLogDetailsDTO
                    {
                        Csn = csn,
                        Terminal = nl.Terminal,
                        LogId = nl.LogId,
                        Entry = mapper.Map<TransitLogDTO, GPSInfo>(nl),
                        Exit = mapper.Map<TransitLogDTO, GPSInfo>(xl)
                    };
                });

                return logs;
            }
        }
    }
}
