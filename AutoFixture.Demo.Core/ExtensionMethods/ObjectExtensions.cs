using Newtonsoft.Json;
using System.Text;

namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class ObjectExtensions
{
    public static string ToFormattedJsonFailSafe(this object? objectInstance, JsonSerializerSettings? serializerSettings = null)
    {
        var stringBuilder = new StringBuilder();
        var stringWriter = new StringWriter(stringBuilder);

        using JsonWriter textWriter = new JsonTextWriter(stringWriter);

        var serializer = JsonSerializer.CreateDefault(serializerSettings);
        serializer.Formatting = Formatting.Indented;
        serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        serializer.Serialize(textWriter, objectInstance);

        return stringBuilder.ToString();
    }
}
