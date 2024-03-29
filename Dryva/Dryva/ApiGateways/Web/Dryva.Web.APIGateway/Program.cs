using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;

namespace Dryva.Web.APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((host, config) =>
           {
               config
               .SetBasePath(host.HostingEnvironment.ContentRootPath)
               // .AddJsonFile("configuration\\config-enrollment.json");
               .AddOcelot("configuration", host.HostingEnvironment);
           })
           .UseStartup<Startup>();
    }
}
