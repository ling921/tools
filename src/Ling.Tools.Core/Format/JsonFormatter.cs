using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Ling.Tools.Format;

/// <summary>
/// Represents a formatter that can be used to beautify and minify JSON.
/// </summary>
public static class JsonFormatter
{
    private static readonly JsonReaderOptions ReaderOptions = new()
    {
        CommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
    };

    private static readonly JsonWriterOptions BeautifyWriterOptions = new()
    {
        Indented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    };

    private static readonly JsonWriterOptions MinifyWriterOptions = new()
    {
        Indented = false,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
    };

    /// <inheritdoc />
    [return: NotNullIfNotNull(nameof(text))]
    public static string? Beautify(string? text)
    {
        if (text is null) return null;
        return Write(text, BeautifyWriterOptions);
    }

    /// <inheritdoc />
    [return: NotNullIfNotNull(nameof(text))]
    public static string? Minify(string? text)
    {
        if (text is null) return null;
        return Write(text, MinifyWriterOptions);
    }

    private static string Write(string text, JsonWriterOptions options)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var reader = new Utf8JsonReader(bytes, ReaderOptions);
        using var ms = new MemoryStream();
        using var writer = new Utf8JsonWriter(ms, options);

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.None:
                    break;
                case JsonTokenType.StartObject:
                    writer.WriteStartObject();
                    break;
                case JsonTokenType.EndObject:
                    writer.WriteEndObject();
                    break;
                case JsonTokenType.StartArray:
                    writer.WriteStartArray();
                    break;
                case JsonTokenType.EndArray:
                    writer.WriteEndArray();
                    break;
                case JsonTokenType.PropertyName:
                    writer.WritePropertyName(reader.GetString()!);
                    break;
                case JsonTokenType.Comment:
                    break;
                case JsonTokenType.String:
                    writer.WriteStringValue(reader.GetString());
                    break;
                case JsonTokenType.Number:
                    writer.WriteRawValue(reader.ValueSpan);
                    break;
                case JsonTokenType.True:
                    writer.WriteBooleanValue(true);
                    break;
                case JsonTokenType.False:
                    writer.WriteBooleanValue(false);
                    break;
                case JsonTokenType.Null:
                    writer.WriteNullValue();
                    break;
                default:
                    break;
            }
        }

        return Encoding.UTF8.GetString(ms.ToArray());
    }
}
