using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPass
{
    public int SeasonPassKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? AccountKey { get; set; }

    public string SeasonPassOrderStatus { get; set; } = null!;

    public int SeasonPassYear { get; set; }

    public int SeasonPassSetupKey { get; set; }

    public decimal SeasonPassPrice { get; set; }

    public decimal AdjustmentTotal { get; set; }

    public decimal ConvenienceFee { get; set; }

    /// <summary>
    /// SeasonPassPrice + AddlPersonTotal + ConvenienceFee
    /// </summary>
    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public string PassHolderFirstName { get; set; } = null!;

    public string PassHolderLastName { get; set; } = null!;

    public string? PassHolderEmail { get; set; }

    public string? PassHolderPhone { get; set; }

    public int NbrAllowedOnPass { get; set; }

    public bool Idverified { get; set; }

    public DateTime? DateAdded { get; set; }

    public string EnteredBy { get; set; } = null!;

    public string? AdjustmentReason { get; set; }

    public string? BarcodeNumber { get; set; }

    public DateOnly? PassholderBirthdate { get; set; }

    public string? FulfillmentChoice { get; set; }

    public string? MailingName { get; set; }

    public string? MailingAddress { get; set; }

    public string? MailingCity { get; set; }

    public string? MailingState { get; set; }

    public string? MailingZipCode { get; set; }

    public decimal PostageFee { get; set; }

    public decimal LostCardCharge { get; set; }

    public string? InactivateReason { get; set; }

    /// <summary>
    /// Pending, Mailed, Picked Up
    /// </summary>
    public string? FulfillmentStatus { get; set; }

    public DateTime? FulfillmentDate { get; set; }

    public string? FulfillmentBy { get; set; }

    public bool PhotoTaken { get; set; }

    public bool? PrepComplete { get; set; }

    public DateTime? ReminderEmailSent { get; set; }

    public decimal? AddOnFee { get; set; }

    public int? PrimarySeasonPassKey { get; set; }

    public decimal? AddlPersonTotal { get; set; }

    public virtual ICollection<PaymentSeasonPass> PaymentSeasonPasses { get; set; } = new List<PaymentSeasonPass>();

    public virtual ICollection<SeasonPassAddOn> SeasonPassAddOns { get; set; } = new List<SeasonPassAddOn>();

    public virtual ICollection<SeasonPassAddlPerson> SeasonPassAddlPeople { get; set; } = new List<SeasonPassAddlPerson>();

    public virtual ICollection<SeasonPassCheckin> SeasonPassCheckins { get; set; } = new List<SeasonPassCheckin>();

    public virtual ICollection<SeasonPassId> SeasonPassIds { get; set; } = new List<SeasonPassId>();

    public virtual SeasonPassSetup SeasonPassSetupKeyNavigation { get; set; } = null!;

    public virtual ICollection<XSeasonPassAdjustment> XSeasonPassAdjustments { get; set; } = new List<XSeasonPassAdjustment>();
}
