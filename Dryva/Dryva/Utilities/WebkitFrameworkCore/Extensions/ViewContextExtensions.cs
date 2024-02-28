using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebkitFrameworkCore.Extensions
{
    public static class ViewContextExtensions
    {
        public static string CssActive(this ViewContext viewContext, string controller)
        {
            return viewContext.RouteData.Values["controller"].ToString().Equals(controller, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }

        public static string CssActive(this ViewContext viewContext, params string[] controllers)
        {
            var controller = viewContext.RouteData.Values["controller"].ToString();
            return controllers.Any(c => c.Equals(controller, StringComparison.OrdinalIgnoreCase)) ? "active" : "";
        }

        public static string CssActive(this ViewContext viewContext, string controller, string action)
        {
            if (!viewContext.RouteData.Values["controller"].ToString().Equals(controller, StringComparison.OrdinalIgnoreCase))
                return "";

            return viewContext.RouteData.Values["action"].ToString().Equals(action, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }

        public static string CssActive(this ViewContext viewContext, string controller, params string[] actions)
        {
            if (!viewContext.RouteData.Values["controller"].ToString().Equals(controller, StringComparison.OrdinalIgnoreCase))
                return "";

            var action = viewContext.RouteData.Values["action"].ToString();
            return actions.Any(a => a.Equals(action, StringComparison.OrdinalIgnoreCase)) ? "active" : "";
        }
    }
}
