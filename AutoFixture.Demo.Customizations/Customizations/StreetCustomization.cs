using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class StreetCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new StreetPropertyGenerator(localization));
    }

    private sealed class StreetPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            return IsStreetProperty(request)
                ? Faker.Address.StreetAddress()
                : new NoSpecimen();
        }
    }
}
