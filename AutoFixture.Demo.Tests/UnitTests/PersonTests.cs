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

    [Theory]
    [AutoDataCustom]
    public void VerifyThatCreatedOnWasCorrectlySet()
    {
        var now = DateTime.Now;

        var fixture = new Fixture();
        fixture.Customize(new AllCustomization());

        var persons = fixture.Build<Person>()
            .With(p => p.CreatedOn, now)
            .CreateMany();
        
        persons.Should()
            .AllSatisfy(p => p.CreatedOn.Should().BeOnOrBefore(DateTime.Now));
    }


}