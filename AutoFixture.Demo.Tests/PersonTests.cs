namespace AutoFixture.Demo.Tests;

public class PersonTests
{
    [Fact]
    public void CustomizedPipeline()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(new NamePropertyGenerator());
        //fixture.Customizations.Add(new DateOfBirthPropertyGenerator());
        //fixture.Customizations.Add(new EmailPropertyGenerator());
        fixture.Customizations.Add(new PhoneNumberPropertyGenerator());

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