using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Ling.Tools.Web.Shared.Infrastructure;

internal static class ConsoleHelper
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    };

    public static Task WriteLineAsync(this TextWriter writer, object? message)
    {
        string msg;
        if (message is null)
        {
            msg = "<null>";
        }
        else if (message.GetType().IsPrimitive)
        {
            msg = message.ToString() ?? "<null>";
        }
        else
        {
            msg = JsonSerializer.Serialize(message, _jsonSerializerOptions);
        }
        return writer.WriteLineAsync(msg);
    }
}
