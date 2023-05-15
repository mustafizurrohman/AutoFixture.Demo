using AutoFixture.Demo.Core.ExtensionMethods;
using AutoFixture.Demo.Customizations.Customizations.Composition;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Models;
using FluentAssertions;

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
        //fixture.Customizations.Add(new PhoneNumberPropertyGenerator());

        //var person = fixture.CreateMany<Person>().ToList();

        //var debug = person.ToFormattedJsonFailSafe();

        //person.Should().NotBeNull();

        var person = fixture.Create<Person>();

        person.FullName.Should().Contain(" ");
    }
}