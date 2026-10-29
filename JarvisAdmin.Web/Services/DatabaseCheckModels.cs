namespace JarvisAdmin.Web.Services;

// Shape shared by every database-check stored procedure (matches the #TempPayments layout the
// stored procedures already return: OrganizationName, SystemArea, DatabaseCheck, DatabaseKey,
// Field1, Field2). Materialized via EF Core's Database.SqlQuery<T>, which requires a settable POCO.
public class DatabaseCheckRow
{
    public string OrganizationName { get; set; } = null!;
    public string SystemArea { get; set; } = null!;
    public string DatabaseCheck { get; set; } = null!;
    public int DatabaseKey { get; set; }
    public string? Field1 { get; set; }
    public string? Field2 { get; set; }
}

// Sponsor-area check result. Wider than DatabaseCheckRow so each row carries the sponsor and
// pledge details needed to research the problem without a second lookup. Pledge fields are
// null for sponsor-level problems (duplicate sponsor).
public class SponsorCheckRow
{
    public string Problem { get; set; } = null!;
    public string? Details { get; set; }
    public string OrganizationName { get; set; } = null!;
    public int SponsorKey { get; set; }
    public string SponsorName { get; set; } = null!;
    public string SponsorStatus { get; set; } = null!;
    public string ContactName { get; set; } = null!;
    public string ContactPhoneNbr { get; set; } = null!;
    public string? ContactEmail { get; set; }
    public int? PaymentSponsorKey { get; set; }
    public string? PledgeType { get; set; }
    public decimal? SponsorAmount { get; set; }
    public decimal? PaymentAmount { get; set; }
    public decimal? ConvenienceFee { get; set; }
    public decimal? RefundAmount { get; set; }
    public DateTime? SponsorshipAdded { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentType { get; set; }
    public string? ConfirmationNbr { get; set; }
}

// Result shape of the shift_bypaymenttype stored procedure.
internal class PaymentTypeTotal
{
    public string? PaymentType { get; set; }
    public decimal? TotalReceived { get; set; }
}
