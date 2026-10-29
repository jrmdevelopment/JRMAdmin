using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAccountAftercare
{
    public int AuditAftercareKey { get; set; }

    public int AccountAftercareKey { get; set; }

    public int OrganizationKey { get; set; }

    public int AccountKey { get; set; }

    public string EnteredBy { get; set; } = null!;

    public string EmergencyContactRelationship { get; set; } = null!;

    public string AccountHolder1Employer { get; set; } = null!;

    public string? AccountHolder2Employer { get; set; }

    public string? InsuranceCompany { get; set; }

    public string? InsurancePolicyNbr { get; set; }

    public string? EmergencyContact2 { get; set; }

    public string? EmergencyContactPhone2 { get; set; }

    public string? EmergencyContactRelationship2 { get; set; }

    public string? ChildPickupName1 { get; set; }

    public string? ChildPickupAddr1 { get; set; }

    public string? ChildPickupPhone1 { get; set; }

    public string? ChildPickupName2 { get; set; }

    public string? ChildPickupAddr2 { get; set; }

    public string? ChildPickupPhone2 { get; set; }

    public string? ChildPickupName3 { get; set; }

    public string? ChildPickupAddr3 { get; set; }

    public string? ChildPickupPhone3 { get; set; }

    public string? ChildPickupName4 { get; set; }

    public string? ChildPickupAddr4 { get; set; }

    public string? ChildPickupPhone4 { get; set; }

    public DateTime? LastVerified { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
