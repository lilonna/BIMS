using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Controllers
{
    public class AdminController : Controller
    {
        //private readonly UserManager<User> _userManager;
        //private readonly RoleManager<IdentityRole<int>> _roleManager;

        //public AdminController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}
        public IActionResult Index()
        {
            return View();
        }

        //public static async Task CreateRolesAndAdminUser(IServiceProvider serviceProvider, IConfiguration configuration)
        //{
        //    // Get the role manager and user manager (helpers to create keys)
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<BIMS.Models.User>>();

        //    // Define roles like "Admin" and "User"
        //    string[] roleNames = { "Admin", "User", "DeliveryPerson" };

        //    foreach (var roleName in roleNames)
        //    {
        //        // If the role (key type) doesn’t exist, create it.
        //        if (!await RoleManager.RoleExistsAsync(roleName))
        //        {
        //            await RoleManager.CreateAsync(new IdentityRole<int>(roleName));
        //        }
        //    }

        //    // Get admin details from a safe place (like a secret note)
        //    var adminEmail = configuration["AdminCredentials:Email"];
        //    var adminPassword = configuration["AdminCredentials:Password"];

        //    // Check if the admin already exists
        //    if (await UserManager.FindByEmailAsync(adminEmail) == null)
        //    {
        //        var newAdminUser = new BIMS.Models.User
        //        {
        //            FirstName = adminEmail,
        //            Email = adminEmail
                   
        //        };

        //        // Create the admin key (user)
        //        var createAdminUser = await UserManager.CreateAsync(newAdminUser, adminPassword);
        //        if (createAdminUser.Succeeded)
        //        {
        //            // Give this user the extra power (Admin role)
        //            await UserManager.AddToRoleAsync(newAdminUser, "Admin");
        //        }
        //    }
        //}




    }
}
