using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public abstract class PropertyGeneratorBase
{
    protected Faker Faker { get; }
    private string Localization { get; }

    protected PropertyGeneratorBase(string localization = Localizations.DefaultLocalization)
    {
        Localization = localization;
        Faker = new Faker(Localization);
    }

    private static bool IsPropertyOfType(object request, Type type)
    {
        if (request is not PropertyInfo propertyInfo) 
            return false;

        return propertyInfo.PropertyType == type;
    }

    private static bool IsStringProperty(object request)
    {
        return IsPropertyOfType(request, typeof(string));
    }

    private static string GetPropertyName(object request)
    {
        return (request as PropertyInfo)?.Name ?? string.Empty;
    }

    protected static bool IsPhoneNumberProperty(object request)
    {
        if (!IsStringProperty(request))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("phone", "number");
    }

    protected static bool IsEmailProperty(object request)
    {
        if (!IsStringProperty(request))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("email");
    }

    protected static bool IsFirstNameProperty(object request)
    {
        if (!IsStringProperty(request))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("firstName");
    }

    protected static bool IsLastNameProperty(object request)
    {
        if (!IsStringProperty(request))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("lastName");
    }

    protected static bool IsDateOfBirthProperty(object request)
    {        
        if (!IsPropertyOfType(request, typeof(DateTime)))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("date", "birth");
    }

    protected static bool IsStreetProperty(object request)
    {
        if (!IsStringProperty(request))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("street");
    }

    protected static bool IsCityProperty(object request)
    {
        if (!IsStringProperty(request))
            return false;

        var propertyName = GetPropertyName(request);

        return propertyName.ContainStrings("city");
    }
}
