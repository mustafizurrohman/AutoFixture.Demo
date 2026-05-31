using Bogus;
using System.Globalization;
using System.Text;

namespace AutoFixture.Demo.Customizations.Customizations;

internal static class EmailAddressFactory
{
    private const string FallbackToken = "unknown";
    private const string FallbackDomain = "example.com";

    public static string CreateFor(
        Models.Person person,
        string localization = Localizations.DefaultLocalization)
    {
        ArgumentNullException.ThrowIfNull(person);

        var faker = CreateFaker(localization);

        var firstName = ToEmailToken(person.FirstName);
        var lastName = ToEmailToken(person.LastName);
        var birthYearSuffix = ToBirthYearSuffix(person.DateOfBirth);

        var localPart = CreateRandomLocalPart(
            faker,
            firstName,
            lastName,
            birthYearSuffix);

        var domain = GetLocalizedEmailProviderDomain(faker);

        return $"{localPart}@{domain}";
    }

    private static string CreateRandomLocalPart(
        Faker faker,
        string firstName,
        string lastName,
        string birthYearSuffix)
    {
        var nameOrders = new[]
        {
            new[] { firstName, lastName },
            new[] { lastName, firstName }
        };

        var separators = new[]
        {
            ".",
            "_",
            string.Empty
        };

        var includeBirthYearSuffixOptions = new[]
        {
            false,
            true
        };

        var formats = nameOrders
            .SelectMany(nameOrder => separators.Select(separator => string.Join(separator, nameOrder)))
            .SelectMany(namePart => includeBirthYearSuffixOptions.Select(includeBirthYearSuffix =>
                includeBirthYearSuffix
                    ? $"{namePart}{birthYearSuffix}"
                    : namePart))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        return formats[faker.Random.Int(0, formats.Length - 1)];
    }

    private static string ToBirthYearSuffix(DateTime dateOfBirth)
    {
        return dateOfBirth.ToString("yy", CultureInfo.InvariantCulture);
    }

    private static string GetLocalizedEmailProviderDomain(Faker faker)
    {
        var email = faker.Internet.Email();
        var atIndex = email.LastIndexOf('@');

        return atIndex >= 0 && atIndex < email.Length - 1
            ? email[(atIndex + 1)..].ToLowerInvariant()
            : FallbackDomain;
    }

    private static Faker CreateFaker(string localization)
    {
        try
        {
            return new Faker(ToBogusLocale(localization));
        }
        catch
        {
            return new Faker("en");
        }
    }

    private static string ToBogusLocale(string? localization)
    {
        if (string.IsNullOrWhiteSpace(localization))
        {
            return "en";
        }

        try
        {
            var culture = CultureInfo.GetCultureInfo(localization);

            return culture.Name switch
            {
                "de-DE" => "de",
                "de-AT" => "de_AT",
                "de-CH" => "de_CH",

                "en-US" => "en_US",
                "en-GB" => "en_GB",
                "en-AU" => "en_AU",
                "en-CA" => "en_CA",

                "fr-FR" => "fr",
                "fr-CA" => "fr_CA",

                "nl-NL" => "nl",
                "pt-BR" => "pt_BR",
                "pt-PT" => "pt_PT",

                _ => culture.TwoLetterISOLanguageName
            };
        }
        catch (CultureNotFoundException)
        {
            return "en";
        }
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