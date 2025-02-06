using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static async Task CreateRolesAndAdminUser(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // Get the role manager and user manager (helpers to create keys)
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<BIMS.Models.User>>();

            // Define roles like "Admin" and "User"
            string[] roleNames = { "Admin", "User" };

            foreach (var roleName in roleNames)
            {
                // If the role (key type) doesn’t exist, create it.
                if (!await RoleManager.RoleExistsAsync(roleName))
                {
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Get admin details from a safe place (like a secret note)
            var adminEmail = configuration["AdminCredentials:Email"];
            var adminPassword = configuration["AdminCredentials:Password"];

            // Check if the admin already exists
            if (await UserManager.FindByEmailAsync(adminEmail) == null)
            {
                var newAdminUser = new BIMS.Models.User
                {
                    FirstName = adminEmail,
                    Email = adminEmail
                   
                };

                // Create the admin key (user)
                var createAdminUser = await UserManager.CreateAsync(newAdminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    // Give this user the extra power (Admin role)
                    await UserManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }
        }




    }
}
