namespace AutoFixture.Demo.Entities;

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

