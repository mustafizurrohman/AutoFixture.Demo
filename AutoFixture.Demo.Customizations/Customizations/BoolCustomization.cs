using System;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public class BoolCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new BoolPropertyGenerator(Localization));
    }

    private sealed class BoolPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsPropertyOfType(request, typeof(bool)))
            {
                return new NoSpecimen();
            }

            return Faker.Random.Number(10, 1000) % 5 == 0;
        }
    }
}
