using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebkitFrameworkCore;

namespace WebKitFrameworkCore.Routing
{
    public abstract class TenantRouteConstraint : IRouteConstraint
    {
        private readonly IHttpRuntimeCache httpRuntime;
        private readonly ITenantRepository tenantRepository;

        public TenantRouteConstraint(IHttpRuntimeCache httpRuntime, ITenantRepository tenantRepository)
        {
            this.httpRuntime = httpRuntime;
            this.tenantRepository = tenantRepository;
        }

        /// <summary>
        /// Gets the tenancy repository.
        /// </summary>
        /// <value>The tenancy repository.</value>
        //protected abstract ITenantRepository Repository { get; }

        /// <summary>
        /// Gets the comma-separated list of top-level domains supported by your application.
        /// </summary>
        /// <value>The comma-separated list of top-level domains.</value>
        protected abstract string TLD { get; }


        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            var fullAddress = httpContext.Request.Host.Value.Split('.');

            if (fullAddress[0].Equals("www") || fullAddress[0].StartsWith("localhost"))
            {
                // strip off www or localhost
                fullAddress = fullAddress.Skip(1).ToArray();
            }

            if (fullAddress.Length < 2)
            {
                httpRuntime.Cache.Remove(CacheKeys.DomainIdentifier);
                httpRuntime.Cache.Remove(CacheKeys.DomainName);
                return false;
            }

            var tlds = string.IsNullOrEmpty(TLD) ? new string[] { } :
                TLD.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (tlds.Contains(fullAddress[1]))
                return false;

            var tenantSubDomain = fullAddress[0];
            var tenant = tenantRepository.GetOrAdd(tenantSubDomain);

            if (!values.ContainsKey(RouteKeys.Tenant) && tenant != null)
            {
                var jsonTenant = JsonConvert.SerializeObject(tenant);

                values.Add(RouteKeys.Tenant, tenant.Id);

                httpRuntime.Remove(CacheKeys.DomainIdentifier);

                httpRuntime.Insert(CacheKeys.DomainIdentifier, jsonTenant,
                    Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(15));
            }
            else if (tenant == null)
            {
                httpRuntime.Remove(CacheKeys.DomainIdentifier);
                httpRuntime.Remove(CacheKeys.DomainName);
            }
            return true;
        }
    }

}

