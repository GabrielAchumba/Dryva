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
    public class RouteQueryRepository : IRouteQueryRepository
    {
        private readonly string connectionString;
        private readonly DevicesDbContext context;
        private readonly IMapper mapper;
        public RouteQueryRepository(DevicesDbContext context, IMapper mapper)
        {
            connectionString = Startup.ConnectionString;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RouteDTO>> GetRoutes()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Route, RouteDTO>(d => new
                {
                    d.Id,
                    d.Source,
                    d.Destination
                });
                var model = await connection.QueryAsync<RouteDTO>(builder.Query);
                return model;
            }
        }

        public async Task<RouteDTO> GetRoute(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var builder = context.Select<Route, RouteDTO>(d => new
                {
                    d.Id,
                    d.Source,
                    d.Destination
                }).Where(d => d.Id == id);
                var model = await connection.QueryFirstOrDefaultAsync<RouteDTO>(builder.Query);
                return model;
            }
        }

    }
}
