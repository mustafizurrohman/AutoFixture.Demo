using System.Collections.Immutable;
using AutoFixture.Demo.Core.Constants;
using AutoFixture.Demo.Tests.AssertionHelpers;

namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonContactTests(ITestOutputHelper outputHelper) 
    : TestBase(outputHelper)
{

    /// <summary>
    /// Possibility 1: personContacts will have 3 elements
    /// </summary>
    /// <param name="personContacts"></param>
    [Theory]
    [AutoDataCustom(Localizations.Dutch)]
    // [AutoDataPerson]
    public void VerifyThatComplexObjectsAreCorrectlyGenerated_Variant1(List<PersonContact> personContacts)
    {
        PrintObjectInDebug(personContacts);

        using (new AssertionScope())
        {
            personContacts.Should().NotBeNull();

            personContacts.Should().BeValidPersonContacts();
        }
    }

    /// <summary>
    /// Possibility 2: we can configure how many elements personContact will have
    /// Here we are using AutoFixture to decide how many elements we want to create
    /// </summary>
    [Theory]
    [AutoData]
    public void VerifyThatComplexObjectsAreCorrectlyGenerated_Variant2(int num)
    {
        // Arrange
        // Create fixture
        // var fixture = new Fixture();
        // Customize the fixture
        // fixture.Customize(new AllCustomization());

        // Create and Customize fixture
        var fixture = new Fixture()
            .Customize(new AllCustomization());

        // Act
        // Create PersonContact while specifying how many of it we need- default is 3
        var personContacts = fixture.Build<PersonContact>()
            .CreateMany(num)
            .ToImmutableList();

        PrintObjectInDebug(personContacts);

        // Assert
        using (new AssertionScope())
        {
            personContacts.Should().NotBeNull();

            personContacts.Should().BeValidPersonContacts();
        }
    }

    [Theory]
    [AutoDataCustom(Localizations.German)]
    public void VerifyThatGeneratedEmailIsRelatedToPersonName(PersonContact personContact)
    {
        PrintObjectInDebug(personContact);

        var expectedEmailPrefix =
            $"{NormalizeEmailToken(personContact.Person.FirstName)}.{NormalizeEmailToken(personContact.Person.LastName)}";

        using (new AssertionScope())
        {
            personContact.Contact.Email
                .Should()
                .StartWith(expectedEmailPrefix, because: "the generated email should be based on the generated person's name");

        }
    }

    private static string NormalizeEmailToken(string value)
    {
        var normalizedValue = value.Trim().Normalize(System.Text.NormalizationForm.FormD);
        var builder = new System.Text.StringBuilder();
        var previousWasSeparator = false;

        foreach (var character in normalizedValue)
        {
            if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(character) == System.Globalization.UnicodeCategory.NonSpacingMark)
            {
                continue;
            }

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
            ? "unknown"
            : token;
    }

}
