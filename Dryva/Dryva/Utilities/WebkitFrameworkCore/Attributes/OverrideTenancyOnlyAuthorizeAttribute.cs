using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebKitFrameworkCore.Attributes
{
    public class OverrideTenancyOnlyAuthorizeAttribute : TenancyOnlyAuthorizeAttribute
    {
        public OverrideTenancyOnlyAuthorizeAttribute()
        {
            CanOverride = false;
        }
    }
}
