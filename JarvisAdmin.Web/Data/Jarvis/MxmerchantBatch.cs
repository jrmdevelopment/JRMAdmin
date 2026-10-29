using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MxmerchantBatch
{
    public int MxmerchantBatchKey { get; set; }

    public int OrganizationKey { get; set; }

    public string BatchId { get; set; } = null!;

    public DateTime? BatchOpenDate { get; set; }

    public DateTime? BatchCloseDate { get; set; }

    public decimal MxmerchantAmount { get; set; }

    public decimal JarvisAmount { get; set; }

    public bool Emvterminal { get; set; }

    public string? DiscrepancyComments { get; set; }

    public long? BatchNumber { get; set; }
}
