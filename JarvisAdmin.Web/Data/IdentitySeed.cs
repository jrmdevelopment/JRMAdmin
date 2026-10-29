using Microsoft.AspNetCore.Identity;

namespace JarvisAdmin.Web.Data;

// Bootstraps the very first admin account, since public self-registration is disabled.
// No-ops once at least one AdminUsers row exists, so it's safe to run on every startup.
internal static class IdentitySeed
{
    public static async Task SeedInitialAdminUserAsync(IServiceProvider services, IConfiguration configuration, ILogger logger)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        if (userManager.Users.Any())
        {
            return;
        }

        var username = configuration["InitialAdmin:Username"];
        var email = configuration["InitialAdmin:Email"];
        var password = configuration["InitialAdmin:Password"];

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            logger.LogWarning(
                "No AdminUsers exist yet, but InitialAdmin:Username/Email/Password are not configured, so no account was created. " +
                "Set them via user-secrets (local) or environment variables (staging/production) and restart the app.");
            return;
        }

        const string administratorRole = "Administrator";
        if (!await roleManager.RoleExistsAsync(administratorRole))
        {
            await roleManager.CreateAsync(new IdentityRole(administratorRole));
        }

        var user = new ApplicationUser
        {
            UserName = username,
            Email = email,
            EmailConfirmed = true,
        };

        var createResult = await userManager.CreateAsync(user, password);
        if (!createResult.Succeeded)
        {
            var errors = string.Join("; ", createResult.Errors.Select(e => e.Description));
            logger.LogError("Failed to create the initial admin user: {Errors}", errors);
            return;
        }

        await userManager.AddToRoleAsync(user, administratorRole);
        logger.LogInformation("Created initial admin user {Username} in the {Role} role.", username, administratorRole);
    }
}
