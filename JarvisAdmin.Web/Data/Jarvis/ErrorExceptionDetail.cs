using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ErrorExceptionDetail
{
    public int ErrorExceptionDetailKey { get; set; }

    public int? ErrorExceptionKey { get; set; }

    public string? FieldName { get; set; }

    public string? FieldValue { get; set; }

    public virtual ErrorException? ErrorExceptionKeyNavigation { get; set; }
}
