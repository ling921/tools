using System.Text.Json;

namespace Ling.Tools.Format;

/// <summary>
/// Represents a formatter that can be used to beautify and minify JSON.
/// </summary>
public static class JsonFormatter
{
    private static readonly JsonSerializerOptions _formatOptions;
    private static readonly JsonSerializerOptions _minifyOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonFormatter"/> class.
    /// </summary>
    static JsonFormatter()
    {
        _formatOptions = new() { WriteIndented = true };
        _minifyOptions = new() { WriteIndented = false };
    }

    /// <inheritdoc />
    public static string Beautify(string text)
    {
        var doc = JsonDocument.Parse(text);
        return JsonSerializer.Serialize(doc.RootElement, _formatOptions);
    }

    /// <inheritdoc />
    public static string Minify(string text)
    {
        var doc = JsonDocument.Parse(text);
        return JsonSerializer.Serialize(doc.RootElement, _minifyOptions);
    }
}
