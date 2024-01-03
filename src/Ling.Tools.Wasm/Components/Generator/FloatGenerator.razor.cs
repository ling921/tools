using Ling.Tools.Random;
using Gen = Ling.Tools.Random.FloatGenerator;

namespace Ling.Tools.Wasm.Components.Generator;

public partial class FloatGenerator : GeneratorComponentBase<float>
{
    [Parameter]
    public float MinValue { get; set; } = 0;

    [Parameter]
    public float MaxValue { get; set; } = 1;

    public override IGenerator<float> Generator => new Gen(MinValue, MaxValue);
}
