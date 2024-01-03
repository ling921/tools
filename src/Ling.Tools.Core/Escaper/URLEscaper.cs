using System.Diagnostics.CodeAnalysis;

namespace Ling.Tools.Escaper;

/// <summary>
/// Represents a string escaper that can escape and unescape URLs.
/// </summary>
public static class URLEscaper
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
        return Uri.EscapeDataString(input);
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
        return Uri.UnescapeDataString(input);
    }
}
