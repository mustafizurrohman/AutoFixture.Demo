using System.Collections.Immutable;
using AutoFixture.Demo.Core.Constants;
using AutoFixture.Demo.Tests.AssertionHelpers;
#pragma warning disable S125

namespace AutoFixture.Demo.Tests.UnitTests;

public class ContactTests(ITestOutputHelper outputHelper) 
    : TestBase(outputHelper)
{
    [Theory]
    [AutoDataCustom]
    public void VerifyThatContactsAreCorrectlyGeneratedWithoutFixtureCustomization([ListLength(10)] List<Contact> contacts)
    {
        PrintObjectInDebug(contacts);

        using (new AssertionScope())
        {
            contacts.Should().BeValidContacts();
        }
    }

    [Theory]
    [AutoDataCustom(Localizations.Italian)]
    // [AutoDataContact]
    public void VerifyThatContactsAreCorrectlyGeneratedWithFixtureCustomization([ListLength(10)] List<Contact> contacts)
    {
        PrintObjectInDebug(contacts);

        using (new AssertionScope())
        {
            contacts
                .Should().BeValidContacts();

            contacts
                .Should()
                .HaveCount(10, because: "10 contacts should be generated");
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

        PrintObjectInDebug(persons);

        // Assert
        using (new AssertionScope())
        {
            persons.Should().NotBeNull();
        }
    }

    [Theory]
    [AutoData]
    public void DemoContactGenerationWithFixtureCustomization(int num)
    {
        // Arrange- Create and customize fixture
        var fixture = new Fixture()
            .Customize(new AllCustomization());
        
        var personBuilder = fixture.Build<Person>();

        // Act
        var persons = personBuilder.CreateMany(num)
            .ToImmutableList();

        PrintObjectInDebug(persons);

        // Assert
        using (new AssertionScope())
        {
            persons.Should().BeValidPersons();
        }
    }
}
