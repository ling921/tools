using Ling.Tools.Generate;

namespace Ling.Tools.Web.Shared.Components.Generator;

public sealed partial class HexGenerate : ToolComponentBase<HexGenerateState>
{
    private HexGenerator _generator = default!;

    protected override string PersistentKey => "hex_generate";

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await OnAfterStateChangeAsync();
    }

    protected override Task OnAfterStateChangeAsync()
    {
        _generator = new HexGenerator()
            .UseCase(State.Uppercase ? CaseType.Uppercase : CaseType.Lowercase)
            .SetLength(State.Length);

        return Task.CompletedTask;
    }

    private void Generate()
    {
        try
        {
            State.LastGenerated = Enumerable.Range(0, State.Times).Select(_ => _generator.Generate()).ToList();
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
    }
}
