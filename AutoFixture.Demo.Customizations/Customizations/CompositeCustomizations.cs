namespace AutoFixture.Demo.Customizations.Customizations;

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
            new PhoneNumberCustomization()
        )
    {

    }
}
