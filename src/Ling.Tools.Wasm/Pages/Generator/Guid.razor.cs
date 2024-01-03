using Ling.Tools.Wasm.Components.Generator;

namespace Ling.Tools.Wasm.Pages.Generator;

[Route("/gen/uuid")]
public partial class Guid : ToolComponentBase<GuidGeneratorState>
{
    private GuidGenerator Generator { get; set; } = default!;

    protected override string GetPersistentKey() => "gen-uuid";

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
