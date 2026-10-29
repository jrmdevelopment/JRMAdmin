using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XSalesUser
{
    public int SalesUserKey { get; set; }

    public string SalesUserId { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Status { get; set; } = null!;
}
