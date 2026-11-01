using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using JarvisAdmin.Web.Components;
using JarvisAdmin.Web.Components.Account;
using JarvisAdmin.Web.Data;
using JarvisAdmin.Web.Data.Jarvis;
using JarvisAdmin.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// dotnet run only wires up static web assets (Razor scoped CSS bundles, and anything a
// referenced package like Radzen.Blazor ships under _content/) when the environment is
// Development. The "production-data (local)" profile runs as Production to load real data,
// which otherwise 404s all of that CSS/JS. Force it on so local runs stay styled regardless
// of environment. A real `dotnet publish` deployment copies these assets into wwwroot directly,
// so this call is a no-op there.
builder.WebHost.UseStaticWebAssets();

// Git-ignored, machine-local override (see .gitignore) - lets a real production connection string
// live on disk for local "run against production data" use without ever risking a commit. Takes
// priority over everything else, including env vars, so it only affects whoever created the file.
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.local.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options =>
    {
        options.DetailedErrors = builder.Environment.IsDevelopment();
    });

builder.Services.AddRadzenComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var jarvisConnectionString = builder.Configuration.GetConnectionString("JarvisConnection") ?? throw new InvalidOperationException("Connection string 'JarvisConnection' not found.");

// The Jarvis database runs at SQL Server compatibility level 110, which predates OPENJSON (130+).
// Without UseCompatibilityLevel, EF Core 8 translates List<T>.Contains(...) filters using OPENJSON
// and every such query fails with "Incorrect syntax near '$'".
// EnableRetryOnFailure guards against transient network blips (e.g. "the specified network name is
// no longer available") by automatically retrying instead of throwing.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(jarvisConnectionString, sql => sql.UseCompatibilityLevel(110).EnableRetryOnFailure()));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Blazor Server keeps one DI scope for the life of a circuit, so a plain scoped DbContext gets
// shared across every UI interaction and throws "A second operation was started on this context"
// whenever two events overlap. Register a factory so components/services can spin up a fresh
// short-lived context per operation; also expose a scoped JarvisDbContext (built from that factory)
// so the other services that inject it directly keep working unchanged.
builder.Services.AddDbContextFactory<JarvisDbContext>(options =>
    options.UseSqlServer(jarvisConnectionString, sql => sql.UseCompatibilityLevel(110).EnableRetryOnFailure()));
builder.Services.AddScoped<JarvisDbContext>(sp =>
    sp.GetRequiredService<IDbContextFactory<JarvisDbContext>>().CreateDbContext());

builder.Services.AddScoped<MxReconciliationService>();
builder.Services.AddScoped<JarvisPaymentInsertService>();
builder.Services.AddScoped<PaymentSearchService>();
builder.Services.AddScoped<EmvLogAnalysisService>();
builder.Services.AddScoped<DatabaseChecksService>();
builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<LoggedInUsersService>();
builder.Services.AddHttpClient<MxPaymentLookupService>();
builder.Services.AddHttpClient<EmailStatusService>();

// RequireConfirmedAccount is off because there's no real email sender configured (IdentityNoOpEmailSender
// below is a stub) and accounts are created directly by an admin, not via public self-registration.
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    await IdentitySeed.SeedInitialAdminUserAsync(scope.ServiceProvider, app.Configuration, logger);
}

app.Run();
