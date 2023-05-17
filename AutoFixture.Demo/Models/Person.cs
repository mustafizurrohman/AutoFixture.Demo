// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace AutoFixture.Demo.Models; 

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Person
{
    public string FirstName { get; init; } 
    public string LastName { get; init; }
    
    public string FullName => FirstName + " " + LastName;
    
    public Person(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    public override string ToString()
    {
        return FullName;
    }
}
