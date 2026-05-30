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
    
    /// <summary>
    /// Updates the person's date of birth, ensuring it is not in the future and not after the creation date.
    /// </summary>
    /// <param name="updatedDob">The new date of birth.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the date of birth is after the creation date or in the future.
    /// </exception>
    public void UpdateDateOfBirth(DateTime updatedDob)
    {
        if (updatedDob > CreatedOn)
            throw new ArgumentOutOfRangeException(nameof(updatedDob), 
                $"Date of birth ({updatedDob:yyyy-MM-dd}) cannot be after the entry creation date ({CreatedOn:yyyy-MM-dd}).");

        if (updatedDob > Now)
            throw new ArgumentOutOfRangeException(nameof(updatedDob), 
                $"Date of birth ({updatedDob:yyyy-MM-dd}) cannot be in the future (now: {Now:yyyy-MM-dd}).");

        DateOfBirth = updatedDob;
    }
    
    public override string ToString()
    {
        return FullName;
    }
}
