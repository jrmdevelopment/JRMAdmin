using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebBoard
{
    public int BoardKey { get; set; }

    public int OrganizationKey { get; set; }

    public string? BoardMemberStatus { get; set; }

    public string MemberName { get; set; } = null!;

    public string MemberRole { get; set; } = null!;

    public string? RoleDescLine1 { get; set; }

    public string? RoleDescLine2 { get; set; }

    public string? MemberEmail { get; set; }

    public string? MemberPhone { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
