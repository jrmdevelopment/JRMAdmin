using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Renamed from Identity's defaults (AspNetUsers, etc.) to avoid confusion with
        // the legacy JarvisAdminUser table from the old JarvisAdmin project.
        builder.Entity<ApplicationUser>().ToTable("AdminUsers");
        builder.Entity<IdentityRole>().ToTable("AdminRoles");
        builder.Entity<IdentityUserRole<string>>().ToTable("AdminUserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("AdminUserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("AdminUserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("AdminUserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("AdminRoleClaims");
    }
}
