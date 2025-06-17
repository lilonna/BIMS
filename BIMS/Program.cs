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


builder.Services.AddScoped<IOrderRepository, OrderRepository>();  
builder.Services.AddScoped<IOrderService, OrderService>();        
builder.Services.AddScoped<AdminSetupService>();  

builder.Services.AddSingleton(x =>
{
    var account = new Account(
        "deihgf8jg",            
        "264269712441549",         
        "YCLpaESP-xOE9uY3V5ToSgKWRWo"      
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

    
    string[] roles = { "Admin", "User", "DeliveryPerson", "ShopOwner" };

    foreach (var role in roles)
    {
        
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


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await EnsureRoles(serviceProvider); 
}




using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await EnsureRoles(serviceProvider);
     
  

}
app.Run();
