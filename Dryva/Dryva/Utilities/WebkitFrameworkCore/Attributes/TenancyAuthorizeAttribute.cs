using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebkitFrameworkCore;

namespace WebKitFrameworkCore.Attributes
{
    public class TenancyAuthorizeAttribute : TenancyBaseAuthorizeAttribute
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
                    if (user.HasClaim(ClaimTypes.SuperUser, "true") || user.HasClaim(ClaimTypes.Domain, tenantId.ToString()))
                    {
                        base.OnAuthorization(context);
                        return;
                    }
                    else
                    {
                        base.HandleUnauthorizedRequest(context);
                        return;
                    }
                }
            }
            else
            {
                if (user != null)
                {
                    var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Domain);

                    // user account has sub domain, but url is not sub domain. BLOCK!
                    if (claim != null)
                    {
                        base.HandleUnauthorizedRequest(context);
                        return;
                    }
                }
            }

            base.OnAuthorization(context);
        }
    }
}