using System;
using AutoFixture;
using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;
using AutoFixture.Kernel;

namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class NameCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new NamePropertyGenerator(localization));
    }

    private sealed class NamePropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        private NameParts? _currentNameParts;

        public object Create(object request, ISpecimenContext context)
        {
            if (IsFirstNameProperty(request))
            {
                var nameParts = GetOrCreateNameParts();
                nameParts.FirstNameConsumed = true;

                ClearNamePartsIfConsumed();

                return nameParts.FirstName;
            }

            if (IsLastNameProperty(request))
            {
                var nameParts = GetOrCreateNameParts();
                nameParts.LastNameConsumed = true;

                ClearNamePartsIfConsumed();

                return nameParts.LastName;
            }

            return new NoSpecimen();
        }

        private NameParts GetOrCreateNameParts()
        {
            return _currentNameParts ??= CreateNameParts();
        }

        private NameParts CreateNameParts()
        {
            var fullNameParts = Faker.Name
                .FullName()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            return fullNameParts switch
            {
                [var firstName, .., var lastName] => new NameParts(firstName, lastName),
                _ => new NameParts(Faker.Name.FirstName(), Faker.Name.LastName()),
            };
        }

        private void ClearNamePartsIfConsumed()
        {
            if (_currentNameParts is { FirstNameConsumed: true, LastNameConsumed: true })
            {
                _currentNameParts = null;
            }
        }

        private sealed record NameParts(string FirstName, string LastName)
        {
            public bool FirstNameConsumed { get; set; }

            public bool LastNameConsumed { get; set; }
        }
    }
}
