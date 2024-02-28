using Dryva.Security.Models;
using Dryva.Security.Repositories.Commands;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.Repositories
{
    public class DbSeeder : IDbSeeder
    {
        private readonly SecurityDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        public DbSeeder(SecurityDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void CreateAdminCredentials()
        {
            // In Startup i am creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                // first we create Admin Role   
                var role = new AppRole()
                {
                    Name = "Admin"
                };
                roleManager.CreateAsync(role).GetAwaiter().GetResult();

                //Here we create an Admin user who will maintain the website
                var email = "sysadmin@dryva.ng";
                var user = new AppUser()
                {
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = email,
                    Email = email,
                    SuperUser = true
                };
                string userPWD = "Dryvaadmin@2019";

                var result = userManager.CreateAsync(user, userPWD).GetAwaiter().GetResult();

                //Add default User to Role Admin   
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, role.Name).GetAwaiter().GetResult();
                }
            }

            // Creating Guest Role    
            if (!roleManager.RoleExistsAsync("Guest").GetAwaiter().GetResult())
            {
                var role = new AppRole()
                {
                    Name = "Guest"
                };
                roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
        }

    }
}
