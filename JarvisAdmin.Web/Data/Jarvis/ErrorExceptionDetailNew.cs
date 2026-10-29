using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ErrorExceptionDetailNew
{
    public int ErrorExceptionDetailNewKey { get; set; }

    public int? ErrorExceptionNewKey { get; set; }

    public string? FieldName { get; set; }

    public string? FieldValue { get; set; }

    public virtual ErrorExceptionNew? ErrorExceptionNewKeyNavigation { get; set; }
}
