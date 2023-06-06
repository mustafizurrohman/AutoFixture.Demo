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

        return DateTime.Now.Ticks % 2 == 0;
    }
}

