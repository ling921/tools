using System.Diagnostics;

namespace Ling.Tools.Color;

/// <summary>
/// Represents a CMYK color.
/// </summary>
[DebuggerDisplay("Cyan: {Cyan:P2}, Magenta: {Magenta:P2}, Yellow: {Yellow:P2}, Black: {Black:P2}")]
public readonly struct CMYK : IEquatable<CMYK>
{
    /// <summary>
    /// The cyan value.
    /// </summary>
    public readonly float Cyan;

    /// <summary>
    /// The magenta value.
    /// </summary>
    public readonly float Magenta;

    /// <summary>
    /// The yellow value.
    /// </summary>
    public readonly float Yellow;

    /// <summary>
    /// The black value.
    /// </summary>
    public readonly float Black;

    /// <summary>
    /// Constructs a new <see cref="CMYK"/>.
    /// </summary>
    /// <param name="cyan">The cyan value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <param name="magenta">The magenta value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <param name="yellow">The yellow value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <param name="black">The black value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public CMYK(float cyan, float magenta, float yellow, float black)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(cyan);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, cyan);
        ArgumentOutOfRangeException.ThrowIfNegative(magenta);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, magenta);
        ArgumentOutOfRangeException.ThrowIfNegative(yellow);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, yellow);
        ArgumentOutOfRangeException.ThrowIfNegative(black);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, black);

        Cyan = cyan;
        Magenta = magenta;
        Yellow = yellow;
        Black = black;
    }

    /// <summary>
    /// Deconstructs the <see cref="CMYK"/>.
    /// </summary>
    /// <param name="cyan">The cyan value.</param>
    /// <param name="magenta">The magenta value.</param>
    /// <param name="yellow">The yellow value.</param>
    /// <param name="black">The black value.</param>
    public void Deconstruct(out float cyan, out float magenta, out float yellow, out float black)
    {
        cyan = Cyan;
        magenta = Magenta;
        yellow = Yellow;
        black = Black;
    }

    /// <inheritdoc/>
    public bool Equals(CMYK other) => (Cyan, Magenta, Yellow, Black) == (other.Cyan, other.Magenta, other.Yellow, other.Black);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is CMYK cmyk && Equals(cmyk);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Cyan, Magenta, Yellow, Black);

    public static bool operator ==(CMYK left, CMYK right) => left.Equals(right);

    public static bool operator !=(CMYK left, CMYK right) => !(left == right);

    public static implicit operator CMYK(RGB rgb) => ColorConverter.ToCMYK(rgb);

    public static implicit operator CMYK(HSV hsv) => ColorConverter.ToCMYK(hsv);

    public static implicit operator CMYK(HSL hsl) => ColorConverter.ToCMYK(hsl);
}
