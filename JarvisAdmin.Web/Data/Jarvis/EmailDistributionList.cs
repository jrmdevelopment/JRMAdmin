using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class EmailDistributionList
{
    public int EmailDistributionListKey { get; set; }

    public int OrganizationKey { get; set; }

    public string DistributionListName { get; set; } = null!;

    public string DistributionListStatus { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public virtual ICollection<EmailDistributionListDetail> EmailDistributionListDetails { get; set; } = new List<EmailDistributionListDetail>();
}
