using System.Diagnostics;
using System.Text;

namespace Ling.Tools.Generate;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class Int64Generator : NumberGeneratorBase<Int64Generator, long>
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

    public Int64Generator()
    {
        _minInclusive = true;
        _maxInclusive = true;
    }

    public Int64Generator(long minValue, long maxValue, bool minInclusive = true, bool maxInclusive = true)
        : base(minValue, maxValue)
    {
        _minInclusive = minInclusive;
        _maxInclusive = maxInclusive;
    }

    public override Int64Generator GreaterThan(long minValue)
    {
        MinValue = minValue;
        _minInclusive = false;

        return this;
    }

    public Int64Generator GreaterThanOrEqual(long minValue)
    {
        MinValue = minValue;
        _minInclusive = true;

        return this;
    }

    public override Int64Generator LessThan(long maxValue)
    {
        MaxValue = maxValue;
        _maxInclusive = false;
        return this;
    }

    public Int64Generator LessThanOrEqual(long maxValue)
    {
        MaxValue = maxValue;
        _maxInclusive = true;

        return this;
    }

    public override long Generate()
    {
        ThrowIfRangeInvalid();

        var rndMin = _minInclusive ? MinValue : MinValue + 1;
        var rndMax = _maxInclusive ? MaxValue + 1 : MaxValue;
        return Random.Shared.NextInt64(rndMin, rndMax);
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
