using System.Collections.Immutable;
using AutoFixture.Demo.Core.Constants;
using AutoFixture.Demo.Tests.AssertionHelpers;

namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonTests : TestBase
{
    public PersonTests(ITestOutputHelper outputHelper)
        : base(outputHelper)
    {
    }

    /// <summary>
    /// This does generates person and checks that the generated values are in accordance
    /// to the business rules
    /// </summary>
    /// <param name="persons"></param>
    [Theory]
    // [AutoData]
    [AutoDataCustom(localization: Localizations.Chinese)]
    //[AutoDataPerson]
    public void VerifyThatPersonsAreCorrectlyGenerated(List<Person> persons)
    {
        PrintObject(persons);

        // ASSERT
        using (new AssertionScope())
        {
            persons.ShouldBeValidPersons();
        }

    }

    [Fact]
    public void VerifyThatCreatedOnWasCorrectlySet()
    {
        // ARRANGE
        var now = DateTime.Now;

        var fixture = new Fixture()
            .Customize(new AllCustomization());

        // Set a fixed value of CreatedOn and use the rules in AllCustomization
        var personBuilder = fixture.Build<Person>()
            .With(p => p.CreatedOn, now);
            
        // ACT
        var persons = personBuilder.CreateMany()
            .ToImmutableList();

        PrintObject(persons);

        // ASSERT
        using (new AssertionScope()) 
        {
            persons.Select(p => p.CreatedOn)
                .Distinct()
                .First()
                .Should()
                .BeCloseTo(now, TimeSpan.FromMicroseconds(1),
                    because: "Each person should have the same date of birth as specified above");

            persons.Select(p => p.CreatedOn)
                .Distinct()
                .Should()
                .HaveCount(1, 
                    because: "All Persons should have only 1 fixed date of birth");
        }        
    }

    [Fact]
    public void VerifyThatDateIsValidatedOnUpdateDateOfBirthMethod()
    {
        // ARRANGE
        var now = DateTime.Now;
        var oneWeekAgo = now.AddDays(7);

        var fixture = new Fixture()
            .Customize(new AllCustomization());

        // Set a fixed value of CreatedOn and use the rules in AllCustomization
        var person = fixture.Build<Person>()
            .With(p => p.CreatedOn, now)
            .Create();

        PrintObject(person);

        // ACT
        var action = () => person.UpdateDateOfBirth(oneWeekAgo);

        // ASSERT
        action.Should()
            .ThrowExactly<ArgumentException>();

    }

}
