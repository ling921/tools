using System.Diagnostics;

namespace Ling.Tools.Color;

[DebuggerDisplay("Hue: {Hue}°, Saturation: {Saturation:P2}, Lightness: {Lightness:P2}")]
public readonly struct HSL : IEquatable<HSL>
{
    /// <summary>
    /// The hue value.
    /// </summary>
    public readonly float Hue;

    /// <summary>
    /// The saturation value.
    /// </summary>
    public readonly float Saturation;

    /// <summary>
    /// The lightness value.
    /// </summary>
    public readonly float Lightness;

    /// <summary>
    /// Constructs a new <see cref="HSL"/>.
    /// </summary>
    /// <param name="hue">The hue value. Value must be between <c>0</c> and <c>360</c>.</param>
    /// <param name="saturation">The saturation value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <param name="lightness">The lightness value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public HSL(float hue, float saturation, float lightness)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(hue);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(360, hue);
        ArgumentOutOfRangeException.ThrowIfNegative(saturation);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, saturation);
        ArgumentOutOfRangeException.ThrowIfNegative(lightness);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, lightness);

        Hue = hue;
        Saturation = saturation;
        Lightness = lightness;
    }

    /// <summary>
    /// Deconstructs the <see cref="HSL"/>.
    /// </summary>
    /// <param name="hue">The hue value.</param>
    /// <param name="saturation">The saturation value.</param>
    /// <param name="lightness">The lightness value.</param>
    public void Deconstruct(out float hue, out float saturation, out float lightness)
    {
        hue = Hue;
        saturation = Saturation;
        lightness = Lightness;
    }

    /// <inheritdoc/>
    public bool Equals(HSL other) => (Hue, Saturation, Lightness) == (other.Hue, other.Saturation, other.Lightness);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is HSL hsl && Equals(hsl);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Hue, Saturation, Lightness);

    public static bool operator ==(HSL left, HSL right) => left.Equals(right);

    public static bool operator !=(HSL left, HSL right) => !(left == right);

    public static implicit operator HSL(RGB rgb) => ColorConverter.ToHSL(rgb);

    public static implicit operator HSL(CMYK cmyk) => ColorConverter.ToHSL(cmyk);

    public static implicit operator HSL(HSV hsv) => ColorConverter.ToHSL(hsv);
}
