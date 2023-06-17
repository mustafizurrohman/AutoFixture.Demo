namespace AutoFixture.Demo.Entities;

// Using Primary Constructor syntax
// See: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/primary-constructors
// Refer to commented code below for the 'old' syntax
//public class PersonID(string id)
//{
//    public override string ToString()
//    {
//        return id;
//    }
//}

public class PersonID
{
    private string ID { get; }

    public PersonID(string id)
    {
        ID = id;
    }

    public override string ToString()
    {
        return ID;
    }
} 