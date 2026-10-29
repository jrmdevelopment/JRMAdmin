using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SpecialEvent
{
    public int SpecialEventKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SpecialEventConfigureKey { get; set; }

    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ResidentNonResident { get; set; }

    public string HomeAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public DateTime DateOfSale { get; set; }

    public string SaleAddedBy { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<PaymentSpecialEvent> PaymentSpecialEvents { get; set; } = new List<PaymentSpecialEvent>();

    public virtual SpecialEventConfigure SpecialEventConfigureKeyNavigation { get; set; } = null!;

    public virtual ICollection<SpecialEventItemPurchase> SpecialEventItemPurchases { get; set; } = new List<SpecialEventItemPurchase>();
}
