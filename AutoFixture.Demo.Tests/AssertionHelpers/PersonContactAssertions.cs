// ReSharper disable MemberCanBePrivate.Global

using FluentAssertions.Collections;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class PersonContactAssertions
{
    /// <summary>
    /// Asserts that the subject is exactly of type <see cref="PersonContact"/>
    /// and that both the related person and contact are valid.
    /// </summary>
    /// <example>
    /// <code>
    /// personContact
    ///     .Should()
    ///     .BeValidPersonContact();
    ///
    /// personContact
    ///     .Should()
    ///     .BeValidPersonContact("because generated person contacts should be valid");
    /// </code>
    /// </example>
    [CustomAssertion]
    public static AndConstraint<ObjectAssertions> BeValidPersonContact(
        this ObjectAssertions assertions,
        string because = "",
        params object[] becauseArgs)
    {
        ArgumentNullException.ThrowIfNull(assertions);

        using var scope = new AssertionScope(nameof(PersonContact));

        var personContact = assertions.Subject
            .Should()
            .BeOfType<PersonContact>(
                because: because,
                becauseArgs: becauseArgs)
            .Which;

        personContact.Person
            .Should()
            .BeValidPerson();

        personContact.Contact
            .Should()
            .BeValidContact();

        return new AndConstraint<ObjectAssertions>(assertions);
    }

    /// <summary>
    /// Asserts that the subject is exactly of type <see cref="PersonContact"/>
    /// and that both the related person and contact are valid.
    /// </summary>
    /// <example>
    /// <code>
    /// personContact
    ///     .Should()
    ///     .BeValidPersonContact();
    ///
    /// personContact
    ///     .Should()
    ///     .BeValidPersonContact("because generated person contacts should be valid");
    /// </code>
    /// </example>
    [CustomAssertion]
    public static AndConstraint<GenericCollectionAssertions<PersonContact>> BeValidPersonContacts(
        this GenericCollectionAssertions<PersonContact> assertions,
        string because = "",
        params object[] becauseArgs)
    {
        ArgumentNullException.ThrowIfNull(assertions);

        return assertions.BeValidCollection(personContact =>
            personContact
                .Should()
                .BeValidPersonContact(because, becauseArgs));
    }
}