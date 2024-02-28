using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CustomerSubscription.API.Application.Filter;
using CustomerSubscription.API.HealthChecks;
using CustomerSubscription.API.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;

namespace CustomerSubscription.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            
            services.AddSingleton(Configuration);
            services.InstallServicesInAssembly(Configuration.GetConnectionString("SubscriptionDbConnection"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseSerilogRequestLogging();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions {
                    ResponseWriter = GetResponseWriter
                });
            }); 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dryva Subscription API v1");
            });
        }

        private static async Task GetResponseWriter(HttpContext context, HealthReport report) {
            context.Response.ContentType = "application/json";
            var response = GetResponse(report);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static HealthCheckResponse GetResponse(HealthReport report) {
            return new HealthCheckResponse {
                Status = report.Status.ToString(),
                Checks = report.Entries.Select(x => new HealthCheck {
                    Component = x.Key,
                    Status = x.Value.Status.ToString(),
                    Duration = x.Value.Duration,
                    Description = x.Value.Description 
                }),
                TotalDuration = report.TotalDuration
            };
        }
    }
}
