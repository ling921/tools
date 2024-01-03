namespace Ling.Tools.Wasm.Pages;

[Route("/")]
public partial class Index
{
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    [Inject] IMessageService MessageService { get; set; } = default!;
    [Inject] IToastService ToastService { get; set; } = default!;
    [Inject] IStringLocalizer L { get; set; } = default!;

    string? SearchText { get; set; }
    IEnumerable<ToolInfo> Tools => string.IsNullOrWhiteSpace(SearchText)
        ? AppDefaults.Tools
        : AppDefaults.Tools.Where(x => x.Name.Contains(SearchText.Trim(), StringComparison.OrdinalIgnoreCase));

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
