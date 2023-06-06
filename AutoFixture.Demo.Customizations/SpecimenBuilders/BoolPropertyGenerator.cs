namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class BoolPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public BoolPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : base(localization)
    {

    }

    public object Create(object request, ISpecimenContext context)
    {
        if (!IsPropertyOfType(request, typeof(bool)))
            return new NoSpecimen();

        return Faker.Random.Number(10, 1000) % 2 == 0;
    }
}

