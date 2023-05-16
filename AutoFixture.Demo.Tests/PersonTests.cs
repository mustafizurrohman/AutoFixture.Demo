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

        var person = fixture.Create<Person>();

        using (new AssertionScope())
        {
            person.Should().NotBeNull();
            person.FullName.Should().Contain(" ");            
        }       
        
    }
}