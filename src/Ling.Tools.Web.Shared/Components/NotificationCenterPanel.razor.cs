namespace Ling.Tools.Web.Shared.Components;

public sealed partial class NotificationCenterPanel : IDialogContentComponent<GlobalState>
{
    [Inject] IMessageService MessageService { get; set; } = default!;
    [Parameter] public GlobalState Content { get; set; } = default!;
}
