using CustomerSubscription.API.Infrastructure;
using CustomerSubscription.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerSubscription.API.Services
{
    public class DbService : IServiceRunner
    {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddDbContext<SubscriptionDbContext>(option => option.UseSqlServer(connectionString));
            
            services.AddScoped<ISubscriptionCommandRepository, SubscriptionCommandRepository>();
            services.AddScoped<ISubscriptionQueryRepository, SubscriptionQueryRepository>();
        }
    }
}
