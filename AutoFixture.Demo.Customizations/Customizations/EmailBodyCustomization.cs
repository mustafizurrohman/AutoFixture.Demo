using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public sealed class EmailBodyCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailMessageBodyPropertyGenerator(localization));
    }

    private sealed class EmailMessageBodyPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            return IsEmailMessageProperty(request)
                ? Faker.Lorem.Paragraph(10)
                : new NoSpecimen();
        }
    }
}
