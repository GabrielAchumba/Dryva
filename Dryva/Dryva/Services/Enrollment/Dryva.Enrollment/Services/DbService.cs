using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Enrollment.Services
{
    public class DbService : IServiceRunner
    {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddDbContext<EnrollmentDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>(); 
            services.AddScoped<ICaptureSessionQueryRepository, CaptureSessionQueryRepository>();
            services.AddScoped<IDriverQueryRepository, DriverQueryRepository>();
            services.AddScoped<IShareholderQueryRepository, ShareholderQueryRepository>();
            services.AddScoped<IRTPSQueryRepository, RTPSQueryRepository>();
            services.AddScoped<IStateQueryRepository, StateQueryRepository>();
            services.AddScoped<ILGAQueryRepository, LGAQueryRepository>();
        }
    }
}
