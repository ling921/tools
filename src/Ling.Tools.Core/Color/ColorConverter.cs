namespace Ling.Tools.Color;

/// <summary>
/// Conversion between color types.
/// </summary>
public static class ColorConverter
{
    /// <summary>
    /// Convert <see cref="RGB"/> color to hex color.
    /// </summary>
    /// <param name="rgb">The <see cref="RGB"/> color.</param>
    /// <returns>The hex color with format <c>#RRGGBB</c>.</returns>
    public static string ToHexString(this RGB rgb) => $"#{rgb.Red:X2}{rgb.Green:X2}{rgb.Blue:X2}";

    #region Convert to RGB

    /// <summary>
    /// Convert hex color to <see cref="RGB"/> color.
    /// <para>
    /// The format can be one of the following: <c>#RRGGBB</c>, <c>#RGB</c>, <c>RRGGBB</c>, <c>RGB</c>
    /// </para>
    /// </summary>
    /// <param name="hexColor">The hex color.</param>
    /// <returns>The <see cref="RGB"/> color converted from the hex color.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static RGB ToRGB(string hexColor)
    {
        var hex = hexColor?.Trim().ToLower();
        if (hex?.StartsWith('#') == true) hex = hex[1..];
        if (hex?.Length != 3 && hex?.Length != 6 && hex?.All("0123456789abcdef".Contains) != true)
        {
            throw new ArgumentException("Invalid hex color", nameof(hexColor));
        }

        byte red, green, blue;
        if (hex.Length == 3)
        {
            red = Convert.ToByte($"{hex[0]}{hex[0]}", 16);
            green = Convert.ToByte($"{hex[1]}{hex[1]}", 16);
            blue = Convert.ToByte($"{hex[2]}{hex[2]}", 16);
        }
        else
        {
            red = Convert.ToByte(hex[..2], 16);
            green = Convert.ToByte(hex[2..4], 16);
            blue = Convert.ToByte(hex[4..6], 16);
        }

        return new(red, green, blue);
    }

    /// <summary>
    /// Convert <see cref="CMYK"/> color to <see cref="RGB"/> color.
    /// </summary>
    /// <param name="cmyk">The <see cref="CMYK"/> color.</param>
    /// <returns>The <see cref="RGB"/> color converted from the <see cref="CMYK"/> color.</returns>
    public static RGB ToRGB(CMYK cmyk)
    {
        var (c, m, y, k) = cmyk;

        var r = 255 * (1 - c) * (1 - k);
        var g = 255 * (1 - m) * (1 - k);
        var b = 255 * (1 - y) * (1 - k);

        return new RGB((byte)r, (byte)g, (byte)b);
    }

    /// <summary>
    /// Convert <see cref="HSV"/> color to <see cref="RGB"/> color.
    /// </summary>
    /// <param name="hsv">The <see cref="HSV"/> color.</param>
    /// <returns>The <see cref="RGB"/> color converted from the <see cref="HSV"/> color.</returns>
    public static RGB ToRGB(HSV hsv)
    {
        var (h, s, v) = hsv;

        float r, g, b;

        if (s == 0)
        {
            r = g = b = v;
        }
        else
        {
            int i;
            float f, p, q, t;

            if (h == 360)
                h = 0;
            else
                h /= 60;

            i = (int)Math.Truncate(h);
            f = h - i;

            p = v * (1.0f - s);
            q = v * (1.0f - s * f);
            t = v * (1.0f - s * (1.0f - f));

            (r, g, b) = i switch
            {
                0 => (v, t, p),
                1 => (q, v, p),
                2 => (p, v, t),
                3 => (p, q, v),
                4 => (t, p, v),
                _ => (v, p, q),
            };
        }

        return new RGB((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
    }

    /// <summary>
    /// Convert <see cref="HSL"/> color to <see cref="RGB"/> color.
    /// </summary>
    /// <param name="hsl">The <see cref="HSL"/> color.</param>
    /// <returns>The <see cref="RGB"/> color converted from the <see cref="HSL"/> color.</returns>
    public static RGB ToRGB(HSL hsl)
    {
        var (h, s, l) = hsl;

        float r, g, b;

        if (s == 0)
        {
            r = g = b = l;
        }
        else
        {
            float q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            float p = 2 * l - q;
            h /= 360;

            r = HueToRGB(p, q, h + 1 / 3f);
            g = HueToRGB(p, q, h);
            b = HueToRGB(p, q, h - 1 / 3f);
        }

        return new RGB((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));

        static float HueToRGB(float p, float q, float t)
        {
            if (t < 0) t++;
            if (t > 1) t--;
            if (t < 1 / 6f) return p + (q - p) * 6 * t;
            if (t < 1 / 2f) return q;
            if (t < 2 / 3f) return p + (q - p) * (2 / 3f - t) * 6;
            return p;
        }
    }

    #endregion Convert to RGB

    #region  Convert to CMYK

    /// <summary>
    /// Convert <see cref="RGB"/> color to <see cref="CMYK"/> color.
    /// </summary>
    /// <param name="rgb">The <see cref="RGB"/> color.</param>
    /// <returns>The <see cref="CMYK"/> color converted from the <see cref="RGB"/> color.</returns>
    public static CMYK ToCMYK(RGB rgb)
    {
        var (r, g, b) = rgb;

        var rf = r / 255f;
        var gf = g / 255f;
        var bf = b / 255f;

        var k = 1 - Math.Max(Math.Max(rf, gf), bf);
        var c = (1 - rf - k) / (1 - k);
        var m = (1 - gf - k) / (1 - k);
        var y = (1 - bf - k) / (1 - k);

        return new CMYK(c, m, y, k);
    }

    /// <summary>
    /// Convert <see cref="HSV"/> color to <see cref="CMYK"/> color.
    /// </summary>
    /// <param name="hsv">The <see cref="HSV"/> color.</param>
    /// <returns>The <see cref="CMYK"/> color converted from the <see cref="HSV"/> color.</returns>
    public static CMYK ToCMYK(HSV hsv) => ToCMYK(ToRGB(hsv));

    /// <summary>
    /// Convert <see cref="HSL"/> color to <see cref="CMYK"/> color.
    /// </summary>
    /// <param name="hsl">The <see cref="HSL"/> color.</param>
    /// <returns>The <see cref="CMYK"/> color converted from the <see cref="HSL"/> color.</returns>
    public static CMYK ToCMYK(HSL hsl) => ToCMYK(ToRGB(hsl));

    #endregion Convert to CMYK

    #region Convert to HSV

    /// <summary>
    /// Convert <see cref="RGB"/> color to <see cref="HSV"/> color.
    /// </summary>
    /// <param name="rgb">The <see cref="RGB"/> color.</param>
    /// <returns>The <see cref="HSV"/> color converted from the <see cref="RGB"/> color.</returns>
    public static HSV ToHSV(RGB rgb)
    {
        var (r, g, b) = rgb;

        var rf = r / 255f;
        var gf = g / 255f;
        var bf = b / 255f;

        var max = Math.Max(rf, Math.Max(gf, bf));
        var min = Math.Min(rf, Math.Min(gf, bf));
        var diff = max - min;

        var h = 0f;
        if (max == min)
        {
            h = 0;
        }
        else if (max == rf)
        {
            h = (60 * ((gf - bf) / diff) + 360) % 360;
        }
        else if (max == gf)
        {
            h = (60 * ((bf - rf) / diff) + 120) % 360;
        }
        else if (max == bf)
        {
            h = (60 * ((rf - gf) / diff) + 240) % 360;
        }

        float s = max == 0 ? 0 : diff / max;
        float v = max;

        return new HSV(h, s, v);
    }

    /// <summary>
    /// Convert <see cref="CMYK"/> color to <see cref="HSV"/> color.
    /// </summary>
    /// <param name="cmyk">The <see cref="CMYK"/> color.</param>
    /// <returns>The <see cref="HSV"/> color converted from the <see cref="CMYK"/> color.</returns>
    public static HSV ToHSV(CMYK cmyk) => ToHSV(ToRGB(cmyk));

    /// <summary>
    /// Convert <see cref="HSL"/> color to <see cref="HSV"/> color.
    /// </summary>
    /// <param name="hsl">The <see cref="HSL"/> color.</param>
    /// <returns>The <see cref="HSV"/> color converted from the <see cref="HSL"/> color.</returns>
    public static HSV ToHSV(HSL hsl)
    {
        var (h, s, l) = hsl;

        var v = l + s * (l < 0.5 ? l : 1 - l);
        var sv = v == 0 ? 0 : 2 - 2 * l / v;

        return new HSV(h, sv, v);
    }

    #endregion Convert to HSV

    #region Convert to HSL

    /// <summary>
    /// Convert <see cref="RGB"/> color to <see cref="HSL"/> color.
    /// </summary>
    /// <param name="rgb">The <see cref="RGB"/> color.</param>
    /// <returns>The <see cref="HSL"/> color converted from the <see cref="RGB"/> color.</returns>
    public static HSL ToHSL(RGB rgb)
    {
        var (r, g, b) = rgb;

        var rf = r / 255f;
        var gf = g / 255f;
        var bf = b / 255f;

        var max = Math.Max(rf, Math.Max(gf, bf));
        var min = Math.Min(rf, Math.Min(gf, bf));

        float h, s, l;
        l = (max + min) / 2f;

        if (max == min)
        {
            h = s = 0;
        }
        else
        {
            float d = max - min;
            s = l > 0.5 ? d / (2f - max - min) : d / (max + min);

            if (max == rf)
                h = (gf - bf) / d + (gf < bf ? 6f : 0);
            else if (max == gf)
                h = (bf - rf) / d + 2f;
            else
                h = (rf - gf) / d + 4f;

            h /= 6f;
        }

        return new HSL(h * 360, s, l);
    }

    /// <summary>
    /// Convert <see cref="CMYK"/> color to <see cref="HSL"/> color.
    /// </summary>
    /// <param name="cmyk">The <see cref="CMYK"/> color.</param>
    /// <returns>The <see cref="HSL"/> color converted from the <see cref="CMYK"/> color.</returns>
    public static HSL ToHSL(CMYK cmyk) => ToHSL(ToRGB(cmyk));

    /// <summary>
    /// Convert <see cref="HSV"/> color to <see cref="HSL"/> color.
    /// </summary>
    /// <param name="hsv">The <see cref="HSV"/> color.</param>
    /// <returns>The <see cref="HSL"/> color converted from the <see cref="HSV"/> color.</returns>
    public static HSL ToHSL(HSV hsv)
    {
        var (h, s, v) = hsv;

        float l = (2 - s) * v / 2;

        float sl;
        if (l != 0)
        {
            if (l == 1)
                sl = 0;
            else if (l < 0.5)
                sl = s * v / (l * 2);
            else
                sl = s * v / (2 - l * 2);
        }
        else
        {
            sl = 0;
        }

        return new HSL(h, sl, l);
    }

    #endregion Convert to HSL
}
