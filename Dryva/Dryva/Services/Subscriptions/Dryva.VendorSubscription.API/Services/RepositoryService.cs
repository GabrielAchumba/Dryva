using Dryva.VendorSubscription.API.Persistence;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using Dryva.VendorSubscription.API.Persistence.VendorSubscription;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.VendorSubscription.API.Services
{
    public static class RepositoryService
    {
        public static void AddRespositoryService(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRechargeCommandRepository, CustomerRechargeCommandRepository>();
            services.AddScoped<ICustomerRechargeQueryRepository, CustomerRechargeQueryRepository>();

            services.AddScoped<IVendorCommandRepository, VendorCommandRepository>();
            services.AddScoped<IVendorQueryRepository, VendorQueryRepository>();
        }
    }
}
