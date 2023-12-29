namespace Ling.Tools.Web.Shared.Components;

/// <summary>
/// Represents a base class for tool components.
/// </summary>
public abstract class ToolComponentBase : ComponentBase, IAsyncDisposable
{
    private bool _disposed;

    /// <summary>
    /// The string localizer. Injected by dependency injection.
    /// </summary>
    [Inject]
    protected IStringLocalizer L { get; set; } = default!;

    /// <summary>
    /// The message service. Injected by dependency injection.
    /// </summary>
    [Inject]
    protected IMessageService MessageService { get; set; } = default!;

    /// <summary>
    /// The toast service. Injected by dependency injection.
    /// </summary>
    [Inject]
    protected IToastService ToastService { get; set; } = default!;

    /// <summary>
    /// The local storage service. Injected by dependency injection.
    /// </summary>
    [Inject]
    protected LocalStorage Storage { get; set; } = default!;

    /// <summary>
    /// Handles an error.
    /// </summary>
    /// <param name="ex">The exception to handle.</param>
    protected virtual void HandleError(Exception ex)
    {
        MessageService.ShowMessageBar("An error occurred: " + ex.Message, MessageIntent.Error);
        ToastService.ShowError("An error occurred: " + ex.Message, 2000);
    }

    /// <summary>
    /// Disposes the component.
    /// </summary>
    /// <param name="disposing">Whether to dispose managed resources.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    protected virtual ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;

            // Dispose managed resources
        }

        // Dispose unmanaged resources

        return ValueTask.CompletedTask;
    }

    /// <inheritdoc/>
    ValueTask IAsyncDisposable.DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return DisposeAsync(true);
    }
}
