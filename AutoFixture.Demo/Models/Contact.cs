// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace AutoFixture.Demo.Models;

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Contact
{
    // TODO: Uncomment/comment and show demo
    // TODO: Generate Email based on Person.FirstName and Person.LastName
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string Street { get; init; }
    public string City { get; init; }

    public Contact(string phone, string street, string city, string email)
    {
        PhoneNumber = phone ?? throw new ArgumentNullException(nameof(phone));
        Street = street ?? throw new ArgumentNullException(nameof(street));
        City = city ?? throw new ArgumentNullException(nameof(city));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public override string ToString()
    {
        string PrintAddress()
        {
            return Street + ", " + City
                   + Environment.NewLine
                   + "Phone: " + PhoneNumber;
        }

        string PrintEmail()
        {
            return "Email: " + Email;
        }

        return PrintAddress()
               + Environment.NewLine + PrintEmail();
    }
}
