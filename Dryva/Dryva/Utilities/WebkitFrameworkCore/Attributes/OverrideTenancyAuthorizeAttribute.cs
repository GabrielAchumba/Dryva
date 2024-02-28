using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebKitFrameworkCore.Attributes
{
    public class OverrideTenancyAuthorizeAttribute : TenancyAuthorizeAttribute
    {
        public OverrideTenancyAuthorizeAttribute()
        {
            CanOverride = false;
        }
    }
}
