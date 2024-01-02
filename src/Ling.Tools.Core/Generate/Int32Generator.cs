using System.Diagnostics;
using System.Text;

namespace Ling.Tools.Generate;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class Int32Generator : NumberGeneratorBase<Int32Generator, int>
{
    private bool _minInclusive;
    private bool _maxInclusive;

    private string DebuggerDisplay => new StringBuilder("Range: ")
        .Append(_minInclusive ? "[" : "(")
        .Append(MinValue)
        .Append(", ")
        .Append(MaxValue)
        .Append(_maxInclusive ? "]" : ")")
        .ToString();

    public Int32Generator()
    {
        _minInclusive = true;
        _maxInclusive = true;
    }

    public Int32Generator(int minValue, int maxValue, bool minInclusive = true, bool maxInclusive = true)
        : base(minValue, maxValue)
    {
        _minInclusive = minInclusive;
        _maxInclusive = maxInclusive;
    }

    public override Int32Generator GreaterThan(int minValue)
    {
        MinValue = minValue;
        _minInclusive = false;

        return this;
    }

    public Int32Generator GreaterThanOrEqual(int minValue)
    {
        MinValue = minValue;
        _minInclusive = true;

        return this;
    }

    public override Int32Generator LessThan(int maxValue)
    {
        MaxValue = maxValue;
        _maxInclusive = false;
        return this;
    }

    public Int32Generator LessThanOrEqual(int maxValue)
    {
        MaxValue = maxValue;
        _maxInclusive = true;

        return this;
    }

    public override int Generate()
    {
        ThrowIfRangeInvalid();

        var rndMin = _minInclusive ? MinValue : MinValue + 1;
        var rndMax = _maxInclusive ? MaxValue + 1 : MaxValue;
        return Random.Shared.Next(rndMin, rndMax);
    }

    protected override void ThrowIfRangeInvalid()
    {
        base.ThrowIfRangeInvalid();

        if (MinValue == MaxValue && !_minInclusive && !_maxInclusive)
        {
            throw new ArgumentOutOfRangeException("Range contains no values.");
        }
    }
}
