using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Services;

// Ports the old admin_loggedinusers proc: a user counts as "logged in" when the Jarvis app has touched
// UserDetails.LastAccess (userdetails_updatelastaccess) within the last 30 minutes - there's no logout
// tracking, so recent activity is the only signal. The login time itself comes from
// aspnet_Membership.LastLoginDate, and both times are shown in the user's organization time zone.
public class LoggedInUsersService(JarvisDbContext db)
{
    // Same window as admin_loggedinusers.
    private const int ActiveWindowMinutes = 30;

    // LastAccess is written in DB server time, and the server runs on Pacific time.
    private static readonly TimeZoneInfo ServerTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

    public async Task<List<LoggedInUserRow>> GetLoggedInUsersAsync()
    {
        // DateTime.Now translates to GETDATE(), so the window is measured against the DB server clock
        // exactly like the old proc, regardless of the web server's clock/zone.
        var rows = await (
            from u in db.UserDetails
            join o in db.Organizations on u.OrganizationKey equals o.OrganizationKey
            join m in db.AspnetMemberships on u.UserId equals m.UserId into memberships
            from m in memberships.DefaultIfEmpty()
            where u.LastAccess != null && u.LastAccess.Value.AddMinutes(ActiveWindowMinutes) > DateTime.Now
            orderby o.OrganizationName, u.LastAccess descending
            select new
            {
                u.UserName,
                o.OrganizationName,
                o.TimeZone,
                LastAccess = u.LastAccess!.Value,
                LastLoginUtc = m == null ? (DateTime?)null : m.LastLoginDate
            }
        ).ToListAsync();

        return rows.Select(r =>
        {
            var zone = ToTimeZoneInfo(r.TimeZone);
            return new LoggedInUserRow
            {
                UserName = r.UserName,
                OrganizationName = r.OrganizationName,
                TimeZoneName = TimeZoneLabel(r.TimeZone),
                // aspnet_Membership stores LastLoginDate in UTC (SqlMembershipProvider passes UtcNow).
                LoggedIn = r.LastLoginUtc is { } utc
                    ? TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(utc, DateTimeKind.Utc), zone)
                    : null,
                LastActivity = TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(r.LastAccess, DateTimeKind.Unspecified), ServerTimeZone, zone)
            };
        }).ToList();
    }

    // Organization.TimeZone is the legacy offset index (1=Eastern, 2=Central, 3=Mountain, 4=Pacific).
    private static TimeZoneInfo ToTimeZoneInfo(int timeZone) => timeZone switch
    {
        1 => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
        3 => TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"),
        4 => TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"),
        _ => TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
    };

    private static string TimeZoneLabel(int timeZone) => timeZone switch
    {
        1 => "Eastern",
        3 => "Mountain",
        4 => "Pacific",
        _ => "Central"
    };
}

public class LoggedInUserRow
{
    public string UserName { get; set; } = "";
    public string OrganizationName { get; set; } = "";
    public string TimeZoneName { get; set; } = "";
    public DateTime? LoggedIn { get; set; }
    public DateTime LastActivity { get; set; }
}
