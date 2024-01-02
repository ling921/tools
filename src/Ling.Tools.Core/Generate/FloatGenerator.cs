namespace Ling.Tools.Generate;

public sealed class FloatGenerator : NumberGeneratorBase<FloatGenerator, float>
{
    public FloatGenerator() : base(0, 1)
    {
    }

    public FloatGenerator(float minValue, float maxValue) : base(minValue, maxValue)
    {
    }

    public override float Generate()
    {
        ThrowIfRangeInvalid();

        var range = MaxValue - MinValue;
        var sample = Random.Shared.NextSingle();
        return MinValue + range * sample;
    }
}
