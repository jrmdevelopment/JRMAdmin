using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class LockerRental
{
    public int LockerRentalKey { get; set; }

    public int? OrganizationKey { get; set; }

    public int LockerKey { get; set; }

    public string RenterFirstName { get; set; } = null!;

    public string RenterLastName { get; set; } = null!;

    public decimal RateApplied { get; set; }

    public decimal? DepositAmountPaid { get; set; }

    public decimal? DepositAmountReturned { get; set; }

    public bool IdonFile { get; set; }

    public bool? Idreturned { get; set; }

    public DateTime RentalStartDateTime { get; set; }

    public DateTime? RentalEndDateTime { get; set; }

    public string? RentalNotes { get; set; }

    public decimal TotalPaid { get; set; }

    public decimal TotalDue { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string? DepositWithheldReason { get; set; }

    public string? EnteredBy { get; set; }

    public string? RenterPhone { get; set; }

    public virtual Locker LockerKeyNavigation { get; set; } = null!;

    public virtual ICollection<PaymentLockerRental> PaymentLockerRentals { get; set; } = new List<PaymentLockerRental>();
}
