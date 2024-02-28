using Dryva.Devices.Repositories.Commands;
using Dryva.Devices.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Devices.Services
{
    public class DbService : IServiceRunner
    {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddDbContext<DevicesDbContext>(options =>
                options.UseSqlServer(connectionString));


            services.AddScoped<IRabbitUpdateCommand, RabbitUpdateCommand>();
            services.AddScoped<IDeviceQueryRepository, DeviceQueryRepository>();

            services.AddScoped<IRouteQueryRepository, RouteQueryRepository>();

        }
    }
}
