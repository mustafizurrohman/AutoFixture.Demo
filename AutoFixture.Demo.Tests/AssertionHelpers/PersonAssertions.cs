using System.Text.RegularExpressions;
// ReSharper disable MemberCanBePrivate.Global

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static partial class PersonAssertions
{
    [GeneratedRegex("[\u0000-\u007F]+ [\u0000-\u007F]+", RegexOptions.Compiled)]
    private static partial Regex FullNameRegex();

    [GeneratedRegex("[\u0000-\u007F][\u0000-\u007F]+", RegexOptions.Compiled)]
    private static partial Regex NameRegex();

    public static void ShouldBeValidPerson(this Person person)
    {
        var fullNameRegex = FullNameRegex();
        var nameRegex = NameRegex();
        var now = DateTime.Now;

        person
            .Should()
            .NotBeNull(because: "A person should be generated");

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
            .Contain(" ", because: "There must be a white space between the first and last name");

        person.Age
            .Should()
            .NotBeNullOrWhiteSpace();

        person.DateOfBirth
            .Should()
            .BeBefore(now, because: "A person must be born in the past");

    }

    public static void ShouldBeValidPersons(this IEnumerable<Person> persons)
    {
        persons.Should()
            .AllSatisfy(p => p.ShouldBeValidPerson());
    }


}


