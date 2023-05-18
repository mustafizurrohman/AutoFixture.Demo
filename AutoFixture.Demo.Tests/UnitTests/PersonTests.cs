namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonTests
{
    [Theory]
    // [AutoDataCustom]
    [AutoDataPerson]
    public void VerifyThatPersonsAreCorrectlyGenerated(List<Person> persons)
    {
        // ASSERT
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

    [Fact]
    public void VerifyThatCreatedOnWasCorrectlySet()
    {
        // ARRANGE
        var now = DateTime.Now;

        var fixture = new Fixture();
        fixture.Customize(new AllCustomization());

        // Set a fixed value of CreatedOn and use the rules in AllCustomization
        var personBuilder = fixture.Build<Person>()
            .With(p => p.CreatedOn, now);
            
        // ACT
        var persons = personBuilder.CreateMany();

        // ASSERT
        persons.Select(p => p.CreatedOn)
            .Distinct()
            .Should()
            .HaveCount(1);
    }

    [Fact]
    public void VerifyThatDateIsValidatedOnUpdateDateOfBirthMethod()
    {
        // ARRANGE
        var now = DateTime.Now;
        var oneWeekAgo = now.AddDays(7);

        var fixture = new Fixture();
        fixture.Customize(new AllCustomization());

        // Set a fixed value of CreatedOn and use the rules in AllCustomization
        var person = fixture.Build<Person>()
            .With(p => p.CreatedOn, now)
            .Create();

        // ACT
        Action action = () => person.UpdateDateOfBirth(oneWeekAgo);

        // ASSERT
        action.Should()
            .ThrowExactly<ArgumentException>();

    }

}