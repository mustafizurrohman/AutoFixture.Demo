namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonContactTests
{
    [Theory]
    [AutoDataCustom]
    public void VerifyThatComplexObjectsAreCorrectlyGenerated(List<PersonContact> personContacts)
    {
        using (new AssertionScope())
        {
            personContacts.Should().NotBeNull();
        }
    }
}

