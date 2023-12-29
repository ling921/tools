namespace Ling.Tools.Formatter;

/// <summary>
/// The formatter interface.
/// </summary>
public interface IFormatter
{
    /// <summary>
    /// Minify the target text.
    /// </summary>
    /// <param name="text">The text to minify.</param>
    /// <returns>The minified text.</returns>
    string Minify(string text);

    /// <summary>
    /// Format the target text.
    /// </summary>
    /// <param name="text">The text to format.</param>
    /// <returns>The formatted text.</returns>
    string Format(string text);
}
