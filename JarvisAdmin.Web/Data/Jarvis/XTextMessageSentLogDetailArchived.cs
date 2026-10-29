using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XTextMessageSentLogDetailArchived
{
    public int TextMessageSentLogDetailKey { get; set; }

    public int OrganizationKey { get; set; }

    public int TextMessageSentLogKey { get; set; }

    public string CellPhone { get; set; } = null!;

    public string? MessageId { get; set; }

    public int? SeasonKey { get; set; }

    public int? LeagueKey { get; set; }

    public int? TeamKey { get; set; }

    public string? Recipient { get; set; }

    public string? Smsreturn { get; set; }

    public int? AccountKey { get; set; }

    public string? TextMessage { get; set; }

    public int? CdyneInvoiceId { get; set; }
}
