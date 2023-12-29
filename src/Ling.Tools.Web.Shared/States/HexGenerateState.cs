using Ling.Tools.Web.Shared.Components.Generator;

namespace Ling.Tools.Web.Shared.States;

/// <summary>
/// Represents the state of component <see cref="HexGenerate"/>.
/// </summary>
public sealed partial class HexGenerateState : GeneratorToolStateBase
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
