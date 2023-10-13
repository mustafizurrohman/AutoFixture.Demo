namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class BoolPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsPropertyOfType(request, typeof(bool)))
            return new NoSpecimen();

        return Faker.Random.Number(10, 1000) % 5 == 0;
    }
}

