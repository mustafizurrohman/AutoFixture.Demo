namespace AutoFixture.Demo.Customizations.SpecimenBuilders;
internal class EmailMessageBodyPropertyGenerator(string localization = Localizations.DefaultLocalization)
    : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsEmailMessageProperty(request))
            return new NoSpecimen();

        return Faker.Lorem.Paragraph(10);
    }
}
