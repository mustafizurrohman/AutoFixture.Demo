using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

internal class FixtureHelper : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new NamePropertyGenerator());
        fixture.Customizations.Add(new DateOfBirthPropertyGenerator());
        fixture.Customizations.Add(new EmailPropertyGenerator());
        fixture.Customizations.Add(new PhoneNumberPropertyGenerator());
    }
}

