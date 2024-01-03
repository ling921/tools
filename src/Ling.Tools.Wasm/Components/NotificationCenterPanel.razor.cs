namespace Ling.Tools.Wasm.Components;

public sealed partial class NotificationCenterPanel : IDialogContentComponent<GlobalState>
{
    [Inject] IMessageService MessageService { get; set; } = default!;
    [Parameter] public GlobalState Content { get; set; } = default!;
}
