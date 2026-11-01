using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace JarvisAdmin.Web.Services;

// Uses a fresh short-lived context per operation (see the AddDbContextFactory note in Program.cs), so a
// failed save doesn't leave a half-added/modified Organization tracked in the circuit's shared context
// and poison the next attempt.
public partial class OrganizationService(IDbContextFactory<JarvisDbContext> dbFactory)
{
    // The FeeStructure value the legacy procs check for (e.g. Organization.FeeStructure = 'Resident').
    public const string ResidentFeeStructure = "Resident";

    // Mirrors the Organization table's DEFAULT constraints (see dbo.Organization in JarvisData/jarvisdatabase.sql)
    // for the handful of columns that default to something other than a C# type's zero value, plus the
    // FeeStructure/StandingsType/POSScreenName, payment gateway, application and text reminder settings every new
    // organization starts with (GatewayUsed deliberately differs from the table's AuthorizeNET default).
    public static Organization CreateNewOrganization() => new()
    {
        Status = "A",
        DateAdded = DateTime.Now,
        PayOnline = true,
        OnlineApplications = true,
        GatewayUsed = "MXGateway",
        AllowDisc = true,
        MerchantPctToRegistrant = 0.0300m,
        SwipePctToRegistrant = 0.0300m,
        TimeZone = 2,
        FeeStructure = "Neither",
        StandingsType = "Head",
        PosscreenName = "POSRegister.aspx",
        RequirePaymentWhenRegistering = true,
        CoachApplications = true,
        ShiftAutoendMidnight = true,
        // Not on the form and the column is going away, but set on for now in case anything still relies on it.
        SeasonPassAccount = true,
        TextGameReminders = true,
        TextPracticeReminders = true,
        GameTimeTextNotificationMinutes = 120,
        PracticeTimeTextNotificationMinutes = 120,
    };

    // The NOT NULL text columns the form can't supply a default for (the fields marked * on the form).
    public static bool HasRequiredFields(Organization o) =>
        !string.IsNullOrWhiteSpace(o.OrganizationName) &&
        !string.IsNullOrWhiteSpace(o.OrganizationAddr) &&
        !string.IsNullOrWhiteSpace(o.OrganizationCity) &&
        !string.IsNullOrWhiteSpace(o.OrganizationSt) &&
        !string.IsNullOrWhiteSpace(o.OrganizationZip) &&
        !string.IsNullOrWhiteSpace(o.ContactName) &&
        !string.IsNullOrWhiteSpace(o.ContactPhone) &&
        !string.IsNullOrWhiteSpace(o.ContactEmailAddr) &&
        !string.IsNullOrWhiteSpace(o.FeeStructure) &&
        !string.IsNullOrWhiteSpace(o.StandingsType);

    // Puts the phone numbers in the 999-999-9999 form the CHAR(12) phone columns are meant to hold, then returns
    // a message naming the first one that still isn't a full 10-digit number, or null when they're all fine.
    // Formatting here (not just the input mask) also tidies values saved earlier as e.g. "(555) 123-4567".
    public static string? FormatAndValidatePhones(Organization o)
    {
        o.ContactPhone = FormatPhone(o.ContactPhone)!;
        o.AfterhoursPhone = FormatPhone(o.AfterhoursPhone);
        o.ReportPhone = FormatPhone(o.ReportPhone);

        foreach (var (label, phone) in new[] { ("Contact Phone", o.ContactPhone), ("After-Hours Phone", o.AfterhoursPhone), ("Report Phone", o.ReportPhone) })
        {
            if (!string.IsNullOrEmpty(phone) && !PhonePattern().IsMatch(phone))
            {
                return $"{label} must be a full phone number in the format 999-999-9999.";
            }
        }
        return null;
    }

    private static string? FormatPhone(string? phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            return string.IsNullOrEmpty(phone) ? phone : "";
        }

        var digits = new string(phone.Where(char.IsDigit).ToArray());
        if (digits.Length == 11 && digits[0] == '1')
        {
            digits = digits[1..];
        }
        return digits.Length == 10 ? $"{digits[..3]}-{digits[3..6]}-{digits[6..]}" : phone.Trim();
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"^\d{3}-\d{3}-\d{4}$")]
    private static partial System.Text.RegularExpressions.Regex PhonePattern();

    public async Task<List<OrganizationListItem>> GetOrganizationListAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Organizations
            .OrderBy(o => o.OrganizationName)
            .Select(o => new OrganizationListItem(
                o.OrganizationKey,
                o.OrganizationName + " (" + o.OrganizationKey + ")" + (o.Status == "I" ? " - Inactive" : "")))
            .ToListAsync();
    }

    public async Task<Organization?> GetOrganizationAsync(int organizationKey)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Organizations.AsNoTracking().FirstOrDefaultAsync(o => o.OrganizationKey == organizationKey);
    }

    // Residency validation only applies to a Resident fee structure, so it's always saved off otherwise -
    // including for an existing organization that was left in that state before the form enforced it.
    private static void ClearResidencyChecksUnlessResident(Organization organization)
    {
        if (organization.FeeStructure != ResidentFeeStructure)
        {
            organization.ValidateResidencyByAddr = false;
            organization.ValidateResidencyByZip = false;
        }
    }

    // Adds the organization together with its home city and initial login, all in one transaction so a problem with the login
    // (e.g. a User Id that's already taken) doesn't leave an organization behind with no way to sign in. Mirrors
    // what the main Jarvis app does: aspnet_Roles_AddAdministrator for the role, Membership.CreateUser
    // (aspnet_Membership_CreateUser) + userdetails_adduserdetails for the user (Security/AddModifyUser.aspx),
    // then aspnet_RolesToScreen_AddDefault's copy of the template role's screens.
    public async Task<Organization> AddOrganizationAsync(Organization organization, InitialLogin login, string? currentUser)
    {
        ClearResidencyChecksUnlessResident(organization);
        organization.LastUpdatedBy = currentUser;

        var name = login.Name.Trim();
        var userId = login.UserId.Trim();
        var email = login.Email.Trim();
        var (passwordHash, passwordSalt) = JarvisMembershipPassword.Hash(login.Password);

        // EnableRetryOnFailure (Program.cs) requires a manual transaction to run inside the execution strategy,
        // which re-runs the whole block on a transient failure - hence a fresh context and key each attempt.
        await using var strategyDb = await dbFactory.CreateDbContextAsync();
        try
        {
            await SaveOrganizationWithLoginAsync();
        }
        catch
        {
            // The insert was rolled back, so clear the key it was given; otherwise the Add form would treat the
            // still-on-screen organization as an existing one.
            organization.OrganizationKey = 0;
            throw;
        }

        return organization;

        Task SaveOrganizationWithLoginAsync() => strategyDb.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
        {
            await using var db = await dbFactory.CreateDbContextAsync();
            await using var transaction = await db.Database.BeginTransactionAsync();

            organization.OrganizationKey = 0;
            organization.DateAdded = DateTime.Now;
            db.Organizations.Add(organization);
            await db.SaveChangesAsync();

            // The organization's own city as its active home city, as the legacy org insert proc does.
            db.Cities.Add(new City
            {
                OrganizationKey = organization.OrganizationKey,
                CityName = organization.OrganizationCity.Trim(),
                HomeCity = "Y",
                CityStatus = "A",
            });
            await db.SaveChangesAsync();

            var connection = db.Database.GetDbConnection();
            var dbTransaction = transaction.GetDbTransaction();

            // 1. The organization's Administrator role, as aspnet_Roles_AddAdministrator creates it.
            var roleId = (Guid)(await ExecuteScalarAsync(connection, dbTransaction, """
                DECLARE @ApplicationId uniqueidentifier =
                    (SELECT ApplicationId FROM aspnet_Applications WHERE LoweredApplicationName = LOWER(@ApplicationName));
                IF @ApplicationId IS NULL
                    THROW 50000, 'The JarvisRec application was not found in aspnet_Applications.', 1;

                DECLARE @RoleId uniqueidentifier = NEWID();
                INSERT INTO aspnet_Roles (ApplicationId, RoleId, OrganizationKey, RoleName, LoweredRoleName, Description, LastUpdatedBy)
                VALUES (@ApplicationId, @RoleId, @OrganizationKey, 'Administrator', 'administrator', NULL, @Name);
                SELECT @RoleId;
                """,
                ("@ApplicationName", JarvisApplicationName),
                ("@OrganizationKey", organization.OrganizationKey),
                ("@Name", name)))!;

            // 2. The user, through the same procedures the main app's membership provider uses.
            var newUserId = await CreateMembershipUserAsync(connection, dbTransaction, userId, email, passwordHash, passwordSalt);

            await ExecuteScalarAsync(connection, dbTransaction,
                "EXEC userdetails_adduserdetails @UserId, @OrganizationKey, @UserName, 'A', @LastChangedBy, @InitialScreen",
                ("@UserId", newUserId),
                ("@OrganizationKey", organization.OrganizationKey),
                ("@UserName", name),
                ("@LastChangedBy", name),
                ("@InitialScreen", DefaultInitialScreen));

            // 3. Tie the user to the Administrator role.
            await ExecuteScalarAsync(connection, dbTransaction,
                "INSERT INTO aspnet_UsersInRoles (UserId, RoleId, LastUpdatedBy) VALUES (@UserId, @RoleId, @Name)",
                ("@UserId", newUserId),
                ("@RoleId", roleId),
                ("@Name", name));

            // 4. Give the role every screen, copied from the template role like aspnet_RolesToScreen_AddDefault.
            var screenCount = (int)(await ExecuteScalarAsync(connection, dbTransaction, """
                INSERT INTO aspnet_RolesToScreens (RoleId, ScreenName, LastUpdatedBy)
                SELECT @RoleId, ScreenName, @Name FROM aspnet_RolesToScreens WHERE RoleId = @TemplateRoleId;
                SELECT COUNT(*) FROM aspnet_RolesToScreens WHERE RoleId = @RoleId;
                """,
                ("@RoleId", roleId),
                ("@Name", name),
                ("@TemplateRoleId", TemplateAdministratorRoleId)))!;
            if (screenCount == 0)
            {
                throw new InvalidOperationException(
                    $"No screens were found on the template role {TemplateAdministratorRoleId}, so the Administrator role would have no access.");
            }

            await transaction.CommitAsync();
        });
    }

    // The membership application name in the main app's Web.config (provider applicationName="JarvisRec").
    private const string JarvisApplicationName = "JarvisRec";

    // The role aspnet_RolesToScreen_AddDefault copies a new role's screens from.
    private static readonly Guid TemplateAdministratorRoleId = new("90805787-781E-47E6-979D-C13D5E5DCF8B");

    // The main app's default Initial Screen choice (Security/AddModifyUser.aspx offers Dashboard or DailyCalendar).
    private const string DefaultInitialScreen = "Dashboard";

    private static async Task<Guid> CreateMembershipUserAsync(System.Data.Common.DbConnection connection,
        System.Data.Common.DbTransaction transaction, string userName, string email, string passwordHash, string passwordSalt)
    {
        await using var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = """
            EXEC @ReturnValue = aspnet_Membership_CreateUser
                @ApplicationName = @ApplicationName, @UserName = @UserName, @Password = @Password,
                @PasswordSalt = @PasswordSalt, @Email = @Email, @PasswordQuestion = NULL, @PasswordAnswer = NULL,
                @IsApproved = 1, @CurrentTimeUtc = @CurrentTimeUtc, @UniqueEmail = 0,
                @PasswordFormat = @PasswordFormat, @UserId = @UserId OUTPUT;
            """;
        AddParameter(command, "@ApplicationName", JarvisApplicationName);
        AddParameter(command, "@UserName", userName);
        AddParameter(command, "@Password", passwordHash);
        AddParameter(command, "@PasswordSalt", passwordSalt);
        AddParameter(command, "@Email", email);
        AddParameter(command, "@CurrentTimeUtc", DateTime.UtcNow);
        AddParameter(command, "@PasswordFormat", JarvisMembershipPassword.HashedPasswordFormat);
        var returnValue = AddParameter(command, "@ReturnValue", 0, System.Data.ParameterDirection.Output);
        var newUserId = AddParameter(command, "@UserId", Guid.Empty, System.Data.ParameterDirection.Output);

        await command.ExecuteNonQueryAsync();

        // aspnet_Membership_CreateUser's return codes, as SqlMembershipProvider interprets them.
        switch ((int)returnValue.Value!)
        {
            case 0:
                return (Guid)newUserId.Value!;
            case 6:
                throw new InvalidOperationException($"The Initial Login User Id \"{userName}\" is already taken. Please choose another.");
            default:
                throw new InvalidOperationException($"The Initial Login could not be created (aspnet_Membership_CreateUser returned {returnValue.Value}).");
        }
    }

    private static async Task<object?> ExecuteScalarAsync(System.Data.Common.DbConnection connection,
        System.Data.Common.DbTransaction transaction, string sql, params (string Name, object Value)[] parameters)
    {
        await using var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = sql;
        foreach (var (parameterName, value) in parameters)
        {
            AddParameter(command, parameterName, value);
        }
        return await command.ExecuteScalarAsync();
    }

    private static System.Data.Common.DbParameter AddParameter(System.Data.Common.DbCommand command, string name, object value,
        System.Data.ParameterDirection direction = System.Data.ParameterDirection.Input)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value;
        parameter.Direction = direction;
        command.Parameters.Add(parameter);
        return parameter;
    }

    // Writes every column from the edited copy back to its row. DateAdded is restored from the database so
    // an edit can never change when the organization was created.
    public async Task UpdateOrganizationAsync(Organization organization, string? currentUser)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var existing = await db.Organizations.FirstOrDefaultAsync(o => o.OrganizationKey == organization.OrganizationKey)
            ?? throw new InvalidOperationException($"Organization {organization.OrganizationKey} no longer exists.");

        ClearResidencyChecksUnlessResident(organization);
        var dateAdded = existing.DateAdded;
        db.Entry(existing).CurrentValues.SetValues(organization);
        existing.DateAdded = dateAdded;
        existing.LastUpdatedBy = currentUser;

        await db.SaveChangesAsync();
    }
}

public sealed record OrganizationListItem(int OrganizationKey, string DisplayName);
