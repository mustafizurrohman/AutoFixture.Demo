using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class DobCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new DateOfBirthPropertyGenerator(localization));
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

            var today = DateTime.Today;

            return Faker.Date.Between(today.AddYears(-100), today.AddDays(-1));
        }
    }
}
