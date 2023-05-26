// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class PersonContactAssertions
{
    public static void ShouldBeValidPersonContact(this PersonContact personContact)
    {
        personContact.Person
            .ShouldBeValidPerson();

        personContact.Contact
            .ShouldBeValidContact();
    }

    public static void ShouldBeValidPersonContacts(this IEnumerable<PersonContact> personContacts)
    {
        personContacts
            .Should()
            .AllSatisfy(pc => pc.ShouldBeValidPersonContact());
    }
}

