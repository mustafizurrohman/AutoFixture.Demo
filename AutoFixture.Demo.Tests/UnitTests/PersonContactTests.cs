using AutoFixture.Demo.Core.Constants;
using AutoFixture.Demo.Tests.AssertionHelpers;

namespace AutoFixture.Demo.Tests.UnitTests;

public class PersonContactTests : TestBase
{
    
    public PersonContactTests(ITestOutputHelper outputHelper) 
        : base(outputHelper)
    {
    }

    /// <summary>
    /// Possibility 1: personContacts will have 3 elements
    /// </summary>
    /// <param name="personContacts"></param>
    [Theory]
    [AutoDataCustom(Localizations.Dutch)]
    // [AutoDataPerson]
    public void VerifyThatComplexObjectsAreCorrectlyGenerated_Variant1(List<PersonContact> personContacts)
    {
        PrintObject(personContacts);

        using (new AssertionScope())
        {
            personContacts.Should().NotBeNull();

            personContacts.ShouldBeValidPersonContacts();
        }
    }

    /// <summary>
    /// Possibility 2: we can configure how many elements personContact will have
    /// Here we are using AutoFixture to decide how many elements we want to create
    /// </summary>
    [Theory]
    [AutoData]
    public void VerifyThatComplexObjectsAreCorrectlyGenerated_Variant2(int num)
    {
        // Arrange
        // Create fixture
        // var fixture = new Fixture();
        // Customize the fixture
        // fixture.Customize(new AllCustomization());

        // Create and Customize fixture
        var fixture = new Fixture()
            .Customize(new AllCustomization());

        // Act
        // Create PersonContact while specifying how many of it we need- default is 3
        var personContacts = fixture.Build<PersonContact>()
            .CreateMany(num)
            .ToList();

        PrintObject(personContacts);

        // Assert
        using (new AssertionScope())
        {
            personContacts.Should().NotBeNull();

            personContacts.ShouldBeValidPersonContacts();
        }
    }
}
