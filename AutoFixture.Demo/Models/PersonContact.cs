// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Models;

public class PersonContact
{
    public Person Person { get; init; }
    public Contact Contact { get; init; }

    public PersonContact(Person person, Contact contact)
    {
        Person = person;
        Contact = contact;
    }

    public override string ToString()
    {
        return Person 
            + Environment.NewLine
            + Contact;
    }
}
