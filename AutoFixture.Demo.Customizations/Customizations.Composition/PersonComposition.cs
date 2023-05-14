namespace AutoFixture.Demo.Customizations.Customizations.Composition;

public class PersonComposition
{
    public IFixture GetPersonComposition()
    {
        var customizations = new List<ICustomization>()
        {
            new PhoneNumberCustomization(),
            new NameCustomization()
        };

        var fixture = new Fixture()
            .Customize(new CompositeCustomization(customizations));

        return fixture;
    }
}

