using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuthorizeNetBatch
{
    public int AuthorizeNetBatchKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime SettleDate { get; set; }

    public double BatchId { get; set; }

    public decimal BatchTotal { get; set; }

    public decimal? JarvisBatchTotal { get; set; }

    public string? DifferenceComments { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
