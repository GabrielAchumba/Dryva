using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CustomerSubscription.API.Services {
    public class HealthChecksServiceRunner : IServiceRunner {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddHealthChecks()
                .AddSqlServer(connectionString, failureStatus: HealthStatus.Unhealthy);
        }
    }
}