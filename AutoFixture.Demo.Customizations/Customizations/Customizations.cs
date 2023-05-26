using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public class NameCustomization : ICustomization
{
    private string Localization { get; }

    public NameCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new NamePropertyGenerator(Localization));
    }
}

public class EmailCustomization : ICustomization
{
    private string Localization { get; }

    public EmailCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailPropertyGenerator(Localization));
    }
}

public class DobCustomization : ICustomization
{
    private string Localization { get; }

    public DobCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new DateOfBirthPropertyGenerator(Localization));
    }
}

public class PhoneNumberCustomization : ICustomization
{
    private string Localization { get; }

    public PhoneNumberCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PhoneNumberPropertyGenerator(Localization));
    }
}

public class StreetCustomization : ICustomization
{
    private string Localization { get; }

    public StreetCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new StreetPropertyGenerator(Localization));
    }
}

public class CityCustomization : ICustomization
{
    private string Localization { get; }

    public CityCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new CityPropertyGenerator(Localization));
    }
}

public class PersonIDCustomization : ICustomization
{
    private string Localization { get; }

    public PersonIDCustomization(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
    }

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PersonIdGenerator(Localization));
    }
}
