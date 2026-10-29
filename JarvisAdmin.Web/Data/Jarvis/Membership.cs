using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Membership
{
    public int MembershipKey { get; set; }

    public int OrganizationKey { get; set; }

    public int AccountKey { get; set; }

    public string MemberFirstName { get; set; } = null!;

    public string MemberLastName { get; set; } = null!;

    public string? MemberAddress { get; set; }

    public string? MemberCity { get; set; }

    public string? MemberState { get; set; }

    public string? MemberZipcode { get; set; }

    public string? MemberPhone { get; set; }

    public string? MemberAlternatePhone { get; set; }

    public string? MemberEmailAddr { get; set; }

    public DateTime? MemberBirthDate { get; set; }

    public string? PlaceOfEmployment { get; set; }

    public string EnteredBy { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public DateTime? ReminderEmailSent { get; set; }

    public string? RecurringPaymentRegistrationNbr { get; set; }

    public string? RecurringPaymentToken { get; set; }

    public byte[]? RecurringPaymentLastFour { get; set; }

    public string? RecurringPaymentType { get; set; }

    public string? RecurringPaymentAddedBy { get; set; }

    public DateTime? RecurringPaymentAddedDate { get; set; }

    public DateTime? RecurringPaymentCancelDate { get; set; }

    public string? RecurringPaymentCancelBy { get; set; }

    public string MonthlyBankDraft { get; set; } = null!;

    public DateTime? MonthlyBankDraftCancelDate { get; set; }

    public DateTime? MonthlyBankDraftStartDate { get; set; }

    public string? MonthlyBankDraftCancelBy { get; set; }

    public string? LastUpdatedBy { get; set; }

    public bool? MonthlyRecurringBilling { get; set; }

    public int? MxVaultedCustomerId { get; set; }

    public virtual ICollection<MembershipAddlPerson> MembershipAddlPeople { get; set; } = new List<MembershipAddlPerson>();

    public virtual ICollection<MembershipDetail> MembershipDetails { get; set; } = new List<MembershipDetail>();

    public virtual ICollection<MembershipId> MembershipIds { get; set; } = new List<MembershipId>();

    public virtual ICollection<MembershipScanLog> MembershipScanLogs { get; set; } = new List<MembershipScanLog>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
