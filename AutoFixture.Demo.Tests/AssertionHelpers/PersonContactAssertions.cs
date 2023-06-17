// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class PersonContactAssertions
{
    /// <summary>
    /// Assert that a PersonContact has valid attributes / is valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="personContact">Instance of PersonContact to assert</param>
    public static void ShouldBeValidPersonContact(this PersonContact personContact)
    {
        personContact.Person
            .ShouldBeValidPerson();

        personContact.Contact
            .ShouldBeValidContact();
    }

    /// <summary>
    /// Assert that a IEnumerable of PersonContacts has valid attributes / are valid
    /// Please enclose with a new assertion scope, if necessary
    /// </summary>
    /// <param name="personContacts">IEnumerable of PersonContacts</param>
    public static void ShouldBeValidPersonContacts(this IEnumerable<PersonContact> personContacts)
    {
        personContacts
            .Should()
            .AllSatisfy(pc => pc.ShouldBeValidPersonContact());
    }
}
