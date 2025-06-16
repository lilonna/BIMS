using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BIMS.Repositories;
using BIMS.Services;
using CloudinaryDotNet;
using Npgsql.EntityFrameworkCore.PostgreSQL;




var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ChapaService>();
builder.Services.AddScoped<ChapaService>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();




builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<BIMSContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("BIMSConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);


var connString = builder.Configuration.GetConnectionString("BIMSConnection");
using var conn = new Npgsql.NpgsqlConnection(connString);
conn.Open();
Console.WriteLine("Connection succeeded");
conn.Close();


builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddRoleManager<RoleManager<IdentityRole<int>>>()
    .AddEntityFrameworkStores<BIMSContext>()
    .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<INotificationService, NotificationService>();


builder.Services.AddScoped<IOrderRepository, OrderRepository>();  // Register Repository
builder.Services.AddScoped<IOrderService, OrderService>();        // Register Service
builder.Services.AddScoped<AdminSetupService>();  // Register AdminSetupService

builder.Services.AddSingleton(x =>
{
    var account = new Account(
        "deihgf8jg",            // your cloud name
        "264269712441549",         // replace with your actual API key
        "YCLpaESP-xOE9uY3V5ToSgKWRWo"       // replace with your actual API secret
    );
    return new Cloudinary(account);
});

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "myapp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}
app.UseStaticFiles();
app.UseDeveloperExceptionPage();


app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

async Task EnsureRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

    // Define roles that should be checked or created
    string[] roles = { "Admin", "User", "DeliveryPerson", "ShopOwner" };

    foreach (var role in roles)
    {
        // Check if the role exists, create it if it doesn't
        if (!await roleManager.RoleExistsAsync(role))
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole<int>(role));
            if (!roleResult.Succeeded)
            {
                Console.WriteLine($"Failed to create role: {role}");
            }
        }
    }




}

// Call the method after building the app
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await EnsureRoles(serviceProvider); // Ensure roles and admin user exist
}



// Call the method after building the app
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await EnsureRoles(serviceProvider);
      // Ensure the admin user exists
  

}
app.Run();
