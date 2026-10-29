using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Services;

// Ports the old EmailStatusUpdate.aspx's "Blank Email Status" screen. The old page's update button
// never actually finished (it fetched from SendGrid but the result was never written back - see the
// commented-out attempts in EmailStatusUpdate.aspx.vb), so this fills in the missing half: for each
// EmailSentLogDetail row still missing a status, look up that recipient's latest activity from
// SendGrid's Email Activity API (the same api.sendgrid.com host/key the old app's working bounce/spam/
// block handlers in CommonMethods.aspx.vb already use) and write the result back onto the row.
public class EmailStatusService(JarvisDbContext db, HttpClient httpClient, IConfiguration configuration)
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    // Only check yesterday's and today's sends for status updates.
    private const int LookbackDays = 1;

    // The Email Activity API rate-limits aggressively. Retry a 429 a few times with backoff before
    // giving up on that recipient - otherwise a throttled call was indistinguishable from a genuine
    // "no activity found" and the row would get silently marked as such despite never being looked up.
    private const int MaxRateLimitRetries = 5;
    private static readonly TimeSpan RateLimitFallbackDelay = TimeSpan.FromSeconds(2);

    // How many successful updates to accumulate before persisting, so a long-running batch doesn't
    // lose everything if it gets interrupted partway through.
    private const int SaveBatchSize = 25;

    // Each row costs a live SendGrid call (plus possible rate-limit retries), so processing the full
    // backlog in one request times out well before it finishes. Cap it per click - the query re-selects
    // rows still missing status, so repeated clicks work through the backlog in bounded chunks.
    private const int UpdateBatchSize = 100;

    public async Task<List<EmailStatusRow>> GetEmailsWithNoStatusAsync()
    {
        return await (
            from d in db.EmailSentLogDetails
            join l in db.EmailSentLogs on d.EmailSentLogKey equals l.EmailSentLogKey
            join o in db.Organizations on l.OrganizationKey equals o.OrganizationKey
            where string.IsNullOrEmpty(d.EmailStatus) && d.EmailSentLogKey == 280694 // TEMP: scoped test run
            orderby l.DateSent descending
            select new EmailStatusRow
            {
                EmailSentLogDetailKey = d.EmailSentLogDetailKey,
                OrganizationName = o.OrganizationName,
                EmailAddressSent = d.EmailAddressSent,
                EmailSubject = l.EmailSubject,
                DateSent = l.DateSent
            }
        ).ToListAsync();
    }

    public async Task<EmailStatusUpdateResult> UpdateSendStatusAsync()
    {
        var apiKey = configuration["SendGrid:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
            return new EmailStatusUpdateResult(0, 0, 0, "SendGrid API key is not configured (SendGrid:ApiKey).");

        var pending = await (
            from d in db.EmailSentLogDetails
            join l in db.EmailSentLogs on d.EmailSentLogKey equals l.EmailSentLogKey
            where string.IsNullOrEmpty(d.EmailStatus) && d.EmailSentLogKey == 279834 // TEMP: scoped test run
            orderby d.EmailSentLogDetailKey
            select d
        ).Take(UpdateBatchSize).ToListAsync();

        var updated = 0;
        var notFound = 0;
        var rateLimited = 0;

        foreach (var detail in pending)
        {
            var result = await LookupLatestMessageAsync(detail.EmailAddressSent, apiKey);

            if (result.RateLimitExhausted)
            {
                rateLimited++;
                continue;
            }

            if (result.Message?.Status is null)
            {
                notFound++;
                continue;
            }

            ApplyStatus(detail, result.Message);
            updated++;

            // Save as we go rather than once at the end - a batch this size can take a long time
            // (SendGrid's Email Activity API is slow and rate-limited), and without this, an
            // interrupted run (closed page, disconnected circuit, etc.) would lose all progress.
            if (updated % SaveBatchSize == 0)
                await db.SaveChangesAsync();
        }

        await db.SaveChangesAsync();

        return new EmailStatusUpdateResult(updated, notFound, rateLimited, null);
    }

    // SendGrid's Email Activity API (GET /v3/messages) - the same host/auth scheme as the old app's
    // working suppression-list handlers, just a different endpoint. query uses SGQL, e.g. to_email="x".
    // limit=1 relies on the API's default newest-first ordering to get the most recent activity.
    //
    // This endpoint rate-limits hard (observed 429s within a handful of calls), so a 429 is retried
    // with backoff rather than treated as "no activity" - otherwise throttling looked identical to a
    // genuine miss and rows got marked not-found without ever being successfully looked up.
    private async Task<SendGridLookupResult> LookupLatestMessageAsync(string email, string apiKey)
    {
        var query = $"to_email=\"{email}\"";
        var url = $"https://api.sendgrid.com/v3/messages?limit=1&query={Uri.EscapeDataString(query)}";

        for (var attempt = 0; attempt <= MaxRateLimitRetries; attempt++)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            using var response = await httpClient.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                if (attempt == MaxRateLimitRetries)
                    return SendGridLookupResult.RateLimited;

                var delay = response.Headers.RetryAfter?.Delta ?? RateLimitFallbackDelay * (attempt + 1);
                await Task.Delay(delay);
                continue;
            }

            if (!response.IsSuccessStatusCode)
                return SendGridLookupResult.NotFound;

            var body = await response.Content.ReadAsStringAsync();
            var parsed = JsonSerializer.Deserialize<SendGridMessagesResponse>(body, JsonOptions);
            return new SendGridLookupResult(parsed?.Messages.FirstOrDefault(), RateLimitExhausted: false);
        }

        return SendGridLookupResult.RateLimited;
    }

    private static void ApplyStatus(EmailSentLogDetail detail, SendGridMessage message)
    {
        detail.EmailStatus = message.Status;
        detail.SendGridDateSent = message.LastEventTime;

        switch (message.Status)
        {
            case "delivered":
                detail.EmailDelivered = 1;
                break;
            case "bounce":
                detail.EmailBounced = 1;
                break;
            case "deferred":
                detail.EmailDeferred = 1;
                break;
            case "dropped":
                detail.EmailDropped = 1;
                break;
            case "spamreport":
                detail.EmailMarkedSpam = 1;
                break;
            case "unsubscribe":
            case "group_unsubscribe":
                detail.EmailUnsubscribe = 1;
                break;
        }

        // Opens are a separate signal from status (a delivered message can also have been opened).
        if (message.OpensCount > 0)
            detail.EmailOpened = 1;
    }

    private sealed record SendGridLookupResult(SendGridMessage? Message, bool RateLimitExhausted)
    {
        public static readonly SendGridLookupResult NotFound = new(null, RateLimitExhausted: false);
        public static readonly SendGridLookupResult RateLimited = new(null, RateLimitExhausted: true);
    }

    private sealed class SendGridMessagesResponse
    {
        [JsonPropertyName("messages")]
        public List<SendGridMessage> Messages { get; set; } = [];
    }

    private sealed class SendGridMessage
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("opens_count")]
        public int OpensCount { get; set; }

        [JsonPropertyName("last_event_time")]
        public DateTime? LastEventTime { get; set; }
    }
}
