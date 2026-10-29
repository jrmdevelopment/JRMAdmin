using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XEmailSentLogArchived
{
    public int EmailSentLogKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime DateSent { get; set; }

    public string EmailSubject { get; set; } = null!;

    public string? EmailBody { get; set; }

    public string SentBy { get; set; } = null!;

    public string? ReplyToEmail { get; set; }

    public string ScreenSentFrom { get; set; } = null!;

    public string? TypeOfSend { get; set; }

    public int? SeasonKey { get; set; }

    public int? LeagueKey { get; set; }

    public int? TeamKey { get; set; }

    public string? Attachment1Name { get; set; }

    public string? Attachment2Name { get; set; }

    public int? GroupId { get; set; }

    public string SendInBackground { get; set; } = null!;

    public string? EmailSendStatus { get; set; }

    public string? SendGridJson { get; set; }

    public string Archived { get; set; } = null!;
}
