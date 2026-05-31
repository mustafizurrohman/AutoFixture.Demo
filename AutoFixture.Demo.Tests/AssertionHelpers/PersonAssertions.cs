// ReSharper disable MemberCanBePrivate.Global

using FluentAssertions.Collections;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class PersonAssertions
{
    private const string Space = " ";
    private const char Dash = '-';

    /// <summary>
    /// Asserts that a <see cref="Person"/> has valid attributes.
    /// </summary>
    [CustomAssertion]
    public static AndConstraint<ObjectAssertions> BeValidPerson(
        this ObjectAssertions assertions)
    {
        assertions.Subject
            .Should()
            .BeAssignableTo<Person>(because: "the subject should be a person");

        if (assertions.Subject is not Person person)
        {
            return new AndConstraint<ObjectAssertions>(assertions);
        }

        using var _ = new AssertionScope(nameof(Person));

        var now = DateTime.Now;

        person.FirstName
            .Should()
            .NotBeNullOrWhiteSpace(because: "FirstName is required");

        person.FirstName
            .Should()
            .NotContain(Space, because: "FirstName should not contain spaces");

        person.FirstName
            .Should()
            .Match(name => name.All(IsLetterOrDash),
                because: "FirstName should not contain numbers or special characters");

        person.LastName
            .Should()
            .NotBeNullOrWhiteSpace(because: "LastName is required");

        person.LastName
            .Should()
            .NotContain(Space, because: "LastName should not contain spaces");

        person.LastName
            .Should()
            .Match(name => name.All(IsLetterOrDash),
                because: "LastName should not contain numbers or special characters");

        person.FullName
            .Should()
            .NotBeNullOrWhiteSpace(because: "FullName is required");

        person.FullName
            .Should()
            .Contain(Space,
                because: "there must be a white space between the first and last name");

        person.Age
            .Should()
            .NotBeNullOrWhiteSpace(
                because: "Age must be translated to a valid human readable age");

        person.DateOfBirth
            .Should()
            .BeBefore(now,
                because: "a person must be born in the past");

        person.DateOfBirth
            .Should()
            .NotBeCloseTo(DateTime.MinValue, TimeSpan.FromDays(1),
                because: "DateOfBirth should not be close to the minimum value represented by DateTime");

        person.DateOfBirth
            .Should()
            .NotBeCloseTo(DateTime.MaxValue, TimeSpan.FromDays(1),
                because: "DateOfBirth should not be close to the maximum value represented by DateTime");

        return new AndConstraint<ObjectAssertions>(assertions);
    }

    /// <summary>
    /// Asserts that every <see cref="Person"/> in a collection has valid attributes.
    /// </summary>
    [CustomAssertion]
    public static AndConstraint<GenericCollectionAssertions<Person>> BeValidPersons(
        this GenericCollectionAssertions<Person> assertions)
    {
        return assertions.BeValidCollection(personContact =>
            personContact.Should().BeValidPerson());
    }

    private static bool IsLetterOrDash(char character)
    {
        return char.IsLetter(character) || character == Dash;
    }
}