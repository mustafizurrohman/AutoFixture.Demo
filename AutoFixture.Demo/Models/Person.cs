using System.Net.Mail;
namespace AutoFixture.Demo.Models; 

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Person
{
    private static DateTime Now => DateTime.Now;

    public string Firstname { get; init; } 
    public string Lastname { get; init; }
    // public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public DateTime DateOfBirth { get; init; }

    public string FullName => Firstname + " " + Lastname;
    
    public int AgeInYears => Now.Year - DateOfBirth.Year;

    public Person(string firstname, string lastname, string email, string phoneNumber, DateTime dateOfBirth)
    {
        Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
        
        Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
        
        // Email = (new MailAddress(email)).Address;
        
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));  

        //if (dateOfBirth > Now)
        //    throw new ArgumentException($"{nameof(DateOfBirth)} must be in the past");
         
        DateOfBirth = dateOfBirth;

    }
}
