using Ling.Tools.Random;
using Gen = Ling.Tools.Random.HexGenerator;

namespace Ling.Tools.Wasm.Components.Generator;

public sealed partial class HexGenerator : GeneratorComponentBase<string>
{
    [Parameter]
    public int Length { get; set; }

    [Parameter]
    public bool Uppercase { get; set; }

    public override IGenerator<string> Generator => new Gen()
        .SetLength(Length)
        .UseCase(Uppercase ? CaseType.Uppercase : CaseType.Lowercase);
}
