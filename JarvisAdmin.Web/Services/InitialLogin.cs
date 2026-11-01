using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace JarvisAdmin.Web.Services;

// The first login created alongside a new organization: a user in the main Jarvis app (Jarvis2024), saved the
// way its Security/AddModifyUser.aspx does it. Name goes to UserDetails.UserName and, as with
// aspnet_Roles_AddAdministrator's 'Jarvis Login', to the LastUpdatedBy/LastChangedBy columns of the new rows.
public class InitialLogin
{
    public string Name { get; set; } = "Jarvis Login";
    public string Email { get; set; } = "susan@jarvisrec.com";
    public string UserId { get; set; } = "";
    public string Password { get; set; } = "";

    // Matches minRequiredPasswordLength on the main app's membership provider (Jarvis2024 Web.config).
    public const int MinPasswordLength = 5;

    // Returns the first problem with the entered values, or null when they can be saved.
    public string? Validate()
    {
        if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(UserId) || string.IsNullOrEmpty(Password))
        {
            return "Please fill in all Initial Login fields before saving.";
        }
        if (!MailAddress.TryCreate(Email.Trim(), out _))
        {
            return "The Initial Login email address is not valid.";
        }
        if (Password.Length < MinPasswordLength)
        {
            return $"The Initial Login password must be at least {MinPasswordLength} characters.";
        }
        return null;
    }
}

// Reproduces how the main Jarvis app's SqlMembershipProvider stores a password, so a login created here can
// sign in there. Jarvis2024's Web.config sets no passwordFormat, hashAlgorithmType or passwordCompatMode, so
// the provider uses its defaults: Hashed (PasswordFormat 1), with Framework20 compatibility, which means a
// plain SHA-1 of the 16-byte random salt followed by the UTF-16 password, both stored base64-encoded.
public static class JarvisMembershipPassword
{
    public const int HashedPasswordFormat = 1;

    public static (string PasswordHash, string PasswordSalt) Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var passwordBytes = Encoding.Unicode.GetBytes(password);

        var saltedPassword = new byte[salt.Length + passwordBytes.Length];
        Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
        Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);

        return (Convert.ToBase64String(SHA1.HashData(saltedPassword)), Convert.ToBase64String(salt));
    }
}
