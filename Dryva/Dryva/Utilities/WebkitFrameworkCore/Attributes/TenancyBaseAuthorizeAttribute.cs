using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebKitFrameworkCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class TenancyBaseAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        protected bool CanOverride = true;

        public virtual bool IsOverriden(AuthorizationFilterContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (CanOverride && descriptor.ControllerTypeInfo.IsDefined(typeof(TenancyBaseAuthorizeAttribute), false))
                return true;
            else
                return false;
        }

        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                HandleUnauthorizedRequest(context);
        }

        public virtual void HandleUnauthorizedRequest(AuthorizationFilterContext context)
        {
            context.Result = new ChallengeResult(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
