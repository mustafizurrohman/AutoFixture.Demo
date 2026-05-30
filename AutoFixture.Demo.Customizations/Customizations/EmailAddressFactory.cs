using System.Globalization;
using System.Text;

namespace AutoFixture.Demo.Customizations.Customizations;

internal static class EmailAddressFactory
{
    private const string FallbackToken = "unknown";

    private static readonly string[] EmailProviderDomains =
    [
        "gmail.com",
        "outlook.com",
        "yahoo.com",
        "icloud.com",
        "hotmail.com"
    ];

    public static string CreateFor(Models.Person person)
    {
        ArgumentNullException.ThrowIfNull(person);

        var firstName = ToEmailToken(person.FirstName);
        var lastName = ToEmailToken(person.LastName);
        var domain = GetRandomEmailProviderDomain();

        return $"{firstName}.{lastName}@{domain}";
    }

    private static string GetRandomEmailProviderDomain()
    {
        var index = Random.Shared.Next(EmailProviderDomains.Length);

        return EmailProviderDomains[index];
    }

    private static string ToEmailToken(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return FallbackToken;
        }

        var builder = new StringBuilder();
        var normalizedValue = value.Trim().Normalize(NormalizationForm.FormD);
        var previousWasSeparator = false;

        foreach (var character in normalizedValue.Where(character =>
                     CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark))
        {
            if (char.IsLetterOrDigit(character))
            {
                builder.Append(char.ToLowerInvariant(character));
                previousWasSeparator = false;
                continue;
            }

            if (previousWasSeparator || builder.Length == 0)
            {
                continue;
            }

            builder.Append('.');
            previousWasSeparator = true;
        }

        var token = builder
            .ToString()
            .Trim('.');

        return string.IsNullOrWhiteSpace(token)
            ? FallbackToken
            : token;
    }
}