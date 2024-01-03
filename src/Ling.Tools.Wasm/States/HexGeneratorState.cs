namespace Ling.Tools.Wasm.States;

/// <summary>
/// Represents the state for the hexadecimal string generator.
/// </summary>
public sealed partial class HexGeneratorState : GeneratorToolStateBase
{
    /// <summary>
    /// Gets or sets a value indicating whether the generated string should be uppercase.
    /// </summary>
    [ObservableProperty]
    private bool _uppercase = true;

    /// <summary>
    /// Gets or sets the length of the generated string.
    /// </summary>
    [ObservableProperty]
    private int _length = 1;
}
