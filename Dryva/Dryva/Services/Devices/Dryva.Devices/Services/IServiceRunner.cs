using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Devices.Services 
{
    public interface IServiceRunner {
        void Run(IServiceCollection services, string connectionString);
    }
}