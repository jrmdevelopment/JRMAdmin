using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XEmailSentLogDetailArchived
{
    public int EmailSentLogDetailKey { get; set; }

    public int EmailSentLogKey { get; set; }

    public string EmailAddressSent { get; set; } = null!;

    public int? AccountKey { get; set; }

    public string? BadEmailReason { get; set; }

    public string? EmailContent { get; set; }

    public string? EmailStatus { get; set; }

    public string? EmailCategory { get; set; }

    public int EmailBounced { get; set; }

    public int EmailMarkedSpam { get; set; }

    public int EmailOpened { get; set; }

    public int EmailDeferred { get; set; }

    public int EmailDropped { get; set; }

    public int EmailDelivered { get; set; }

    public int EmailUnsubscribe { get; set; }

    public DateTime? ScdateSent { get; set; }

    public DateTime? SendGridDateSent { get; set; }

    public string? EmailOrigin { get; set; }
}
