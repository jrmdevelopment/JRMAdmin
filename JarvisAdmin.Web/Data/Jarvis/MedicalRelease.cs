using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MedicalRelease
{
    public int MedicalReleaseKey { get; set; }

    public int AccountKey { get; set; }

    public int RegistrantKey { get; set; }

    public string ParentGuardian1Name { get; set; } = null!;

    public string ParentGuardian1Relationship { get; set; } = null!;

    public string? ParentGuardian2Name { get; set; }

    public string? ParentGuardian2Relationship { get; set; }

    public string PlayersAddress { get; set; } = null!;

    public string PlayersCity { get; set; } = null!;

    public string PlayersState { get; set; } = null!;

    public string PlayersZipCode { get; set; } = null!;

    public string PrimaryPhone { get; set; } = null!;

    public string? AlternatePhone1 { get; set; }

    public string? AlternatePhone2 { get; set; }

    public string? EmailAddress { get; set; }

    public bool AuthorizeChildToBeTreated { get; set; }

    public string FamilyPhysician { get; set; } = null!;

    public string PhysicianPhone { get; set; } = null!;

    public string PhysicianAddress { get; set; } = null!;

    public string PhysicianCity { get; set; } = null!;

    public string PhysicianState { get; set; } = null!;

    public string HospitalPreference { get; set; } = null!;

    public string ParentInsuranceCo { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public string GroupId { get; set; } = null!;

    public string? LeagueInsuranceCo { get; set; }

    public string? LeaguePolicyNumber { get; set; }

    public string? LeagueGroupId { get; set; }

    public string EmergencyContact1Name { get; set; } = null!;

    public string EmergencyContact1Phone { get; set; } = null!;

    public string EmergencyContact1Relationship { get; set; } = null!;

    public string EmergencyContact2Name { get; set; } = null!;

    public string EmergencyContact2Phone { get; set; } = null!;

    public string EmergencyContact2Relationship { get; set; } = null!;

    public DateTime? DateOfLastTetanusBooster { get; set; }

    public string? MedicalDiagnosis1 { get; set; }

    public string? Medication1 { get; set; }

    public string? Dosage1 { get; set; }

    public string? FrequencyOfDosage1 { get; set; }

    public string? MedicalDiagnosis2 { get; set; }

    public string? Medication2 { get; set; }

    public string? Dosage2 { get; set; }

    public string? FrequencyOfDosage2 { get; set; }

    public string? MedicalDiagnosis3 { get; set; }

    public string? Medication3 { get; set; }

    public string? Dosage3 { get; set; }

    public string? FrequencyOfDosage3 { get; set; }

    public string? MedicalDiagnosis4 { get; set; }

    public string? Medication4 { get; set; }

    public string? Dosage4 { get; set; }

    public string? FrequencyOfDosage4 { get; set; }

    public string EnteredBy { get; set; } = null!;

    public DateTime DateEntered { get; set; }

    public DateTime LastVerified { get; set; }

    public string LastUpdatedBy { get; set; } = null!;
}
