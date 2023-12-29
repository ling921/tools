using System.Diagnostics;

namespace Ling.Tools.Color;

/// <summary>
/// Represents an RGB color.
/// </summary>
[DebuggerDisplay("Red: {Red}, Green: {Green}, Blue: {Blue}")]
public readonly struct RGB : IEquatable<RGB>
{
    /// <summary>
    /// The red value.
    /// </summary>
    public readonly byte Red;

    /// <summary>
    /// The green value.
    /// </summary>
    public readonly byte Green;

    /// <summary>
    /// The blue value.
    /// </summary>
    public readonly byte Blue;

    /// <summary>
    /// Constructs a new <see cref="RGB"/>.
    /// </summary>
    /// <param name="red">The red value.</param>
    /// <param name="green">The green value.</param>
    /// <param name="blue">The blue value.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public RGB(byte red, byte green, byte blue)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(255, red);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(255, green);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(255, blue);

        Red = red;
        Green = green;
        Blue = blue;
    }

    /// <summary>
    /// Constructs a new <see cref="RGB"/> from a hex string.
    /// </summary>
    /// <param name="hexColor">The hex color.</param>
    /// <exception cref="ArgumentException"></exception>
    /// <example>
    /// There are some examples:
    /// <code>
    /// var rgb = new RGB("#FF0000");
    /// var rgb = new RGB("#F00");
    /// var rgb = new RGB("FF0000");
    /// var rgb = new RGB("F00");
    /// </code>
    /// </example>
    public RGB(string hexColor) => ColorConverter.ToRGB(hexColor);

    /// <summary>
    /// Deconstructs the <see cref="RGB"/>.
    /// </summary>
    /// <param name="red">The red value.</param>
    /// <param name="green">The green value.</param>
    /// <param name="blue">The blue value.</param>
    public void Deconstruct(out byte red, out byte green, out byte blue)
    {
        red = Red;
        green = Green;
        blue = Blue;
    }

    /// <inheritdoc/>
    public bool Equals(RGB other) => (Red, Green, Blue) == (other.Red, other.Green, other.Blue);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is RGB rgb && Equals(rgb);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Red, Green, Blue);

    public static bool operator ==(RGB left, RGB right) => left.Equals(right);

    public static bool operator !=(RGB left, RGB right) => !(left == right);

    public static implicit operator RGB(CMYK cmyk) => ColorConverter.ToRGB(cmyk);

    public static implicit operator RGB(HSV hsv) => ColorConverter.ToRGB(hsv);

    public static implicit operator RGB(HSL hsl) => ColorConverter.ToRGB(hsl);
}
