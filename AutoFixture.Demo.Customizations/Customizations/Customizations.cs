using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public class NameCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new NamePropertyGenerator(Localization));
    }
}

public class EmailCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailPropertyGenerator(Localization));
    }
}

public class DobCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new DateOfBirthPropertyGenerator(Localization));
    }
}

public class PhoneNumberCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PhoneNumberPropertyGenerator(Localization));
    }
}

public class StreetCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new StreetPropertyGenerator(Localization));
    }
}

public class CityCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new CityPropertyGenerator(Localization));
    }
}

public class PersonIDCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PersonIdGenerator(Localization));
    }
}

public class BoolCustomization(string localization = Localizations.DefaultLocalization) : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new BoolPropertyGenerator(Localization));
    }
}
