using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public class NameCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new NamePropertyGenerator());
    }
}

public class EmailCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailPropertyGenerator());
    }
}

public class DobCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new DateOfBirthPropertyGenerator());
    }
}

public class PhoneNumberCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PhoneNumberPropertyGenerator());
    }
}

