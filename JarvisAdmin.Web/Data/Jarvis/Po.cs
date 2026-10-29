using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Po
{
    public int Poskey { get; set; }

    public int OrganizationKey { get; set; }

    public int PoscategoryKey { get; set; }

    public int PositemKey { get; set; }

    public string? ChargedTo { get; set; }

    public decimal? PriceEach { get; set; }

    public int? QuantityPurchased { get; set; }

    public decimal SalesTax { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public int GroupId { get; set; }

    public DateTime? DateTimeEntered { get; set; }

    public int? StatementKey { get; set; }

    public string EnteredBy { get; set; } = null!;

    public decimal TotalNsf { get; set; }

    public virtual ICollection<PaymentPo> PaymentPos { get; set; } = new List<PaymentPo>();

    public virtual Poscategory PoscategoryKeyNavigation { get; set; } = null!;

    public virtual Positem PositemKeyNavigation { get; set; } = null!;
}
