namespace Ling.Tools.Web.Shared.Components.Generator;

public sealed partial class GuidGenerate : ToolComponentBase<GuidGenerateState>
{
    private GuidGenerator _generator = default!;

    protected override string PersistentKey => "guid_generate";

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await OnAfterStateChangeAsync();
    }

    protected override Task OnAfterStateChangeAsync()
    {
        _generator = new GuidGenerator()
            .UseCase(State.Lowercase ? CaseType.Lowercase : CaseType.Uppercase)
            .ExcludeHyphen(State.ExcludeHyphen);

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
