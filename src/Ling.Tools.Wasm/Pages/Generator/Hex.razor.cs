using Ling.Tools.Wasm.Components.Generator;

namespace Ling.Tools.Wasm.Pages.Generator;

[Route("/gen/hex")]
public partial class Hex : ToolComponentBase<HexGeneratorState>
{
    private HexGenerator Generator { get; set; } = default!;

    protected override string GetPersistentKey() => "gen-hex";

    void Generate()
    {
        try
        {
            var generator = Generator.Generator;
            State.LastGenerated = Enumerable.Range(0, State.Times).Select(_ => generator.Generate()).ToList();
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
    }
}
