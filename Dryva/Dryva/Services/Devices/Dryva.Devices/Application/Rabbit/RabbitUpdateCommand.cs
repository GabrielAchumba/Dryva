using Dapper;
using Dryva.Devices.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices
{
    public interface IRabbitUpdateCommand
    {
        Task<int> UpdateDeviceRoute(RouteDTO dto);
    }

    public class RabbitUpdateCommand : IRabbitUpdateCommand
    {
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
    }
}
