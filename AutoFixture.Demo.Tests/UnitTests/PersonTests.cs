using AutoFixture.Demo.Tests.AssertionHelpers;

namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonTests : TestBase
{
    public PersonTests(ITestOutputHelper outputHelper)
        : base(outputHelper)
    {
    }

    /// <summary>
    /// This does not test anything a such
    /// Comment and uncomment the attributes and observe how it influences the generation of List of Person
    /// </summary>
    /// <param name="persons"></param>
    [Theory]
    // [AutoData]
    [AutoDataCustom]
    //[AutoDataPerson]
    public void VerifyThatPersonsAreCorrectlyGenerated(List<Person> persons)
    {
        OutputHelper.WriteLine(persons.ToFormattedJsonFailSafe());

        // ASSERT
        using (new AssertionScope())
        {
            persons
                .Should()
                .AllSatisfy(p => p.ShouldBeValidPerson());
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

        OutputHelper.WriteLine(persons.ToFormattedJsonFailSafe());

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

        OutputHelper.WriteLine(person.ToFormattedJsonFailSafe());

        // ACT
        var action = () => person.UpdateDateOfBirth(oneWeekAgo);

        // ASSERT
        action.Should()
            .ThrowExactly<ArgumentException>();

    }

}
