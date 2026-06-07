using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class CityCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new CityPropertyGenerator(localization));
    }

    private sealed class CityPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            return IsCityProperty(request)
                ? Faker.Address.City()
                : new NoSpecimen();
        }
    }
}
