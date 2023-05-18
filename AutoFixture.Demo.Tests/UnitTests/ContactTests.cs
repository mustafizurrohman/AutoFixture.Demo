using AutoFixture.Xunit2;

namespace AutoFixture.Demo.Tests.UnitTests;

public class ContactTests
{
    [Theory]
    [AutoData]
    public void VerifyThatContactsAreCorrectlyGeneratedWithoutFixtureCustomization(List<Contact> contacts)
    {
        using (new AssertionScope())
        {
            contacts
                .Should()
                .NotBeNull();
        }
    }

    [Theory]
    [AutoDataCustom("it")]
    // [AutoDataContact]
    public void VerifyThatContactsAreCorrectlyGeneratedWithFixtureCustomization(List<Contact> contacts)
    {
        using (new AssertionScope())
        {
            contacts
                .Should()
                .NotBeNull();
        }
    }

    [Fact]
    public void DemoContactGenerationWithoutFixtureCustomization()
    {
        var fixture = new Fixture();
        var personBuilder = fixture.Build<Person>();

        var persons = personBuilder.CreateMany()
            .ToList();

        persons.Should().NotBeNull();
    }

    [Fact]
    public void DemoContactGenerationWithFixtureCustomization()
    {
        var fixture = new Fixture();
        fixture.Customize(new AllCustomization());
        var personBuilder = fixture.Build<Person>();

        var persons = personBuilder.CreateMany()
            .ToList();

        persons.Should().NotBeNull();
    }
}

