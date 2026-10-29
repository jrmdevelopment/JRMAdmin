using JarvisAdmin.Web.Data.Jarvis;

namespace JarvisAdmin.Web.Services;

public class OrganizationService(JarvisDbContext db)
{
    // Mirrors the Organization table's DEFAULT constraints (see dbo.Organization in jarvisdb.sql)
    // for the handful of columns that default to something other than a C# type's zero value.
    public static Organization CreateNewOrganization() => new()
    {
        Status = "A",
        DateAdded = DateTime.Now,
        AutoReopenFields = true,
        PayOnline = true,
        OnlineApplications = true,
        GatewayUsed = "AuthorizeNET",
        TimeZone = 2,
    };

    public async Task<Organization> AddOrganizationAsync(Organization organization, string? currentUser)
    {
        organization.DateAdded = DateTime.Now;
        organization.LastUpdatedBy = currentUser;

        db.Organizations.Add(organization);
        await db.SaveChangesAsync();

        return organization;
    }
}
