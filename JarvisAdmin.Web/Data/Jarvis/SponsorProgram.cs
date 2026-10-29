using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SponsorProgram
{
    public int SponsorProgramKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ProgramName { get; set; } = null!;

    public string SponsorProgramStatus { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<SponsorPledgeType> SponsorPledgeTypes { get; set; } = new List<SponsorPledgeType>();
}
