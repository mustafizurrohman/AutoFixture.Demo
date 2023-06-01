namespace AutoFixture.Demo.Customizations.Customizations;

/// <summary>
/// Composite customization containing all custom rules
/// </summary>
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

/// <summary>
/// Composite customization containing all custom rules for 
/// custom generation for properties of Person
/// </summary>
public sealed class PersonCustomization : CompositeCustomization
{
    public PersonCustomization(string localization = Localizations.DefaultLocalization)
        : base(
            new NameCustomization(localization),
            new DobCustomization(localization),
            new PersonIDCustomization(localization)
        ) 
    {

    }
}

/// <summary>
/// Composite customization containing all custom rules for 
/// custom generation for properties of Contact
/// </summary>
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
