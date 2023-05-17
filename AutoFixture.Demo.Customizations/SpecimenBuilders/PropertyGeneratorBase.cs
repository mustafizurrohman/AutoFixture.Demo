using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public abstract class PropertyGeneratorBase
{
    protected Faker Faker { get; }

    protected PropertyGeneratorBase(string localization = "de")
    {
        Faker = new Faker(localization);
    }

    protected static bool IsStringProperty(object request)
    {
        if (request is not PropertyInfo propertyInfo)
            return false;

        return propertyInfo.PropertyType == typeof(string);

    }

    protected static string GetPropertyName(object request)
    {
        return (request as PropertyInfo)?.Name ?? string.Empty;
    }
}

