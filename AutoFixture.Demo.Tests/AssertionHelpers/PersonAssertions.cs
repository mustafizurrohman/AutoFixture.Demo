// ReSharper disable MemberCanBePrivate.Global

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class PersonAssertions
{
    private const string Space = " ";
    private const char Dash = '-';

    /// <summary>
    /// Assert that a person has valid attributes / is valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="person">Instance of person to assert</param>
    public static void ShouldBeValidPerson(this Person person)
    {
        var now = DateTime.Now;

        person
            .Should()
            .NotBeNull(because: "A person should not be null");

        person.FirstName
            .Should()
            .NotContain(Space);

        person.FirstName
            .Should()
            .Match(ch => ch.All(cc => char.IsLetter(cc) || cc == Dash), 
                because: "FirstName should not contain numbers or special characters");

        person.LastName
            .Should()
            .NotContain(Space);

        person.LastName
            .Should()
            .Match(ch => ch.All(cc => char.IsLetter(cc) || cc == Dash), 
                because: "LastName should not contain numbers or special characters");

        person.FullName
            .Should()
            .Contain(Space, 
                because: "There must be a white space between the first and last name");

        person.Age
            .Should()
            .NotBeNullOrWhiteSpace(
                because: "Age must be translated to a valid human readable age");

        person.DateOfBirth
            .Should()
            .BeBefore(now, 
                because: "A person must be born in the past");

        person.DateOfBirth
            .Should()
            .NotBeCloseTo(DateTime.MinValue, TimeSpan.FromDays(1),
                because: "DateOfBirth should not be close to the maximum value represented by Datetime");

        person.DateOfBirth
            .Should()
            .NotBeCloseTo(DateTime.MaxValue, TimeSpan.FromDays(1),
                because: "DateOfBirth should not be close to the minimum value represented by Datetime");

    }

    /// <summary>
    /// Assert that a IEnumerable of Person has valid attributes / are valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="persons">IEnumerable of Persons to assert</param>
    public static void ShouldBeValidPersons(this IEnumerable<Person> persons)
    {
        persons.Should()
            .AllSatisfy(p => p.ShouldBeValidPerson(),
                because: "Each person in the IEnumerable should be a valid person according to the validation rules.");
    }

}
