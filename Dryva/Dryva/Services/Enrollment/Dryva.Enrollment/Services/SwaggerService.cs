using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Enrollment.Services
{ 
    public class SwaggerService : IServiceRunner 
    {
        public void Run(IServiceCollection services, string connectionString) {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Dryva Enrollment API",
                    Version = "v1",
                    Description = "Dryva enrollment API"
                });
            });
        }
    }
}