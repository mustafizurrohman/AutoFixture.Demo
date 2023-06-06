using System.Text.RegularExpressions;
// ReSharper disable MemberCanBePrivate.Global

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static partial class PersonAssertions
{
    // [^()[\]{}*&^%$#@!]+
    [GeneratedRegex("[\u0000-\u007FäüößéÄÜÖ]+ [\u0000-\u007FäüößéÄÜÖ]+", RegexOptions.Compiled)]
    private static partial Regex FullNameRegex();

    [GeneratedRegex("[\u0000-\u007FäüößéÄÜÖ][\u0000-\u007FäüößéÄÜÖ]+", RegexOptions.Compiled)]
    private static partial Regex NameRegex();

    /// <summary>
    /// Assert that a person has valid attributes / is valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="person">Instance of person to assert</param>
    public static void ShouldBeValidPerson(this Person person)
    {
        var fullNameRegex = FullNameRegex();
        var nameRegex = NameRegex();
        var now = DateTime.Now;

        person
            .Should()
            .NotBeNull(because: "A person should not be null");

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

        person.DateOfBirth
            .Should()
            .NotBeCloseTo(DateTime.MinValue, TimeSpan.FromDays(10));

        person.DateOfBirth
            .Should()
            .NotBeCloseTo(DateTime.MaxValue, TimeSpan.FromDays(10));

    }

    /// <summary>
    /// Assert that a IEnumerable of Person has valid attributes / are valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="persons">IEnumerable of Persons</param>
    public static void ShouldBeValidPersons(this IEnumerable<Person> persons)
    {
        persons.Should()
            .AllSatisfy(p => p.ShouldBeValidPerson());
    }


}


