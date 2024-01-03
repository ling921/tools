namespace Ling.Tools.Wasm.Components;

public sealed partial class NotificationCenter : IDisposable
{
    [Inject] IDialogService DialogService { get; set; } = default!;
    [Inject] IMessageService MessageService { get; set; } = default!;

    protected override void OnInitialized()
    {
        MessageService.OnMessageItemsUpdated += UpdateCount;
    }

    private void UpdateCount()
    {
        InvokeAsync(StateHasChanged);
    }

    private async Task OpenNotificationCenterAsync()
    {
        var dialog = await DialogService.ShowPanelAsync<NotificationCenterPanel>(new DialogParameters<GlobalState>()
        {
            Alignment = HorizontalAlignment.Right,
            Title = "Notifications",
            PrimaryAction = null,
            SecondaryAction = null,
            ShowDismiss = true
        });

        DialogResult result = await dialog.Result;
        HandlePanel(result);
    }

    private static void HandlePanel(DialogResult result)
    {
        if (result.Cancelled)
        {
            return;
        }

        if (result.Data is not null)
        {
            return;
        }
    }

    public void Dispose()
    {
        MessageService.OnMessageItemsUpdated -= UpdateCount;
    }
}
