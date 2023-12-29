using System.Diagnostics;

namespace Ling.Tools.Color;

/// <summary>
/// Represents an HSV color. Also known as HSB.
/// </summary>
[DebuggerDisplay("Hue: {Hue:0.##}°, Saturation: {Saturation:P2}, Value: {Value:P2}")]
public readonly struct HSV : IEquatable<HSV>
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
    /// The brightness value.
    /// </summary>
    public readonly float Value;

    /// <summary>
    /// Constructs a new <see cref="HSV"/>.
    /// </summary>
    /// <param name="hue">The hue value. Value must be between <c>0</c> and <c>360</c>.</param>
    /// <param name="saturation">The saturation value. Value must be between <c>0</c> and <c>1</c>.</param>
    /// <param name="value">The brightness value. Value must be between <c>0</c> and <c>1</c>.</param>
    public HSV(float hue, float saturation, float value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(hue);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(360, hue);
        ArgumentOutOfRangeException.ThrowIfNegative(saturation);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, saturation);
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(1, value);

        Hue = hue;
        Saturation = saturation;
        Value = value;
    }

    /// <summary>
    /// Deconstructs the <see cref="HSV"/>.
    /// </summary>
    /// <param name="hue">The hue value.</param>
    /// <param name="saturation">The saturation value.</param>
    /// <param name="value">The brightness value.</param>
    public void Deconstruct(out float hue, out float saturation, out float value)
    {
        hue = Hue;
        saturation = Saturation;
        value = Value;
    }

    /// <inheritdoc/>
    public bool Equals(HSV other) => (Hue, Saturation, Value) == (other.Hue, other.Saturation, other.Value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is HSV hsv && Equals(hsv);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(Hue, Saturation, Value);

    public static bool operator ==(HSV left, HSV right) => left.Equals(right);

    public static bool operator !=(HSV left, HSV right) => !(left == right);

    public static implicit operator HSV(RGB rgb) => ColorConverter.ToHSV(rgb);

    public static implicit operator HSV(CMYK cmyk) => ColorConverter.ToHSV(cmyk);

    public static implicit operator HSV(HSL hsl) => ColorConverter.ToHSV(hsl);
}
