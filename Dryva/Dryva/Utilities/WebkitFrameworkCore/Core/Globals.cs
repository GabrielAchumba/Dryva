using System;
using System.Collections.Generic;
using System.Text;

namespace WebkitFrameworkCore
{
    public static class ClaimTypes
    {
        public const string SuperUser = "http://eds-micronet.com/claims/superUser";
        public const string Domain = "http://eds-micronet.com/claims/domain";
        public const string PageAccess = "http://eds-micronet.com/claims/pageAccess";
        public const string SelfService = "http://eds-micronet.com/claims/selfService";
    }

    public static class CacheKeys
    {
        public const string DomainIdentifier = "http://eds-micronet.com/cache/domainIdentifier";
        public const string DomainName = "http://eds-micronet.com/cache/domainName";
    }

    public static class RouteKeys
    {
        public const string Tenant = "tenant_id";
    }
}
