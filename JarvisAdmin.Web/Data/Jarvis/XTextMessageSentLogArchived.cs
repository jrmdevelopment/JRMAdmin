using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XTextMessageSentLogArchived
{
    public int TextMessageSentLogKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime DateSent { get; set; }

    public string? TextMessage { get; set; }

    public string SentBy { get; set; } = null!;

    public string ScreenSentFrom { get; set; } = null!;

    public int? NbrToSend { get; set; }

    public string? TypeOfSend { get; set; }

    public int? NumberSent { get; set; }

    public string? TextSubject { get; set; }

    public string? AddlInfo { get; set; }

    public int? GroupId { get; set; }

    public int? SeasonKey { get; set; }

    public int? LeagueKey { get; set; }

    public int? TeamKey { get; set; }
}
