namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class CityPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public CityPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : base(localization)
    {
    }

    public object Create(object request, ISpecimenContext context)
    {
        if (!IsCityProperty(request))
            return new NoSpecimen();

        return Faker.Address.City();
    }
}
