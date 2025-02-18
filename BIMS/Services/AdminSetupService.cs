using BIMS.Models;
using Microsoft.AspNetCore.Identity;

namespace BIMS.Services
{
    public class AdminSetupService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AdminSetupService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task CreateAdminIfNotExistsAsync()
        {
            var adminEmail = _configuration["AdminCredentials:Email"];
            var adminPassword = _configuration["AdminCredentials:Password"];

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    // Admin created successfully
                    Console.WriteLine(" Admin created successfully");
                }
                else
                {
                    Console.WriteLine("Failed to create admin.");// Handle errors
                }
            }
        }
    }

}
