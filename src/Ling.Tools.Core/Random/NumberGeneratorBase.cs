using System.Diagnostics;
using System.Numerics;

namespace Ling.Tools.Random;

[DebuggerDisplay("Range: [{MinValue}, {MaxValue})")]
public abstract class NumberGeneratorBase<TGenerator, T> : IGenerator<T>
    where TGenerator : NumberGeneratorBase<TGenerator, T>
    where T : INumber<T>
{
    protected T MinValue { get; set; } = default!;
    protected T MaxValue { get; set; } = default!;

    protected NumberGeneratorBase()
    {
    }

    protected NumberGeneratorBase(T minValue, T maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;

        ThrowIfRangeInvalid();
    }

    public abstract T Generate();

    public virtual TGenerator SetRange(T minValue, T maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;

        ThrowIfRangeInvalid();

        return AsTGenerator();
    }

    public virtual TGenerator GreaterThan(T minValue)
    {
        MinValue = minValue;

        return AsTGenerator();
    }

    public virtual TGenerator LessThan(T maxValue)
    {
        MaxValue = maxValue;

        return AsTGenerator();
    }

    protected virtual void ThrowIfRangeInvalid()
    {
        if (MinValue > MaxValue)
        {
            throw new ArgumentOutOfRangeException("Minimum value cannot be greater than maximum value.");
        }
    }

    private TGenerator AsTGenerator() => (this as TGenerator)!;
}
