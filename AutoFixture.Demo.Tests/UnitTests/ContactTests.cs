using AutoFixture.Demo.Models;
using AutoFixture.Xunit2;

namespace AutoFixture.Demo.Tests.UnitTests;

public class ContactTests : TestBase
{
    public ContactTests(ITestOutputHelper outputHelper)
        : base(outputHelper)
    {
    }


    [Theory]
    [AutoData]
    public void VerifyThatContactsAreCorrectlyGeneratedWithoutFixtureCustomization(List<Contact> contacts)
    {
        PrintObject(contacts);

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
        PrintObject(contacts);

        using (new AssertionScope())
        {
            contacts
                .Should()
                .NotBeNull();

            contacts
                .Should()
                .HaveCount(3);
        }
    }

    [Fact]
    public void DemoContactGenerationWithoutFixtureCustomization()
    {
        // Arrange
        var fixture = new Fixture();
        var personBuilder = fixture.Build<Person>();

        // Act
        var persons = personBuilder.CreateMany()
            .ToList();

        PrintObject(persons);

        // Assert
        persons.Should().NotBeNull();
    }

    [Fact]
    public void DemoContactGenerationWithFixtureCustomization()
    {
        // Arrange
        var fixture = new Fixture();
        fixture.Customize(new AllCustomization());
        var personBuilder = fixture.Build<Person>();

        // Act
        var persons = personBuilder.CreateMany()
            .ToList();

        PrintObject(persons);

        // Assert
        persons.Should().NotBeNull();
    }
}

