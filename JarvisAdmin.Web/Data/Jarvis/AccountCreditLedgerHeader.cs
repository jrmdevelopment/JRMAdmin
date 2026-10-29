using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountCreditLedgerHeader
{
    public int AccountCreditLedgerHeaderKey { get; set; }

    public int OrganizationKey { get; set; }

    public int AccountKey { get; set; }

    public string CreditSourceType { get; set; } = null!;

    public int? SourceKey { get; set; }

    public decimal CreditAmount { get; set; }

    public decimal CreditBalanceRemaining { get; set; }

    public string? RevenueCode { get; set; }

    public string CreditStatus { get; set; } = null!;

    public DateTime DateCreditGiven { get; set; }

    public string CreditDescription { get; set; } = null!;

    public string LastUpdatedBy { get; set; } = null!;

    public DateTime LastUpdatedDate { get; set; }
}
