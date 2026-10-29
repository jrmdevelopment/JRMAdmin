using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditMembership
{
    public int AuditMembershipKey { get; set; }

    public int MembershipKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? AccountKey { get; set; }

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

    public string? MembershipNotes { get; set; }

    public string EnteredBy { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public DateTime? ReminderEmailSent { get; set; }

    public string? RecurringPaymentRegistrationNbr { get; set; }

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

    public bool? MonthlyRecurringBilling { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
