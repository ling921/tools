using Microsoft.FluentUI.AspNetCore.Components.Utilities;

namespace Ling.Tools.Wasm.Components;

public sealed partial class Copyable : FluentComponentBase, IAsyncDisposable
{
    private string _copyBtnText = "Copy";
    private IJSObjectReference _jsModule = default!;
    private ElementReference? _contentElement;

    [Parameter] public string? Text { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public bool Inline { get; set; }
    [Parameter] public Appearance? Appearance { get; set; } = Microsoft.FluentUI.AspNetCore.Components.Appearance.Neutral;
    [Parameter] public string? CopyBtnClass { get; set; }
    [Parameter] public string? CopyBtnStyle { get; set; }

    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

    private string? ClassValue => new CssBuilder(Class)
        .AddClass("copyable")
        .Build();

    private string? CopyBtnClassValue => new CssBuilder(CopyBtnClass)
        .AddClass("copyable-btn")
        .Build();

    private string? StyleValue => new StyleBuilder(Style)
        .AddStyle("display", "inline-block", Inline)
        .AddStyle("position", "relative", !Inline)
        .Build();

    private string? CopyBtnStyleValue => new StyleBuilder(CopyBtnStyle)
        .AddStyle("user-select", "none")
        .AddStyle("position", "absolute", !Inline)
        .Build();

    private string? ChildContentStyleValue => new StyleBuilder(Style)
        .AddStyle("display", "inline-block", Inline)
        .Build();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/copy.js");
        }
    }

    private async Task CopyContent()
    {
        var result = await _jsModule.InvokeAsync<bool>("copyToClipboard", (object?)Text ?? _contentElement);

        _copyBtnText = result ? "Copied!" : "Failed";

        _ = Task.Delay(800).ContinueWith(_ =>
        {
            _copyBtnText = "Copy";
            StateHasChanged();
        }).ConfigureAwait(false);
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_jsModule is not null)
            {
                await _jsModule.DisposeAsync();
            }
        }
        catch (JSDisconnectedException)
        {
            // The JSRuntime side may routinely be gone already if the reason we're disposing is that
            // the client disconnected. This is not an error.
        }
    }
}
