namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class EmailPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (IsEmailProperty(request))
            return Faker.Internet.Email();

        return new NoSpecimen();
    }
}
