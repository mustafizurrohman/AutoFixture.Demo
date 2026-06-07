using System;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public class EmailCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailPropertyGenerator(Localization));
    }

    private sealed class EmailPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (IsEmailProperty(request))
            {
                return Faker.Internet.Email();
            }

            return new NoSpecimen();
        }
    }
}
