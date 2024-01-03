using Ling.Tools.Random;
using Gen = Ling.Tools.Random.Int32Generator;

namespace Ling.Tools.Wasm.Components.Generator;

public partial class Int32Generator : GeneratorComponentBase<int>
{
    [Parameter]
    public int MinValue { get; set; } = 0;

    [Parameter]
    public bool MinInclusive { get; set; } = true;

    [Parameter]
    public int MaxValue { get; set; } = 100;

    [Parameter]
    public bool MaxInclusive { get; set; } = true;

    public override IGenerator<int> Generator => new Gen(MinValue, MaxValue, MinInclusive, MaxInclusive);
}
