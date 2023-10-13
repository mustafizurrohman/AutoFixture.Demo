// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace AutoFixture.Demo.Models;

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Contact(string phone, string street, string city, string email)
{
    // TODO: Uncomment/comment and show demo
    // TODO: Generate Email based on Person.FirstName and Person.LastName
    public string Email { get; init; } = email ?? throw new ArgumentNullException(nameof(email));
    public string PhoneNumber { get; init; } = phone ?? throw new ArgumentNullException(nameof(phone));
    public string Street { get; init; } = street ?? throw new ArgumentNullException(nameof(street));
    public string City { get; init; } = city ?? throw new ArgumentNullException(nameof(city));

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
