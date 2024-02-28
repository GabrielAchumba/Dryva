using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Maps.Services 
{
    public interface IServiceRunner {
        void Run(IServiceCollection services, string connectionString);
    }
}