namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class PhoneNumberPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsPhoneNumberProperty(request))
            return new NoSpecimen();

        return Faker.Phone.PhoneNumber();
    }
}
