using LeagueTables.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LeagueTables.Extensions;

public static class IApplicationBuilderExtensions
{
    public static async Task<IApplicationBuilder> AddAdminAndUserRolesAsync(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        await AddRoleIfNotPresentAsync(roleManager, IdentityRolesNames.Admin);
        await AddRoleIfNotPresentAsync(roleManager, IdentityRolesNames.User);

        return app;
    }

    public static async Task<IApplicationBuilder> AddDefaultAdminAccountAsync(this IApplicationBuilder app)
    {
        const string email = "admin@admin.admin";
        const string password = "admin";

        using var serviceScope = app.ApplicationServices.CreateScope();

        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();

        var admin = await userManager.FindByEmailAsync(email);

        if (admin is null)
        {
            var newUser = new UserEntity()
            {
                Email = email,
                UserName = email
            };

            var identityResult = await userManager.CreateAsync(newUser, password);
            ThrowIfIdentityFailed(identityResult);

            admin = newUser;
        }

        await AddRoleIfNotPresent(userManager, admin, IdentityRolesNames.User);
        await AddRoleIfNotPresent(userManager, admin, IdentityRolesNames.Admin);

        return app;
    }

    private static async Task AddRoleIfNotPresent(UserManager<UserEntity> userManager, UserEntity user, string role)
    {
        if (await userManager.IsInRoleAsync(user, role))
        {
            return;
        }

        var identityResult = await userManager.AddToRoleAsync(user, role);
        ThrowIfIdentityFailed(identityResult);
    }

    private static async Task AddRoleIfNotPresentAsync(RoleManager<IdentityRole<Guid>> roleManager, string roleName)
    {
        if (await roleManager.RoleExistsAsync(roleName))
        {
            return;
        }

        var adminRole = new IdentityRole<Guid>(roleName);

        var identityResult = await roleManager.CreateAsync(adminRole);

        ThrowIfIdentityFailed(identityResult);
    }

    private static void ThrowIfIdentityFailed(IdentityResult identityResult)
    {
        if (!identityResult.Succeeded)
        {
            throw new Exception(identityResult.ToString());
        }
    }
}
