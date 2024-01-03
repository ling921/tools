using Ling.Tools.Random;
using Gen = Ling.Tools.Random.Int64Generator;

namespace Ling.Tools.Wasm.Components.Generator;

public partial class Int64Generator : GeneratorComponentBase<long>
{
    [Parameter]
    public long MinValue { get; set; } = 0;

    [Parameter]
    public bool MinInclusive { get; set; } = true;

    [Parameter]
    public long MaxValue { get; set; } = 100;

    [Parameter]
    public bool MaxInclusive { get; set; } = true;

    public override IGenerator<long> Generator => new Gen(MinValue, MaxValue, MinInclusive, MaxInclusive);
}
