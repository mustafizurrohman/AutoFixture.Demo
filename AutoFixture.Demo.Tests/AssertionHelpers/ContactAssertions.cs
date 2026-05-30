// ReSharper disable MemberCanBePrivate.Global
using FluentAssertions.Collections;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class ContactAssertions
{
    public static AndConstraint<ObjectAssertions> BeValidContact(
        this ObjectAssertions assertions)
    {
        assertions.Subject
            .Should()
            .BeOfType<Contact>();

        var contact = (Contact)assertions.Subject!;

        contact.Email
            .Should()
            .BeValidEmail();

        contact.PhoneNumber
            .Should()
            .NotBeNullOrWhiteSpace();

        contact.Street
            .Should()
            .NotBeNullOrWhiteSpace();

        contact.City
            .Should()
            .NotBeNullOrWhiteSpace();

        return new AndConstraint<ObjectAssertions>(assertions);
    }

    public static AndConstraint<GenericCollectionAssertions<Contact>> BeValidContacts(
        this GenericCollectionAssertions<Contact> assertions)
    {
        assertions.Subject
            .Should()
            .NotBeNullOrEmpty();

        foreach (var contact in assertions.Subject)
        {
            contact
                .Should()
                .BeValidContact();
        }

        return new AndConstraint<GenericCollectionAssertions<Contact>>(assertions);
    }
}
