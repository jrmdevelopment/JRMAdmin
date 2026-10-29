using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class JarvisAdminUser
{
    public int JarvisAdminUserKey { get; set; }

    public string UserName { get; set; } = null!;

    public byte[]? UserPassword { get; set; }

    public string? UserFullName { get; set; }

    public string? EmailAddress { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LastLogin { get; set; }
}
