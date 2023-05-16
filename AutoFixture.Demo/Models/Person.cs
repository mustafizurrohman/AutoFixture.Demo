using System.Net.Mail;
namespace AutoFixture.Demo.Models; 

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Person
{
    private static DateTime Now => DateTime.Now;

    public string FirstName { get; init; } 
    public string LastName { get; init; }
    //public string Email { get; init; }
    //public string PhoneNumber { get; init; }
    //public DateTime DateOfBirth { get; init; }

    public string FullName => FirstName + " " + LastName;
    
    //public int AgeInYears => Now.Year - DateOfBirth.Year;

    public Person(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        
        // Email = (new MailAddress(email)).Address;
        //Email = (new MailAddress(FirstName + "." + LastName + "@gmail.com")).Address;

        //PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));  

        //if (dateOfBirth > Now)
        //    throw new ArgumentException($"{nameof(DateOfBirth)} must be in the past");
         
        //DateOfBirth = dateOfBirth;

    }
}
