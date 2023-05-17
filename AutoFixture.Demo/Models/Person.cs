// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace AutoFixture.Demo.Models; 

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Person
{
    private static DateTime Now => DateTime.Now;

    public string FirstName { get; set; } 
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
    
    public string FullName => FirstName + " " + LastName;

    protected Person()
    {

    }

    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        
        //if (dateOfBirth > Now)
        //    throw new ArgumentException("Date of birth must be in the past", nameof(dateOfBirth));

        DateOfBirth = dateOfBirth;
    }

    public override string ToString()
    {
        return FullName;
    }
}
