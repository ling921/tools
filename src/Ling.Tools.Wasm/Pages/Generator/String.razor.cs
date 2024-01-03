using Ling.Tools.Wasm.Components.Generator;

namespace Ling.Tools.Wasm.Pages.Generator;

[Route("/gen/string")]
public partial class String : ToolComponentBase<StringGeneratorState>
{
    private StringGenerator Generator { get; set; } = default!;

    protected override string GetPersistentKey() => "gen-string";

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
