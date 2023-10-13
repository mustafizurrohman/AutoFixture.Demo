// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Models;

public class PersonContact(Person person, Contact contact)
{
    public Person Person { get; init; } = person;
    public Contact Contact { get; init; } = contact;

    public override string ToString()
    {
        return Person 
            + Environment.NewLine
            + Contact;
    }
}
