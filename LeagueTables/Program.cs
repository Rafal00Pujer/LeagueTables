using LeagueTables.Data.Context;
using LeagueTables.Data.Entities;
using LeagueTables.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<LeagueTablesContext>(options =>
{
    var rootPath = builder.Environment.ContentRootPath;
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!.Replace("[DataDirectory]", rootPath);

    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<UserEntity, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<LeagueTablesContext>();

builder.Services.AddAuthentication();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

await app.AddAdminAndUserRolesAsync();

if (app.Environment.IsDevelopment())
{
    await app.AddDefaultAdminAccountAsync();

    app.AssertMapperConfiguration();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
