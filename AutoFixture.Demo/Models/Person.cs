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

    public DateTime CreatedOn = Now;
    
    public string FullName => FirstName + " " + LastName;

    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        DateOfBirth = dateOfBirth;
    }

    // TODO: Unit test for this
    public void UpdateDateOfBirth(DateTime updatedDob)
    {
        if (updatedDob < CreatedOn)
            throw new ArgumentException("Person must be created before the entry was created");

        DateOfBirth = updatedDob;
    }

    public override string ToString()
    {
        return FullName;
    }
}
