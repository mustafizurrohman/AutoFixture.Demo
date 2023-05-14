using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class EmailPropertyGenerator : ISpecimenBuilder
{
    private static Faker Faker => new("de");

    public object Create(object request, ISpecimenContext context)
    {
        if (request is not PropertyInfo propertyInfo)
            return new NoSpecimen();

        var isStringProperty = propertyInfo.PropertyType == typeof(string);

        if (!isStringProperty)
            return new NoSpecimen();

        if (propertyInfo.Name.Contains("email", StringComparison.InvariantCultureIgnoreCase))
            return Faker.Name.FirstName() + "@gmail.com";

        return new NoSpecimen();
    }
}

