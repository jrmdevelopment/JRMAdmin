using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Registrant
{
    public int RegistrantKey { get; set; }

    public int AccountKey { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }

    public DateTime DateEntered { get; set; }

    public string EnteredBy { get; set; } = null!;

    public string RegistrantStatus { get; set; } = null!;

    public string? MedicalConditions { get; set; }

    public bool Over18 { get; set; }

    public bool BirthCertificateOnFile { get; set; }

    public string? ParticipantPhysician { get; set; }

    public string? PhysicianPhoneNbr { get; set; }

    public string? HospitalChoice { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? SpecialNeeds { get; set; }

    public virtual Account AccountKeyNavigation { get; set; } = null!;

    public virtual ICollection<AccountToDocument> AccountToDocuments { get; set; } = new List<AccountToDocument>();

    public virtual ICollection<RegistrantToLeague> RegistrantToLeagues { get; set; } = new List<RegistrantToLeague>();
}
