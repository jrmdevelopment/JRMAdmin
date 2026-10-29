namespace JarvisAdmin.Web.Services;

public class EmailStatusRow
{
    public int EmailSentLogDetailKey { get; set; }
    public string OrganizationName { get; set; } = null!;
    public string EmailAddressSent { get; set; } = null!;
    public string EmailSubject { get; set; } = null!;
    public DateTime DateSent { get; set; }
}

public record EmailStatusUpdateResult(int Updated, int NotFound, int RateLimited, string? Error);
