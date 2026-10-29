using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentInstructor
{
    public int PaymentInstructorKey { get; set; }

    public int InstructorKey { get; set; }

    public int LeagueKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? CheckNbr { get; set; }

    public string? CashReceiptNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public int? ShiftKey { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }
}
