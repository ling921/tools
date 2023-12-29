using Ling.Tools.Generator;

namespace Ling.Tools.Web.Shared.Components.Generator;

public sealed partial class StringGenerate : ToolComponentBase<StringGenerateState>
{
    private StringGenerator _generator = default!;

    protected override string PersistentKey => "string_generate";

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await OnAfterStateChangeAsync();
    }

    protected override Task OnAfterStateChangeAsync()
    {
        _generator = new StringGenerator()
            .SetLength(State.Length)
            .AllowIf(State.HasNumber, "0123456789")
            .AllowIf(State.HasUppercaseLetter, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            .AllowIf(State.HasLowercaseLetter, "abcdefghijklmnopqrstuvwxyz");
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
