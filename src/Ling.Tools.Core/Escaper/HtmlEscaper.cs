using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Ling.Tools.Escaper;

/// <summary>
/// Represents a string escaper that can escape and unescape HTML strings.
/// </summary>
public static class HtmlEscaper
{
    /// <summary>
    /// Escapes a string.
    /// </summary>
    /// <param name="input">The string to escape.</param>
    /// <returns>The escaped string.</returns>
    [return: NotNullIfNotNull(nameof(input))]
    public static string? Escape(string? input)
    {
        if (input == null) return null;
        return WebUtility.HtmlEncode(input);
    }

    /// <summary>
    /// Unescapes a string.
    /// </summary>
    /// <param name="input">The string to unescape.</param>
    /// <returns>The unescaped string.</returns>
    [return: NotNullIfNotNull(nameof(input))]
    public static string? Unescape(string? input)
    {
        if (input == null) return null;
        return WebUtility.HtmlDecode(input);
    }
}
