using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebkitFrameworkCore;

namespace WebKitFrameworkCore.Attributes
{
    public class TenancyOnlyAuthorizeAttribute : TenancyBaseAuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            if (IsOverriden(context))
                return;

            var user = context.HttpContext.User as System.Security.Claims.ClaimsPrincipal;
            var tenantId = context.RouteData.Values[RouteKeys.Tenant] as Guid?;

            if (tenantId != null)
            {
                if (user != null)
                {
                    if (!(user.HasClaim(ClaimTypes.SuperUser, "true") || user.HasClaim(ClaimTypes.Domain, tenantId.ToString())))
                    {
                        base.HandleUnauthorizedRequest(context);
                        return;
                    }
                }

                base.OnAuthorization(context);
                return;
            }

            base.HandleUnauthorizedRequest(context);
        }
    }
}
