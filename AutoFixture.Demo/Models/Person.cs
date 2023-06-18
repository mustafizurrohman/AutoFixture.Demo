// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using AutoFixture.Demo.Core.ExtensionMethods;
using AutoFixture.Demo.Entities;

namespace AutoFixture.Demo.Models; 

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Person
{
    private static DateTime Now => DateTime.Now;

    // Not a primitive obsession!
    public required PersonID ID { get; set; }

    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedOn = Now;
    
    public string FullName => FirstName + " " + LastName;

    public string Age => DateOfBirth.ToFriendlyAge();

    // TODO: Uncomment and show demo
    // public string RandomData { get; set; }
    
    public void UpdateDateOfBirth(DateTime updatedDob)
    {
        if (updatedDob > CreatedOn)
            throw new ArgumentException("Person must have Date of birth before the entry was created");

        if (updatedDob > Now)
            throw new ArgumentException("Person cannot have Date of birth in the future");

        DateOfBirth = updatedDob;
    }
    
    public override string ToString()
    {
        return FullName;
    }
}
