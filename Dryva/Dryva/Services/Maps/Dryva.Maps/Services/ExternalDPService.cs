using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Maps.Services
{
    public class ExternalDpService : IServiceRunner {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
        }
    }
}