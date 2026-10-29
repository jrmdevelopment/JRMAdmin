using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RecurringDebitAudit
{
    public int RecurringDebitAuditKey { get; set; }

    public int OrganizationKey { get; set; }

    public string RecurringDebitSource { get; set; } = null!;

    public DateTime DateOfTransaction { get; set; }

    public int ResponseCode { get; set; }

    public int MainTableKey { get; set; }

    public int? PaymentTableKey { get; set; }

    public decimal DebitAmount { get; set; }

    public int? ResponseReasonCode { get; set; }

    public string? ResponseReasonDesc { get; set; }

    public string? Resolution { get; set; }

    public string? ResolutionBy { get; set; }

    public DateTime? ResolutionDate { get; set; }
}
