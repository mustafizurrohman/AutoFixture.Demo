// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class ContactAssertions
{
    /// <summary>
    /// Assert that a contact has valid attributes / is valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="contact">Instance of contact to assert</param>
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

    /// <summary>
    /// Assert that a IEnumerable of Contact has valid attributes / are valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="contacts">IEnumerable of Contact</param>
    public static void ShouldBeValidContacts(this IEnumerable<Contact> contacts)
    {
        contacts.Should()
            .AllSatisfy(contact => contact.ShouldBeValidContact());
    }
}