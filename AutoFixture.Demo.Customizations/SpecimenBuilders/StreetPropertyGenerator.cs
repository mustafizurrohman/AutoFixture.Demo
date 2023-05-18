namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class StreetPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public StreetPropertyGenerator(string localization = "de")
        : base(localization)
    {
    }

    public object Create(object request, ISpecimenContext context)
    {
        if (!IsStreetProperty(request))
            return new NoSpecimen();

        return Faker.Address.StreetAddress();
    }
}

