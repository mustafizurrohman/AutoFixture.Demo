namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class CityPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsCityProperty(request))
            return new NoSpecimen();

        return Faker.Address.City();
    }
}
