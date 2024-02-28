using AutoMapper;
using Dapper;
using Dryva.Security.DTOs;
using Dryva.Security.Models;
using Dryva.Security.Repositories.Commands;
using Dryva.Utitlties.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Repositories.Queries
{
    public class DeviceQueryRepository : IDeviceQueryRepository
    {
        private readonly string connectionString;
        private readonly SecurityDbContext context;
        private readonly IMapper mapper;
        public DeviceQueryRepository(SecurityDbContext context, IMapper mapper)
        {
            connectionString = Startup.ConnectionString;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<DeviceAccountDTO> GetDevice(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DeviceAccountDTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.SerialNumber,
                    d.Terminal,
                    d.CompanyName
                }).Where(p => p.Id == id);
                var model = await connection.QueryFirstOrDefaultAsync<DeviceAccountDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        public async Task<DeviceAccountDTO> GetDevice(int terminal)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DeviceAccountDTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.SerialNumber,
                    d.Terminal,
                    d.CompanyName
                }).Where(d => d.Terminal == terminal);
                var model = await connection.QueryFirstOrDefaultAsync<DeviceAccountDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }

        public async Task<DeviceAccountDTO> GetDevice(string serialNumber)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Device, DeviceAccountDTO>(d => new
                {
                    d.Id,
                    d.Name,
                    d.SerialNumber,
                    d.Terminal,
                    d.CompanyName
                }).Where(d => d.SerialNumber == serialNumber);
                var model = await connection.QueryFirstOrDefaultAsync<DeviceAccountDTO>(builder.Query, (object)builder.Parameters);
                return model;
            }
        }
    }
}
