using Ling.Tools.Random;
using Gen = Ling.Tools.Random.DoubleGenerator;

namespace Ling.Tools.Wasm.Components.Generator;

public partial class DoubleGenerator : GeneratorComponentBase<double>
{
    [Parameter]
    public double MinValue { get; set; } = 0;

    [Parameter]
    public double MaxValue { get; set; } = 1;

    public override IGenerator<double> Generator => new Gen(MinValue, MaxValue);
}
