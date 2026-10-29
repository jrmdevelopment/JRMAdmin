using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityReservation
{
    public int FacilityReservationKey { get; set; }

    public int OrganizationKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public string ReservationStatus { get; set; } = null!;

    public string ReservationType { get; set; } = null!;

    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public decimal ReservationFeeCharged { get; set; }

    public decimal ReservationAdjustment { get; set; }

    public string? AdjustmentReason { get; set; }

    public decimal? MembershipDiscount { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal TotalRequiredFee { get; set; }

    public decimal TotalOptionalFee { get; set; }

    public decimal SalesTax { get; set; }

    public decimal SecurityDepositCharged { get; set; }

    public decimal SecurityDepositReturnAmt { get; set; }

    public string? SecurityDepositKeptReason { get; set; }

    public DateTime? SecurityDepositReturnDate { get; set; }

    public bool SecurityDepositPaid { get; set; }

    public bool SecurityDepositHeld { get; set; }

    public string? HeldDepositInformation { get; set; }

    public int? AccountKey { get; set; }

    public string ApplicantName { get; set; } = null!;

    public string? ApplicantAddress { get; set; }

    public string? ApplicantCity { get; set; }

    public string? ApplicantState { get; set; }

    public string? ApplicantZipCode { get; set; }

    public string? ApplicantContactPhone { get; set; }

    public string? ApplicantEmailAddress { get; set; }

    public DateTime DateOfReservation { get; set; }

    public DateTime StartTimeOfEvent { get; set; }

    public DateTime EndTimeOfEvent { get; set; }

    public string PurposeOfUse { get; set; } = null!;

    public string? ResidentNon { get; set; }

    public bool AlcoholPresent { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public bool InsuranceReceived { get; set; }

    public string? ReservationComments { get; set; }

    public int? TeamKey { get; set; }

    public int? NumberInGroup { get; set; }

    public int? MaximumCapacity { get; set; }

    public string? RoomConfiguration { get; set; }

    public bool ExemptFromCharge { get; set; }

    public bool? TextSent { get; set; }

    public DateTime? ReminderEmailSent { get; set; }

    public int? GroupId { get; set; }

    public int? AssociatedToReservationKey { get; set; }

    public Guid? CalendarActivityKey { get; set; }

    public int? RecurrenceKey { get; set; }

    public int? PrepCleanupTimeKey { get; set; }

    public string? RentalAgreement { get; set; }

    public string? AlcoholAgreement { get; set; }

    public string? NoAlcoholAgreement { get; set; }

    public string EnteredBy { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual ICollection<FacilityReservationOtherFee> FacilityReservationOtherFees { get; set; } = new List<FacilityReservationOtherFee>();

    public virtual FacilitySpace FacilitySpaceKeyNavigation { get; set; } = null!;

    public virtual ICollection<FacilityToCustomQuestion> FacilityToCustomQuestions { get; set; } = new List<FacilityToCustomQuestion>();

    public virtual ICollection<PaymentFacility> PaymentFacilities { get; set; } = new List<PaymentFacility>();
}
