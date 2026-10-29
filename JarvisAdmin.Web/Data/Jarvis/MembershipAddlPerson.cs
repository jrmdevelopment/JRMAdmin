using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipAddlPerson
{
    public int MembershipAddlPersonKey { get; set; }

    public int MembershipKey { get; set; }

    public string AddlPersonFirstName { get; set; } = null!;

    public string AddlPersonLastName { get; set; } = null!;

    public DateTime? AddlPersonBirthDate { get; set; }

    public string? RelationshipToMember { get; set; }

    public string AddlPersonStatus { get; set; } = null!;

    public virtual Membership MembershipKeyNavigation { get; set; } = null!;
}
