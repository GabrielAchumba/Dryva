using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Enrollment.Services 
{
    public interface IServiceRunner {
        void Run(IServiceCollection services, string connectionString);
    }
}