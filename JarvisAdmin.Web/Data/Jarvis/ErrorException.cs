using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ErrorException
{
    public int ErrorExceptionKey { get; set; }

    public int? OrganizationKey { get; set; }

    public string UserName { get; set; } = null!;

    public string PageName { get; set; } = null!;

    public string? Httpstatus { get; set; }

    public string? StatusText { get; set; }

    public string? ErrorMessage { get; set; }

    public string? ErrorThrown { get; set; }

    public string? StackTrace { get; set; }

    public string? UserAgent { get; set; }

    public DateTime DateTimeStamp { get; set; }

    public virtual ICollection<ErrorExceptionDetail> ErrorExceptionDetails { get; set; } = new List<ErrorExceptionDetail>();
}
