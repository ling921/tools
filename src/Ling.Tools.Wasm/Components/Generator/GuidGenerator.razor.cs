using Ling.Tools.Random;
using Gen = Ling.Tools.Random.GuidGenerator;

namespace Ling.Tools.Wasm.Components.Generator;

public sealed partial class GuidGenerator : GeneratorComponentBase<string>
{
    [Parameter]
    public bool Lowercase { get; set; }

    [Parameter]
    public bool ExcludeHyphens { get; set; }

    public override IGenerator<string> Generator => new Gen()
        .UseCase(Lowercase ? CaseType.Lowercase : CaseType.Uppercase)
        .ExcludeHyphens(ExcludeHyphens);
}
