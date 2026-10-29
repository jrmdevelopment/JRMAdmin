using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountCreditReturnSource
{
    public int AccountCreditReturnSourceKey { get; set; }

    public int OrganizationKey { get; set; }

    public string SourceTable { get; set; } = null!;

    public int SourceTableKey { get; set; }

    public int? RegistrantToLeagueKey { get; set; }

    public int AccountCreditLedgerHeaderKey { get; set; }

    public string? CreditDescription { get; set; }

    public decimal ReturnAmount { get; set; }

    public DateTime ReturnDate { get; set; }

    public DateTime OriginPaymentDate { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public int? ShiftKey { get; set; }

    public string? FromRevenueCode { get; set; }

    public string? ToRevenueCode { get; set; }

    public string? PostedBy { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public string? ValorTxnId { get; set; }

    public DateTime DateCreated { get; set; }

    public int? TeamKey { get; set; }

    public int? FacilityReservationKey { get; set; }

    public int? SeasonPassKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }
}
