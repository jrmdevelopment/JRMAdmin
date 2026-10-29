using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ApplicationError
{
    public int ApplicationErrorKey { get; set; }

    public int OrganizationKey { get; set; }

    public string? UserName { get; set; }

    public string PageName { get; set; } = null!;

    public string? StatusText { get; set; }

    public string? ResponseText { get; set; }

    public string? ResponseData { get; set; }

    public string? ErrorThrown { get; set; }

    public string? UserAgent { get; set; }

    public string ErrorType { get; set; } = null!;

    public string ErrorMessage { get; set; } = null!;

    public string Browser { get; set; } = null!;

    public string OperatingSystem { get; set; } = null!;

    public DateTime DateTimeStamp { get; set; }
}
