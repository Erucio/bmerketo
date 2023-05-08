
using ASP_Assignment.Helpers.Repositories;
using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ASP_Assignment_DB")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthService>();


builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});




var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
