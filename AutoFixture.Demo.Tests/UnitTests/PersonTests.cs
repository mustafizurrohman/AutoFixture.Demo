namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonTests
{
    [Theory]
    // [AutoDataCustom]
    [AutoDataPerson]
    public void VerifyThatPersonsAreCorrectlyGenerated(List<Person> persons)
    {
        using (new AssertionScope())
        {
            persons
                .Should()
                .NotBeNull();

            persons
                .Should()
                .AllSatisfy(p => p.FullName.Should().Contain(" "));
        }

    }


}