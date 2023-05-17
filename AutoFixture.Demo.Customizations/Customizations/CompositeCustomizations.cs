namespace AutoFixture.Demo.Customizations.Customizations;

public class AllCustomization : CompositeCustomization
{
    public AllCustomization()
        : base(
              new NameCustomization(),
              new EmailCustomization(),
              new DobCustomization(),
              new PhoneNumberCustomization(),
              new StreetCustomization(),
              new CityCustomization()
        )
    {

    }
}

public class PersonCustomization : CompositeCustomization
{
    public PersonCustomization()
        : base(new NameCustomization()) 
    {

    }
}

public class ContactCustomization : CompositeCustomization
{
    public ContactCustomization()
        : base(
            new EmailCustomization(),
            new PhoneNumberCustomization(),
            new StreetCustomization(),
            new CityCustomization()
        )
    {

    }
}
