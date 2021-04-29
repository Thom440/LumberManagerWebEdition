using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LumberManagerWebEdition.Models
{
    public static class IdentityHelper
    {
        // Role names
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static void SetIdentityOptions(IdentityOptions options)
        {
            // Setting sign in options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            // Set password strength
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;

            // Set lockout options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 3;
        }

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create role if it does not exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultAdmin(IServiceProvider serviceProvider)
        {
            const string email = "admin@admin.com";
            const string username = "admin";
            const string password = "adminadmin";

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Check if any users are in database
            if (userManager.Users.Count() == 0)
            {
                IdentityUser admin = new IdentityUser()
                {
                    Email = email,
                    UserName = username,
                };

                // Create instructor
                await userManager.CreateAsync(admin, password);

                // Add to instructor role
                await userManager.AddToRoleAsync(admin, Admin);
            }
        }
    }
}
