using BIMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BIMS.Repositories;
using BIMS.Services;



var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BIMSContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BIMSConnection"))
            );
builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddRoleManager<RoleManager<IdentityRole<int>>>()
    .AddEntityFrameworkStores<BIMSContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();  // Register Repository
builder.Services.AddScoped<IOrderService, OrderService>();        // Register Service

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

    string[] roles = { "Admin", "User", "DeliveryPerson" , "ShopOwner" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole<int>(role));
        }
    }
}

// Call the method after building the app
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await EnsureRoles(serviceProvider);
}
app.Run();
