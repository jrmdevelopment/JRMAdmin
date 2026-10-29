using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ErrorFeedback
{
    public int AppErrorFeedbackKey { get; set; }

    public int OrganizationKey { get; set; }

    public string UserName { get; set; } = null!;

    public string ErrorDetails { get; set; } = null!;

    public DateTime DateAdded { get; set; }
}
