using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Helpers
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds and configures the identity system for the specified User type.
        /// </summary>
        /// <typeparam name="TUser">The type of the user.</typeparam>
        /// <typeparam name="TRole">The type of the role.</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="setupAction">The setup action.</param>
        /// <returns>IdentityBuilder.</returns>
        public static IdentityBuilder AddIdentityCore<TUser, TRole>(
            this IServiceCollection services, Action<IdentityOptions> setupAction)
            where TUser : IdentityUser
            where TRole : IdentityRole
        {
            var builder = services.AddIdentityCore<TUser>(setupAction).AddRoles<TRole>();
            return builder;
        }
    }
}

