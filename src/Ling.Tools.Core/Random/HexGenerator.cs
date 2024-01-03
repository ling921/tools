using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Ling.Tools.Random;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class HexGenerator : IGenerator<string>
{
    private int _length = 1;
    private CaseType _case = CaseType.Uppercase;

    private string DebuggerDisplay => new StringBuilder()
        .Append("Length: ")
        .Append(_length)
        .Append(", Casing: ")
        .Append(_case is CaseType.Uppercase ? "Uppercase" : "Lowercase")
        .ToString();

    public HexGenerator SetLength(int length)
    {
        _length = length;
        return this;
    }

    public HexGenerator UseCase(CaseType @case = CaseType.Uppercase)
    {
        _case = @case;
        return this;
    }

    public string Generate()
    {
        using var rng = RandomNumberGenerator.Create();
        var isEven = _length % 2 == 0;
        var buffer = new byte[_length / 2 + (isEven ? 0 : 1)];
        rng.GetBytes(buffer);
        var text = BitConverter.ToString(buffer).Replace("-", "");
        var hex = isEven ? text : text[..^1];
        return _case is CaseType.Uppercase ? hex : hex.ToLowerInvariant();
    }
}