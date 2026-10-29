using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class StatementDetail
{
    public int StatementDetailKey { get; set; }

    public int StatementKey { get; set; }

    public string ProgramName { get; set; } = null!;

    public int? NumberBilled { get; set; }

    public decimal? BilledAmount { get; set; }

    public decimal? BillRate { get; set; }

    public decimal? RegistrationPercentTotal { get; set; }

    public string? RevenueCode { get; set; }

    public int? SeasonKey { get; set; }

    public virtual Statement StatementKeyNavigation { get; set; } = null!;
}
