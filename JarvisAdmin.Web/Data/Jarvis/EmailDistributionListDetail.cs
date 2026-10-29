using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class EmailDistributionListDetail
{
    public int EmailDistributionListDetailKey { get; set; }

    public int EmailDistributionListKey { get; set; }

    public string DistributionEmailAddr { get; set; } = null!;

    public string? NameOfIndividual { get; set; }

    public virtual EmailDistributionList EmailDistributionListKeyNavigation { get; set; } = null!;
}
