namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class PhoneNumberPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsStringProperty(context))
            return new NoSpecimen();

        var propName = GetPropertyName(request);

        var isPhoneNumberProperty = propName.Contains("phone", StringComparison.InvariantCultureIgnoreCase)
                                    && propName.Contains("number", StringComparison.InvariantCultureIgnoreCase);

        if (!isPhoneNumberProperty)
            return new OmitSpecimen();

        return "040 " + Enumerable.Range(0, 9)
            .OrderBy(_ => Guid.NewGuid())
            .Take(6);
    }
}