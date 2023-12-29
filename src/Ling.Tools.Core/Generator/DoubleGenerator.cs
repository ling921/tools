namespace Ling.Tools.Generator;

public sealed class DoubleGenerator : NumberGeneratorBase<DoubleGenerator, double>
{
    public DoubleGenerator() : base(0, 1)
    {
    }

    public DoubleGenerator(double minValue, double maxValue) : base(minValue, maxValue)
    {
    }

    public override double Generate()
    {
        ThrowIfRangeInvalid();

        var range = MaxValue - MinValue;
        var sample = Random.Shared.NextDouble();
        return MinValue + range * sample;
    }
}
