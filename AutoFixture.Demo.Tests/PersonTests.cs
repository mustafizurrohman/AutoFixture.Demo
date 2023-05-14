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
        fixture.Customizations.Add(new EmailPropertyGenerator());

        var person = fixture.Create<Person>();

        person.Should().NotBeNull();
    }
}