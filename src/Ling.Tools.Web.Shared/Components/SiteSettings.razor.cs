namespace Ling.Tools.Web.Shared.Components;

public sealed partial class SiteSettings
{
    [Inject] IDialogService DialogService { get; set; } = default!;
    [Inject] GlobalState GlobalState { get; set; } = default!;

    private async Task OpenSiteSettingsAsync()
    {
        var dialog = await DialogService.ShowPanelAsync<SiteSettingsPanel>(GlobalState, new DialogParameters<GlobalState>()
        {
            ShowTitle = true,
            Title = "Site settings",
            Content = GlobalState,
            Alignment = HorizontalAlignment.Right,
            PrimaryAction = "OK",
            SecondaryAction = null,
            ShowDismiss = true
        });

        DialogResult result = await dialog.Result;
        HandlePanel(result);
    }

    private void HandlePanel(DialogResult result)
    {
        if (result.Cancelled)
        {
            return;
        }

        if (result.Data is not null)
        {
            GlobalState? state = result.Data as GlobalState;

            GlobalState.SetDirection(state!.Dir);
            GlobalState.SetLuminance(state.Luminance);
            GlobalState.SetColor(state!.Color);

            return;
        }
    }
}
