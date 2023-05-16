namespace AutoFixture.Demo.Customizations.Customizations.Composition;

public static class PersonComposition
{
    public static IFixture GetPersonFixture()
    {
        var customizations = new List<ICustomization>()
        {
            new PersonCustomization()
        };

        var fixture = new Fixture()
            .Customize(new CompositeCustomization(customizations));

        return fixture;
    }
}

