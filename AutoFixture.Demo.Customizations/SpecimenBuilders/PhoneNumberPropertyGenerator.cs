namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class PhoneNumberPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsPhoneNumberProperty(request))
            return new NoSpecimen();

        return Faker.Phone.PhoneNumber();
    }
}