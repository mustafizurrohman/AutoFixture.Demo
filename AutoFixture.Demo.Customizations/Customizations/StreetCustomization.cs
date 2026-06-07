using System;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public class StreetCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new StreetPropertyGenerator(Localization));
    }

    private sealed class StreetPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsStreetProperty(request))
            {
                return new NoSpecimen();
            }

            return Faker.Address.StreetAddress();
        }
    }
}
