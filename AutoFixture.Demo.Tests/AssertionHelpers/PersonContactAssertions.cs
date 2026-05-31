// ReSharper disable MemberCanBePrivate.Global
using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class PersonContactAssertions
{
    /// <summary>
    /// Asserts that a <see cref="PersonContact"/> has a valid person and contact.
    /// </summary>
    [CustomAssertion]
    public static AndConstraint<ObjectAssertions> BeValidPersonContact(
        this ObjectAssertions assertions)
    {
        assertions.Subject
            .Should()
            .BeAssignableTo<PersonContact>(because: "the subject should be a person contact");

        if (assertions.Subject is not PersonContact personContact)
        {
            return new AndConstraint<ObjectAssertions>(assertions);
        }

        using var _ = new AssertionScope(nameof(PersonContact));

        personContact.Person
            .Should()
            .BeValidPerson();

        personContact.Contact
            .Should()
            .BeValidContact();

        return new AndConstraint<ObjectAssertions>(assertions);
    }

    /// <summary>
    /// Asserts that every <see cref="PersonContact"/> in a collection is valid.
    /// </summary>
    [CustomAssertion]
    public static AndConstraint<GenericCollectionAssertions<PersonContact>> BeValidPersonContacts(
        this GenericCollectionAssertions<PersonContact> assertions)
    {
        return assertions.BeValidCollection(personContact =>
            personContact.Should().BeValidPersonContact());
    }
}
