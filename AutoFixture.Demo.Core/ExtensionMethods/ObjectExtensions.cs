using System.Globalization;

namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class ObjectExtensions
{
    private const string FallbackJson = "{}";

    public static string ToFormattedJsonFailSafe(
        this object? objectInstance,
        JsonSerializerSettings? serializerSettings = null)
    {
        try
        {
            var stringBuilder = new StringBuilder();

            using var stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture);
            using var jsonWriter = new JsonTextWriter(stringWriter);
            jsonWriter.Formatting = Formatting.Indented;

            var serializer = JsonSerializer.CreateDefault(serializerSettings);
            serializer.Formatting = Formatting.Indented;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            serializer.Serialize(jsonWriter, objectInstance);
            jsonWriter.Flush();

            return stringBuilder.ToString();
        }
        catch (Exception exception) when (exception is JsonException or InvalidOperationException)
        {
            return FallbackJson;
        }
    }
}
