using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace Ling.Tools.Escape;

/// <summary>
/// Represents a string escaper that can escape and unescape JSON strings.
/// </summary>
public static class JsonEscaper
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
        var sb = new StringBuilder();
        foreach (var c in input)
        {
            _ = sb.Append(c switch
            {
                '"' => "\\\"",
                '\\' => "\\\\",
                '\b' => "\\b",
                '\f' => "\\f",
                '\n' => "\\n",
                '\r' => "\\r",
                '\t' => "\\t",
                _ => 0x00 <= c && c <= 0x1F ? $"\\u{(int)c:X4}" : new string(c, 1)
            });
        }
        return sb.ToString();
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
        return Regex.Unescape(input);
    }
}