using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CoachApplication
{
    public int CoachApplicationKey { get; set; }

    public int AccountKey { get; set; }

    public int LeagueKey { get; set; }

    public int SeasonKey { get; set; }

    public DateTime DateAdded { get; set; }

    public string TypeOfApplication { get; set; } = null!;

    /// <summary>
    /// (S)ubmitted, (A)ctive, (I)nactive, (D)enied
    /// </summary>
    public string ApplicationStatus { get; set; } = null!;

    public string CoachFirstName { get; set; } = null!;

    public string CoachLastName { get; set; } = null!;

    public string EmailAddr { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public int? YearsInState { get; set; }

    public string? PlayerToCoach { get; set; }

    public string? RelationshipToPlayer { get; set; }

    public string? Employer { get; set; }

    public string? EmployerAddress { get; set; }

    public string? Occupation { get; set; }

    public string EverSuspended { get; set; } = null!;

    public string? ReferenceName1 { get; set; }

    public string? ReferencePhone1 { get; set; }

    public string? ReferenceName2 { get; set; }

    public string? ReferencePhone2 { get; set; }

    public string? ReferenceName3 { get; set; }

    public string? ReferencePhone3 { get; set; }

    public string VolunteerCapacity { get; set; } = null!;

    public string? PreviousAddress { get; set; }

    public string? PreviousCity { get; set; }

    public string? PreviousState { get; set; }

    public string? PreviousZip { get; set; }

    public bool AgreeToVolunteerWaiver { get; set; }

    public byte[]? EncryptedSsn { get; set; }

    public string CriminalOffense { get; set; } = null!;

    public string? ImageFileName { get; set; }

    public string? PassBackgroundCheck { get; set; }

    public string? BackgroundCheckBy { get; set; }

    public DateTime? DateOfBgcheck { get; set; }

    public string? BackgroundExplain { get; set; }

    public string? CommentsFromReviewer { get; set; }

    public DateTime? CoachAppEmail { get; set; }

    public DateTime? ConfirmedDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentType { get; set; }

    public decimal? PaymentAmount { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? PaymentPostedBy { get; set; }

    public int? ShiftKey { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public int? GroupId { get; set; }

    public int? MerchantBatchId { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? PaymentComments { get; set; }

    public DateTime? CodeOfConductDate { get; set; }

    public virtual Account AccountKeyNavigation { get; set; } = null!;

    public virtual ICollection<CoachToCustomQuestion> CoachToCustomQuestions { get; set; } = new List<CoachToCustomQuestion>();

    public virtual League LeagueKeyNavigation { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }

    public virtual ICollection<TeamToCoach> TeamToCoaches { get; set; } = new List<TeamToCoach>();
}
