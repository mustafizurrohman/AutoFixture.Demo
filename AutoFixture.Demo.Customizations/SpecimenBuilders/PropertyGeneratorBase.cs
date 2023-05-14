using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public abstract class PropertyGeneratorBase
{
    public Faker Faker { get; }

    protected PropertyGeneratorBase(string localization = "de")
    {
        Faker = new Faker(localization);
    }

    protected bool IsStringProperty(object request)
    {
        if (request is not PropertyInfo propertyInfo)
            return false;

        return propertyInfo.PropertyType == typeof(string);

    }

    protected string GetPropertyName(object request)
    {
        return (request as PropertyInfo)?.Name ?? string.Empty;
    }
}

