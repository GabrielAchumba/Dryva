using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dryva.Maps.Services
{
    public static class InstallerExtensions {
        public static void InstallServicesInAssembly(this IServiceCollection services, string connectionString) {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IServiceRunner).IsAssignableFrom(x) && 
                !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IServiceRunner>().ToList();

            installers.ForEach(installer => installer.Run(services, connectionString));
        }
    }
}