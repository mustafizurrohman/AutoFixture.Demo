namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class StreetPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsStreetProperty(request))
            return new NoSpecimen();

        return Faker.Address.StreetAddress();
    }
}
