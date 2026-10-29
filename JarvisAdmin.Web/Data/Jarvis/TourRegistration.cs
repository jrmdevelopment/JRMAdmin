using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TourRegistration
{
    public int TourRegistrationKey { get; set; }

    public int OrganizationKey { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? FirstName2 { get; set; }

    public string? LastName2 { get; set; }

    public DateOnly? BirthDate2 { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? EmergencyContactName { get; set; }

    public int TourTypeItemKey { get; set; }

    public bool? BringOwnKayak { get; set; }

    public DateTime TourDateTime { get; set; }

    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public decimal ConvenienceFee { get; set; }

    public int NbrOfPersons { get; set; }

    public int? NbrOfHours { get; set; }

    public string? SpecialRequest { get; set; }

    public DateTime? CheckedOutTime { get; set; }

    public DateTime? CheckedInTime { get; set; }

    public DateTime BookingDateTime { get; set; }

    public string? StaffNotes { get; set; }

    public string? GroupName { get; set; }

    public virtual ICollection<PaymentTourRegistration> PaymentTourRegistrations { get; set; } = new List<PaymentTourRegistration>();

    public virtual TourTypeItem TourTypeItemKeyNavigation { get; set; } = null!;
}
