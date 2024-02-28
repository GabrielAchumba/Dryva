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
    public class NoTenancyAuthorizeAttribute : TenancyBaseAuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            if (IsOverriden(context))
                return;

            var user = context.HttpContext.User as System.Security.Claims.ClaimsPrincipal;
            var tenantId = context.RouteData.Values[RouteKeys.Tenant] as Guid?;

            if (tenantId == null)
            {
                if (user != null)
                {
                    var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Domain);

                    if (claim != null)
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
