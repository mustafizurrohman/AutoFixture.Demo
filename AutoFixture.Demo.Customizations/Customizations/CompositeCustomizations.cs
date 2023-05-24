namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class AllCustomization : CompositeCustomization
{
    public AllCustomization(string localization = Localizations.DefaultLocalization)
        : base(
              new PersonCustomization(localization),
              new ContactCustomization(localization)
        )
    {
    }
}

public sealed class PersonCustomization : CompositeCustomization
{
    public PersonCustomization(string localization = Localizations.DefaultLocalization)
        : base(
            new NameCustomization(localization),
            new DobCustomization(localization)
        ) 
    {

    }
}

public sealed class ContactCustomization : CompositeCustomization
{
    public ContactCustomization(string localization = Localizations.DefaultLocalization)
        : base(
            new EmailCustomization(localization),
            new PhoneNumberCustomization(localization),
            new StreetCustomization(localization),
            new CityCustomization(localization)
        )
    {

    }
}
