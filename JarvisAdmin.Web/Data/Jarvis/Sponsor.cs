using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Sponsor
{
    public int SponsorKey { get; set; }

    public int OrganizationKey { get; set; }

    public string SponsorStatus { get; set; } = null!;

    public string SponsorName { get; set; } = null!;

    public string? SponsorAddress { get; set; }

    public string? SponsorCity { get; set; }

    public string? SponsorState { get; set; }

    public string? SponsorZip { get; set; }

    public string? SponsorPrimaryPhone { get; set; }

    public string? SponsorSecondaryPhone { get; set; }

    public string ContactName { get; set; } = null!;

    public string? ContactAddress { get; set; }

    public string? ContactCity { get; set; }

    public string? ContactState { get; set; }

    public string? ContactZip { get; set; }

    public string ContactPhoneNbr { get; set; } = null!;

    public string? ContactSecondaryPhone { get; set; }

    public string? ContactEmail { get; set; }

    public string? WebsiteAddress { get; set; }

    public DateTime SponsorSince { get; set; }

    public string? SponsorNotes { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? AddedBy { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<SponsorPledgeDetail> SponsorPledgeDetails { get; set; } = new List<SponsorPledgeDetail>();
}
