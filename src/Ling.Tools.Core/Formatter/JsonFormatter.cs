using System.Text.Json;

namespace Ling.Tools.Formatter;

/// <summary>
/// Represents a JSON formatter.
/// </summary>
public sealed class JsonFormatter : IFormatter
{
    private readonly JsonSerializerOptions _formatOptions;
    private readonly JsonSerializerOptions _minifyOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonFormatter"/> class.
    /// </summary>
    /// <param name="ignoreComments">Whether to ignore comments.</param>
    public JsonFormatter(bool ignoreComments)
    {
        var commentHandling = ignoreComments ? JsonCommentHandling.Skip : JsonCommentHandling.Allow;
        _formatOptions = new() { WriteIndented = true, ReadCommentHandling = commentHandling };
        _minifyOptions = new() { ReadCommentHandling = commentHandling };
        _formatOptions.MakeReadOnly();
        _minifyOptions.MakeReadOnly();
    }

    /// <inheritdoc />
    public string Format(string text)
    {
        var doc = JsonDocument.Parse(text);
        return JsonSerializer.Serialize(doc.RootElement, _formatOptions);
    }

    /// <inheritdoc />
    public string Minify(string text)
    {
        var doc = JsonDocument.Parse(text);
        return JsonSerializer.Serialize(doc.RootElement, _minifyOptions);
    }
}
