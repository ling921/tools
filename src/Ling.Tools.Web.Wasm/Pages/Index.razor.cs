namespace Ling.Tools.Web.Wasm.Pages;

[Route("/")]
public partial class Index
{
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    [Inject] IMessageService MessageService { get; set; } = default!;
    [Inject] IToastService ToastService { get; set; } = default!;
    [Inject] ToolService ToolService { get; set; } = default!;

    IEnumerable<ToolInfo> AllTools => ToolService.All();
    IEnumerable<ToolInfo> FilteredTools => AllTools;

    void OnBreakpointEnterHandler(GridItemSize size)
    {
        Console.WriteLine($"Page Size: {size}");
    }

    void OnToolClick(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            ToastService.ShowInfo("No tool selected");
        }
        else
        {
            NavigationManager.NavigateTo(path);
        }
    }
}
