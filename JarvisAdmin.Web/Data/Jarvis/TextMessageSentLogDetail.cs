using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TextMessageSentLogDetail
{
    public int TextMessageSentLogDetailKey { get; set; }

    public int OrganizationKey { get; set; }

    public int TextMessageSentLogKey { get; set; }

    public string CellPhone { get; set; } = null!;

    public string? Recipient { get; set; }

    public string? TextMessage { get; set; }

    public int? AccountKey { get; set; }

    public int? TeamKey { get; set; }

    public string? MessageId { get; set; }

    public string? Smsreturn { get; set; }

    public string? MessageIdStopped { get; set; }

    public virtual Account? AccountKeyNavigation { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual TextMessageSentLog TextMessageSentLogKeyNavigation { get; set; } = null!;
}
