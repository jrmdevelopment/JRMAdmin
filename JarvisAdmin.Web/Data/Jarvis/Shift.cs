using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Shift
{
    public int ShiftKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime ShiftStartDate { get; set; }

    public DateTime? ShiftEndDate { get; set; }

    public decimal BeginningBalance { get; set; }

    public decimal? DrawerTotalCash { get; set; }

    public decimal? DrawerTotalCreditCard { get; set; }

    public decimal? DrawerTotalChecks { get; set; }

    public decimal? ReceivablesInputTotal { get; set; }

    public string? ShiftComments { get; set; }

    public DateTime? BalancedOn { get; set; }

    public string ShiftStartName { get; set; } = null!;

    public string? ShiftEndName { get; set; }

    public string? ShiftBalancedName { get; set; }

    public DateTime? ShiftReleaseDate { get; set; }

    public Guid? ShiftStartUserId { get; set; }

    public int? ShiftLocationKey { get; set; }

    public Guid? ShiftEndUserId { get; set; }

    public Guid? ShiftBalanceUserId { get; set; }

    public virtual ICollection<AccountCredit> AccountCredits { get; set; } = new List<AccountCredit>();

    public virtual ICollection<AccountDonation> AccountDonations { get; set; } = new List<AccountDonation>();

    public virtual ICollection<CoachApplication> CoachApplications { get; set; } = new List<CoachApplication>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<PaymentFacility> PaymentFacilities { get; set; } = new List<PaymentFacility>();

    public virtual ICollection<PaymentLockerRental> PaymentLockerRentals { get; set; } = new List<PaymentLockerRental>();

    public virtual ICollection<PaymentMembership> PaymentMemberships { get; set; } = new List<PaymentMembership>();

    public virtual ICollection<PaymentMerchandise> PaymentMerchandises { get; set; } = new List<PaymentMerchandise>();

    public virtual ICollection<PaymentSeasonPass> PaymentSeasonPasses { get; set; } = new List<PaymentSeasonPass>();

    public virtual ICollection<PaymentSpecialEvent> PaymentSpecialEvents { get; set; } = new List<PaymentSpecialEvent>();

    public virtual ICollection<PaymentSponsor> PaymentSponsors { get; set; } = new List<PaymentSponsor>();

    public virtual ICollection<PaymentTeam> PaymentTeams { get; set; } = new List<PaymentTeam>();

    public virtual ICollection<PaymentVendor> PaymentVendors { get; set; } = new List<PaymentVendor>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PostransactionPayment> PostransactionPayments { get; set; } = new List<PostransactionPayment>();
}
