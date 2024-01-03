namespace Ling.Tools.Wasm.States;

/// <summary>
/// Represents the state for the GUID generator.
/// </summary>
public sealed partial class GuidGeneratorState : GeneratorToolStateBase
{
    /// <summary>
    /// Gets or sets a value indicating whether to use uppercase.
    /// </summary>
    [ObservableProperty]
    private bool _lowercase = true;

    /// <summary>
    /// Gets or sets a value indicating whether to exclude hyphen.
    /// </summary>
    [ObservableProperty]
    private bool _excludeHyphen = true;
}
