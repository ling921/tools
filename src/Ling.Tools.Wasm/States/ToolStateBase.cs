namespace Ling.Tools.Wasm.States;

/// <summary>
/// Represents the base class for all tool states.
/// </summary>
[MessagePackObject(true)]
public abstract class ToolStateBase : ObservableObject
{
    /// <summary>
    /// Gets the list of properties that will not trigger <see cref="ToolComponentBase{TState}.OnBeforeStateChangeAsync"/>
    /// and <see cref="ToolComponentBase{TState}.OnAfterStateChangeAsync"/>
    /// </summary>
    [JsonIgnore, IgnoreMember]
    public virtual IReadOnlyCollection<string> NotifyExclusiveProperties => [];
}

/// <summary>
/// Represents the base class for all generator tool states.
/// </summary>
public abstract partial class GeneratorToolStateBase : ToolStateBase
{
    /// <summary>
    /// Gets or sets the number of times to generate.
    /// </summary>
    [ObservableProperty]
    private int _times = 1;

    /// <summary>
    /// Gets the list of last generated strings.
    /// </summary>
    [ObservableProperty]
    public ICollection<string> _lastGenerated = [];

    /// <inheritdoc/>
    public override IReadOnlyCollection<string> NotifyExclusiveProperties => [nameof(Times), nameof(LastGenerated)];
}
