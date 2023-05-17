using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class EmailPropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
{    
    public object Create(object request, ISpecimenContext context)
    {
        if (request is not PropertyInfo propertyInfo)
            return new NoSpecimen();

        var isStringProperty = propertyInfo.PropertyType == typeof(string);

        if (!isStringProperty)
            return new NoSpecimen();

        if (propertyInfo.Name.Contains("Email", StringComparison.InvariantCultureIgnoreCase))
            return Faker.Internet.Email();

        return new NoSpecimen();
    }
}

