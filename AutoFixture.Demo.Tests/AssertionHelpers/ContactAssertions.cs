// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class ContactAssertions
{
    public static void ShouldBeValidContact(this Contact contact)
    {
        contact.Email
            .Should()
            .NotBeNullOrWhiteSpace();

        contact.PhoneNumber
            .Should()
            .NotBeNullOrWhiteSpace();

        contact.Street
            .Should()
            .NotBeNullOrWhiteSpace();

        contact.City
            .Should()
            .NotBeNullOrWhiteSpace();
    }

    public static void ShouldBeValidContacts(this IEnumerable<Contact> contacts)
    {
        contacts.Should()
            .AllSatisfy(contact => contact.ShouldBeValidContact());
    }
}