using System;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class PersonIDCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PersonIdGenerator(localization));
    }

    private sealed class PersonIdGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsPropertyOfType(request, typeof(PersonID)))
            {
                return new NoSpecimen();
            }

            var generatedId = Guid.NewGuid()
                .ToString("N")
                [..10]
                .ToUpperInvariant();

            return new PersonID(generatedId);
        }
    }
}
