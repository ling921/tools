namespace Ling.Tools.Web.Wasm.Pages;

[Route("/{categoty}/{name}")]
public partial class Tool : ComponentBase
{
    private ToolInfo? _info;
    private string Title => _info?.Name ?? "Not Found";

    [Parameter]
    public string Categoty { get; set; } = default!;

    [Parameter]
    public string Name { get; set; } = default!;

    [Inject]
    private ToolService ToolService { get; set; } = default!;

    protected override void OnInitialized()
    {
        _info = ToolService.Find(Categoty, Name);
    }
}
