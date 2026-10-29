namespace JarvisAdmin.Web.Services;

public record MxPaymentLookupResult(string PaymentId, List<MxFieldRow> Fields, string? ErrorMessage);

public record MxCustomerVaultLookupResult(string CustomerId, List<MxFieldRow> Fields, string? ErrorMessage);

public record MxFieldRow(string Field, string Value);
