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
        var fixture = PersonComposition.GetPersonFixture();

        var person = fixture.CreateMany<Person>().ToList();

        person.Should().NotBeNull();
    }
}