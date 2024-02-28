using Dryva.Maps.Repositories.Commands;
using Dryva.Maps.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Maps.Services
{
    public class DbService : IServiceRunner
    {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddDbContext<MapsDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IMapQueryRepository, MapQueryRepository>();
        }
    }
}
