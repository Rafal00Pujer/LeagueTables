using LeagueTables.Data.Context;
using LeagueTables.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LeagueTablesContext>(options =>
{
    var rootPath = builder.Environment.ContentRootPath;
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!.Replace("[DataDirectory]", rootPath);

    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<UserEntity, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<LeagueTablesContext>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
