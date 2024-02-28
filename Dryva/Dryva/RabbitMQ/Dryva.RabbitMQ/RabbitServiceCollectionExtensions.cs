using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dryva.RabbitMQ
{
    public static class RabbitServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitConfig = new RabbitOptions();
            rabbitConfig.UserName = configuration["rabbit:UserName"];
            rabbitConfig.Password = configuration["rabbit:Password"];
            rabbitConfig.HostName = configuration["rabbit:HostName"];
            rabbitConfig.VHost = configuration["rabbit:VHost"] ?? rabbitConfig.VHost;

            string _port = configuration["rabbit:Port"];
            if (!string.IsNullOrEmpty(_port))
            {
                int port = rabbitConfig.Port;
                int.TryParse(_port, out port);
                rabbitConfig.Port = port;
            }
            services.AddSingleton(rabbitConfig);

            services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.AddSingleton<IPooledObjectPolicy<IModel>, RabbitModelPooledObjectPolicy>();
            services.AddSingleton<IRabbitManager, RabbitManager>();

            return services;
        }

        public static void RegisterRabbitSubscriber<TModel, TRepo>(this IApplicationBuilder app) where TModel : RabbitSubcriberBase
        {
            var rmanager = app.ApplicationServices.GetRequiredService<IRabbitManager>();
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<TRepo>();
                Activator.CreateInstance(typeof(TModel), rmanager, repo);
            }
        }

        public static void RegisterRabbitSubscriber<TModel, TRepo1, TRepo2>(this IApplicationBuilder app) where TModel : RabbitSubcriberBase
        {
            var rmanager = app.ApplicationServices.GetRequiredService<IRabbitManager>();
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<TRepo1>();
                var repo2 = scope.ServiceProvider.GetRequiredService<TRepo2>();
                Activator.CreateInstance(typeof(TModel), rmanager, repo, repo2);
            }
        }
    }
}
