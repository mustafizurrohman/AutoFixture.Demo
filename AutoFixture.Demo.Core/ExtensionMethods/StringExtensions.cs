// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class StringExtensions
{
    public static bool ContainsIgnoreCultureIgnoreCase(this string str, 
        string query, 
        StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
    {
        return str.Contains(query, stringComparison);
    }

    public static bool ContainStrings(this string propertyName, 
        params string[] stringsToCompare)
    {
        return stringsToCompare.All(str => propertyName.ContainsIgnoreCultureIgnoreCase(str));
    }
    
    public static string GetFirstChars(this string str, int count)
    {
        return str.Substring(0, Math.Min(count, str.Length));
    }
}
