using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Ling.Tools.Extensions;

internal static class StringBuilderExtensions
{
    [return: NotNullIfNotNull(nameof(sb))]
    public static StringBuilder? AppendIf(this StringBuilder? sb, bool condition, object? value)
    {
        return condition ? sb?.Append(value) : sb;
    }

    [return: NotNullIfNotNull(nameof(sb))]
    public static StringBuilder? AppendIf(this StringBuilder? sb, bool condition, object? valueIfTrue, object? valueIfFalse)
    {
        return condition ? sb?.Append(valueIfTrue) : sb?.Append(valueIfFalse);
    }

    [return: NotNullIfNotNull(nameof(sb))]
    public static StringBuilder? Append<T>(this StringBuilder? sb, IEnumerable<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (var item in values)
        {
            sb?.Append(item);
        }
        return sb;
    }

    [return: NotNullIfNotNull(nameof(sb))]
    public static StringBuilder? Append<T>(this StringBuilder? sb, IEnumerable<T> values, Converter<T, string> formatter)
    {
        ArgumentNullException.ThrowIfNull(values);
        ArgumentNullException.ThrowIfNull(formatter);

        foreach (var item in values)
        {
            var value = formatter(item);
            sb?.Append(value);
        }
        return sb;
    }

    [return: NotNullIfNotNull(nameof(sb))]
    public static StringBuilder? AppendFormat<T>(this StringBuilder? sb, IEnumerable<T> values, string format)
    {
        ArgumentNullException.ThrowIfNull(values);
        ArgumentNullException.ThrowIfNull(format);

        foreach (var item in values)
        {
            sb?.AppendFormat(format, item);
        }
        return sb;
    }
}
