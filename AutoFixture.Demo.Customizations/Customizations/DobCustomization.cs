using System;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public class DobCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new DateOfBirthPropertyGenerator(Localization));
    }

    private sealed class DateOfBirthPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsDateOfBirthProperty(request))
            {
                return new NoSpecimen();
            }

            var now = DateTime.Now;

            return Faker.Date.Between(now.AddYears(-100), now.AddDays(-1));
        }
    }
}
