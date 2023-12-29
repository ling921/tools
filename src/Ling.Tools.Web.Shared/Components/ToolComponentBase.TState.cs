using System.ComponentModel;

namespace Ling.Tools.Web.Shared.Components;

/// <summary>
/// Represents a base class for tool components with a <typeparamref name="TState"/>.
/// <para>
/// The <typeparamref name="TState"/> will be stored in local storage automatically.
/// </para>
/// </summary>
/// <typeparam name="TState">The type of the state for the tool component.</typeparam>
public abstract class ToolComponentBase<TState> : ToolComponentBase
    where TState : ToolStateBase, new()
{
    /// <summary>
    /// Gets the persistent key used to store the <typeparamref name="TState"/>.
    /// </summary>
    protected virtual string PersistentKey => "tool_component";

    /// <summary>
    /// Gets the <typeparamref name="TState"/> of the component.
    /// </summary>
    protected TState State { get; private set; } = default!;

    private async void InternalBeforeStateChangeAsync(object? sender, PropertyChangingEventArgs e)
    {
        if (!State.NotifyExclusiveProperties.Contains(e.PropertyName))
        {
            await OnBeforeStateChangeAsync();
        }
    }

    private async void InternalAfterStateChangeAsync(object? sender, PropertyChangedEventArgs e)
    {
        if (!State.NotifyExclusiveProperties.Contains(e.PropertyName))
        {
            await OnAfterStateChangeAsync();
        }
        await Storage.SetAsync(PersistentKey, State);
    }

    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        var state = await Storage.GetAsync<TState>(PersistentKey);
        State = state ?? new();
        State.PropertyChanging += InternalBeforeStateChangeAsync;
        State.PropertyChanged += InternalAfterStateChangeAsync;
    }

    /// <summary>
    /// Called before the <typeparamref name="TState"/> is changed.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual Task OnBeforeStateChangeAsync()
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Called after the <typeparamref name="TState"/> is changed.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual Task OnAfterStateChangeAsync()
    {
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    protected override async ValueTask DisposeAsync(bool disposing)
    {
        await base.DisposeAsync(disposing);

        State.PropertyChanging -= InternalBeforeStateChangeAsync;
        State.PropertyChanged -= InternalAfterStateChangeAsync;

        await Storage.SetAsync(PersistentKey, State);
        await Console.Out.WriteLineAsync("State saved");
    }
}
