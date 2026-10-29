using System.Data;
using System.Text;
using System.Text.Json;
using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Services;

// Looks up a transaction directly from MX Merchant's own API (not Jarvis), by resolving
// MxmerchantBatchTxn.PaymentId for a ReferenceNbr and calling MX Merchant's payment endpoint with
// that organization's API credentials - the same credentials/decryption/endpoint the main Jarvis2024
// app already uses (Common/PaymentService.vb: GetMerchantAccountKey/GetMerchantSecretKey,
// BuildMxBasicAuthHeader), ported here so this always hits MX's *production* API regardless of the
// legacy app's own sandbox/production toggle.
public class MxPaymentLookupService(JarvisDbContext db, HttpClient httpClient)
{
    private const string MxProductionBaseUrl = "https://api.mxmerchant.com/checkout/v3";

    public async Task<List<string>> GetPaymentIdsAsync(int organizationKey, string referenceNbr)
    {
        return await db.MxmerchantBatchTxns
            .Where(t => t.OrganizationKey == organizationKey && t.ReferenceNbr == referenceNbr && t.PaymentId != null)
            .Select(t => t.PaymentId!)
            .Distinct()
            .ToListAsync();
    }

    public async Task<MxPaymentLookupResult> LookupPaymentAsync(int organizationKey, string paymentId)
    {
        var authHeader = await BuildMxBasicAuthHeaderAsync(organizationKey);
        if (authHeader is null)
            return new MxPaymentLookupResult(paymentId, [], "No MX Merchant API credentials found for this organization.");

        using var request = new HttpRequestMessage(HttpMethod.Get, $"{MxProductionBaseUrl}/payment/{Uri.EscapeDataString(paymentId)}");
        request.Headers.Add("Authorization", authHeader);
        request.Headers.Add("Accept", "application/json");

        using var response = await httpClient.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return new MxPaymentLookupResult(paymentId, [], $"MX Merchant API returned HTTP {(int)response.StatusCode}: {body}");

        try
        {
            using var doc = JsonDocument.Parse(body);
            var fields = new List<MxFieldRow>();
            FlattenJson(doc.RootElement, "", fields);
            return new MxPaymentLookupResult(paymentId, fields, null);
        }
        catch (JsonException)
        {
            return new MxPaymentLookupResult(paymentId, [], $"Could not parse MX Merchant's response as JSON: {body}");
        }
    }

    public async Task<MxCustomerVaultLookupResult> LookupCustomerVaultAsync(int organizationKey, string customerId)
    {
        var authHeader = await BuildMxBasicAuthHeaderAsync(organizationKey);
        if (authHeader is null)
            return new MxCustomerVaultLookupResult(customerId, [], "No MX Merchant API credentials found for this organization.");

        using var request = new HttpRequestMessage(HttpMethod.Get, $"{MxProductionBaseUrl}/customercardaccount?id={Uri.EscapeDataString(customerId)}");
        request.Headers.Add("Authorization", authHeader);
        request.Headers.Add("Accept", "application/json");

        using var response = await httpClient.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return new MxCustomerVaultLookupResult(customerId, [], $"MX Merchant API returned HTTP {(int)response.StatusCode}: {body}");

        try
        {
            using var doc = JsonDocument.Parse(body);
            var fields = new List<MxFieldRow>();
            FlattenJson(doc.RootElement, "", fields);
            return new MxCustomerVaultLookupResult(customerId, fields, null);
        }
        catch (JsonException)
        {
            return new MxCustomerVaultLookupResult(customerId, [], $"Could not parse MX Merchant's response as JSON: {body}");
        }
    }

    private static void FlattenJson(JsonElement element, string path, List<MxFieldRow> fields)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                    FlattenJson(property.Value, path.Length == 0 ? property.Name : $"{path}.{property.Name}", fields);
                break;
            case JsonValueKind.Array:
                var index = 0;
                foreach (var item in element.EnumerateArray())
                {
                    FlattenJson(item, $"{path}[{index}]", fields);
                    index++;
                }
                break;
            default:
                fields.Add(new MxFieldRow(path, element.ValueKind == JsonValueKind.Null ? "" : element.ToString()));
                break;
        }
    }

    // Mirrors PaymentService.vb's BuildMxBasicAuthHeader: "Basic base64(apiKey:apiSecret)".
    private async Task<string?> BuildMxBasicAuthHeaderAsync(int organizationKey)
    {
        var (accountKey, secretKey) = await GetEncryptedMerchantKeysAsync(organizationKey);
        if (accountKey is null || secretKey is null)
            return null;

        var credentials = $"{accountKey}:{secretKey}";
        return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
    }

    // Mirrors OrganizationDB.GetEncryptedMerchant + PaymentService.vb's GetMerchantAccountKey/
    // GetMerchantSecretKey: calls org_encryptedmerchant and RC4-decrypts columns 2 (account/API key)
    // and 3 (secret key) with password "sorganizationc" + OrganizationKey. Column 1 (account nbr) is
    // read by the legacy code but never actually used in the final key, so it's skipped here too.
    private async Task<(string? AccountKey, string? SecretKey)> GetEncryptedMerchantKeysAsync(int organizationKey)
    {
        var connection = db.Database.GetDbConnection();
        var wasClosed = connection.State != ConnectionState.Open;
        if (wasClosed)
            await connection.OpenAsync();

        try
        {
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "org_encryptedmerchant";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@OrganizationKey";
            parameter.Value = organizationKey;
            command.Parameters.Add(parameter);

            using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
                return (null, null);

            var password = "sorganizationc" + organizationKey;

            var accountKey = reader.IsDBNull(2) ? null : Rc4Decrypt(password, Encoding.UTF8.GetString((byte[])reader.GetValue(2)));
            var secretKey = reader.IsDBNull(3) ? null : Rc4Decrypt(password, Encoding.UTF8.GetString((byte[])reader.GetValue(3)));

            return (accountKey, secretKey);
        }
        finally
        {
            if (wasClosed)
                await connection.CloseAsync();
        }
    }

    // Faithful port of DBAccessLayer/RC4Encrypt.vb - a symmetric RC4 stream cipher (same operation
    // encrypts and decrypts). Uses Microsoft.VisualBasic.Strings.Asc/Chr rather than a plain (char)
    // cast so byte values in the 128-255 range round-trip exactly as VB's Asc/Chr did, since the
    // stored ciphertext was itself produced through VB's Asc/Chr semantics.
    private static string Rc4Decrypt(string password, string cipherText)
    {
        var sbox = new int[256];
        var key = new int[256];
        var passwordLength = password.Length;

        for (var a = 0; a < 256; a++)
        {
            key[a] = Microsoft.VisualBasic.Strings.Asc(password[a % passwordLength]);
            sbox[a] = a;
        }

        var b = 0;
        for (var a = 0; a < 256; a++)
        {
            b = (b + sbox[a] + key[a]) % 256;
            (sbox[a], sbox[b]) = (sbox[b], sbox[a]);
        }

        var result = new StringBuilder(cipherText.Length);
        var i = 0;
        var j = 0;
        foreach (var ch in cipherText)
        {
            i = (i + 1) % 256;
            j = (j + sbox[i]) % 256;
            (sbox[i], sbox[j]) = (sbox[j], sbox[i]);

            var k = sbox[(sbox[i] + sbox[j]) % 256];
            var plainByte = Microsoft.VisualBasic.Strings.Asc(ch) ^ k;
            result.Append(Microsoft.VisualBasic.Strings.Chr(plainByte));
        }

        return result.ToString();
    }
}
