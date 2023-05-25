using System.Diagnostics;
using System.Text.RegularExpressions;
using Bogus.DataSets;
// ReSharper disable MemberCanBePrivate.Global

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static partial class PersonAssertions
{
    [GeneratedRegex("[A-Za-z]+ [A-Za-z]+", RegexOptions.Compiled)]
    private static partial Regex FullNameRegex();

    [GeneratedRegex("[A-Z][A-Za-z]+", RegexOptions.Compiled)]
    private static partial Regex NameRegex();

    public static void ShouldBeValidPerson(this Person person)
    {
        var fullNameRegex = FullNameRegex();
        var nameRegex = NameRegex();
        var now = DateTime.Now;

        person
            .Should()
            .NotBeNull();

        person.FirstName
            .Should()
            .MatchRegex(nameRegex);

        person.LastName
            .Should()
            .MatchRegex(nameRegex);

        person.FullName
            .Should()
            .MatchRegex(fullNameRegex);

        person.FullName
            .Should()
            .Contain(" ");

        person.Age
            .Should()
            .NotBeNullOrWhiteSpace();

        person.DateOfBirth
            .Should()
            .BeBefore(now);

    }

    public static void ShouldBeValidPersons(this IEnumerable<Person> persons)
    {
        persons.Should()
            .AllSatisfy(p => p.ShouldBeValidPerson());
    }


}


