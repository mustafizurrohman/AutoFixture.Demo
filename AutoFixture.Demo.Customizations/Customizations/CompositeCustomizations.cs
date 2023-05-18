namespace AutoFixture.Demo.Customizations.Customizations;

public class AllCustomization : CompositeCustomization
{
    public AllCustomization(string localization = "de")
        : base(
              new NameCustomization(localization),
              new EmailCustomization(localization),
              new DobCustomization(localization),
              new PhoneNumberCustomization(localization),
              new StreetCustomization(localization),
              new CityCustomization(localization)
        )
    {
    }
}

public class PersonCustomization : CompositeCustomization
{
    public PersonCustomization(string localization = "de")
        : base(
            new NameCustomization(localization),
            new DobCustomization(localization)
        ) 
    {

    }
}

public class ContactCustomization : CompositeCustomization
{
    public ContactCustomization(string localization = "de")
        : base(
            new EmailCustomization(localization),
            new PhoneNumberCustomization(localization),
            new StreetCustomization(localization),
            new CityCustomization(localization)
        )
    {

    }
}
