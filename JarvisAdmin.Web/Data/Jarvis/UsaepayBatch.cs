using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class UsaepayBatch
{
    public string OrganizationKey { get; set; } = null!;

    public string BatchId { get; set; } = null!;

    public string? Seq { get; set; }

    public string? Opened { get; set; }

    public string? Closed { get; set; }

    public int? Count { get; set; }

    public decimal? Amount { get; set; }

    public decimal? OrgPaymentTotal { get; set; }

    public string? DiscrepancyComments { get; set; }
}
