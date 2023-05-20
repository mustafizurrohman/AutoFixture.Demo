namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class PhoneNumberPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public PhoneNumberPropertyGenerator(string localization = "de")
        : base(localization)
    {
    }

    public object Create(object request, ISpecimenContext context)
    {
        if (!IsPhoneNumberProperty(request))
            return new NoSpecimen();

        return Faker.Phone.PhoneNumber();
    }
}
