namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class StringExtensions
{
    public static bool ContainsIgnoreCultureIgnoreCase(this string str, string query)
    {
        return str.Contains(query, StringComparison.InvariantCultureIgnoreCase);
    }
}
