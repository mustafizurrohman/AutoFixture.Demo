// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class StringExtensions
{
    public static bool ContainsIgnoreCultureIgnoreCase(this string str, string query)
    {
        return str.Contains(query, StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool ContainStrings(this string propertyName, params string[] strings)
    {
        return strings.All(propertyName.ContainsIgnoreCultureIgnoreCase);
    }
}
