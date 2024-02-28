using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerSubscription.API.Services {
    public interface IServiceRunner {
        void Run(IServiceCollection services, string connectionString);
    }
}