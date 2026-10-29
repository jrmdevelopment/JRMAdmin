using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MxmerchantBatchTxn
{
    public int MxmerchantBatchTxnKey { get; set; }

    public int OrganizationKey { get; set; }

    public decimal Amount { get; set; }

    public string Authcode { get; set; } = null!;

    public string Batch { get; set; } = null!;

    public long BatchId { get; set; }

    public DateTime DateAdded { get; set; }

    public string CreatedByDevice { get; set; } = null!;

    public string? DeviceId { get; set; }

    public string? PaymentId { get; set; }

    public decimal? OriginalAmount { get; set; }

    public string? PaymentToken { get; set; }

    public string? ReferenceNbr { get; set; }

    public DateTime? SettleDate { get; set; }

    public decimal? SettledAmount { get; set; }

    public string? SettledSource { get; set; }

    public string? TransactionStatus { get; set; }

    public bool ReconciledWithJarvis { get; set; }
}
