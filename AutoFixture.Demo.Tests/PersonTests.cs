using AutoFixture.Demo.Core.ExtensionMethods;
using AutoFixture.Demo.Customizations.Customizations;

namespace AutoFixture.Demo.Tests;

public class PersonTests
{
    [Fact]
    public void CustomizedPipeline()
    {
        var fixture = new Fixture();
        fixture.Customize(new PersonCustomization());


        //var person = fixture.CreateMany<Person>().ToList();

        //var debug = person.ToFormattedJsonFailSafe();

        //person.Should().NotBeNull();

        var persons = fixture.CreateMany<Person>(100);

        var debug = persons.Select(p => p.FullName).ToFormattedJsonFailSafe();

        using (new AssertionScope())
        {
            persons.Should().NotBeNull();
            persons.Should().AllSatisfy(p => p.FullName.Should().Contain(" "));
        }       
        
    }
}