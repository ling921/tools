using System.Diagnostics;
using System.Text;

namespace Ling.Tools.Generate;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class StringGenerator : IGenerator<string>
{
    private readonly HashSet<char> _characters = [];
    private char[]? _charList;
    private int _length = 1;

    private string DebuggerDisplay => new StringBuilder()
        .Append("Length: ")
        .Append(_length)
        .Append(", Characters: ")
        .Append(_charList)
        .ToString();

    public StringGenerator()
    {
    }

    public StringGenerator(ReadOnlySpan<char> chars)
    {
        foreach (var c in chars)
        {
            _characters.Add(c);
        }
        _charList = null;
    }

    public StringGenerator(ReadOnlySpan<char> chars, int length) : this(chars)
    {
        _length = length;
    }

    public string Generate()
    {
        ThrowIfInvalid();

        _charList ??= [.. _characters];

        var chars = new char[_length];
        for (var i = 0; i < _length; i++)
        {
            chars[i] = _charList[Random.Shared.Next(0, _charList.Length)];
        }

        return new string(chars);
    }

    public StringGenerator Allow(ReadOnlySpan<char> chars)
    {
        foreach (var c in chars)
        {
            _characters.Add(c);
        }
        _charList = null;
        return this;
    }

    public StringGenerator AllowIf(bool condition, ReadOnlySpan<char> chars)
    {
        if (condition)
        {
            Allow(chars);
        }
        return this;
    }

    public StringGenerator Disallow(ReadOnlySpan<char> chars)
    {
        foreach (var c in chars)
        {
            _characters.Remove(c);
        }
        _charList = null;
        return this;
    }

    public StringGenerator DisallowIf(bool condition, ReadOnlySpan<char> chars)
    {
        if (condition)
        {
            Disallow(chars);
        }
        return this;
    }

    public StringGenerator SetLength(int length)
    {
        _length = length;
        return this;
    }

    private void ThrowIfInvalid()
    {
        if (_length < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(_length), "Length cannot be less than 1.");
        }

        if (_characters.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(_characters), "Characters cannot be empty.");
        }
    }
}
