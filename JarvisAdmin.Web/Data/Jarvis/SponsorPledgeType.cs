using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SponsorPledgeType
{
    public int SponsorPledgeTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? SponsorProgramKey { get; set; }

    public string? SponsorPledgeType1 { get; set; }

    public string SponsorPledgeTypeDesc { get; set; } = null!;

    public decimal SponsorPledgeTypeAmount { get; set; }

    public string SponsorPledgeTypeStatus { get; set; } = null!;

    public virtual ICollection<SponsorPledgeDetail> SponsorPledgeDetails { get; set; } = new List<SponsorPledgeDetail>();

    public virtual SponsorProgram? SponsorProgramKeyNavigation { get; set; }
}
