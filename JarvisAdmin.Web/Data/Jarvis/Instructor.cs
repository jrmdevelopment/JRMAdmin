using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Instructor
{
    public int InstructorKey { get; set; }

    public int OrganizationKey { get; set; }

    public string InstructorName { get; set; } = null!;

    public string? InstructorAddr { get; set; }

    public string? InstructorCity { get; set; }

    public string? InstructorSt { get; set; }

    public string? InstructorZip { get; set; }

    public string? InstructorEmail { get; set; }

    public byte[]? InstructorEpassword { get; set; }

    public string? InstructorContactPhone { get; set; }

    public DateTime DateEntered { get; set; }

    public string InstructorStatus { get; set; } = null!;

    public string? InstructorNotes { get; set; }

    public decimal? InstructorPercentage { get; set; }

    public string? InstructorClasses { get; set; }

    public decimal? InstructorFlatRate { get; set; }

    public string? ServiceAgreementFileName { get; set; }

    public DateTime? ServiceAgreementExpiration { get; set; }

    public int? VerificationCode { get; set; }

    public DateTime? VerificationCodeDate { get; set; }

    public byte[]? XServiceAgreementPdf { get; set; }

    public virtual ICollection<League> Leagues { get; set; } = new List<League>();
}
