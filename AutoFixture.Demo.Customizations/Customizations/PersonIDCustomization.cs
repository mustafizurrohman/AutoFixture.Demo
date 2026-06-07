using System;
using System.Linq;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public class PersonIDCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PersonIdGenerator(Localization));
    }

    private sealed class PersonIdGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        /// <summary>
        /// Defines how properties of type <see cref="PersonID"/> should be generated.
        /// </summary>
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsPropertyOfType(request, typeof(PersonID)))
            {
                return new NoSpecimen();
            }

            var generatedId = Guid.NewGuid()
                .ToString()
                .Replace("-", string.Empty)
                .Select(c => c.ToString())
                .OrderBy(_ => Guid.NewGuid())
                .Take(10)
                .Aggregate((a, b) => a.ToUpper() + b.ToUpper());

            return new PersonID(generatedId);
        }
    }
}
