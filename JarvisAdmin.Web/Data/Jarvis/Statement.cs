using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Statement
{
    public int StatementKey { get; set; }

    public int OrganizationKey { get; set; }

    public string StatementName { get; set; } = null!;

    public DateTime StatementDate { get; set; }

    public decimal TotalInvoice { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<StatementDetail> StatementDetails { get; set; } = new List<StatementDetail>();
}
