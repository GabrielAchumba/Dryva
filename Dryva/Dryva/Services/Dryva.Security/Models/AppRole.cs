using Microsoft.AspNetCore.Identity;

namespace Dryva.Security.Models
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
