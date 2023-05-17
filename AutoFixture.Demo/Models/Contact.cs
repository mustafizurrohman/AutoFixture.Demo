// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global
using System.Net.Mail;

namespace AutoFixture.Demo.Models;

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Contact
{
    //public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string Street { get; init; }
    public string City { get; init; }

    public Contact(string email, string phone)
    {
        //Email = new MailAddress(email).Address ?? throw new ArgumentNullException(nameof(email));
        PhoneNumber = phone ?? throw new ArgumentNullException(nameof(phone));
    }

    //public override string ToString()
    //{
    //    return "Email: " + Email
    //                     + Environment.NewLine
    //                     + "Phone: " + PhoneNumber;
    //}
}

