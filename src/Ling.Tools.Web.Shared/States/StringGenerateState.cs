using Ling.Tools.Web.Shared.Components.Generator;

namespace Ling.Tools.Web.Shared.States;

/// <summary>
/// Represents the state of component <see cref="StringGenerate"/>.
/// </summary>
public sealed partial class StringGenerateState : GeneratorToolStateBase
{
    /// <summary>
    /// Gets or sets a value indicating whether to include numbers(0-9) in the generated string.
    /// </summary>
    [ObservableProperty]
    private bool _hasNumber = true;

    /// <summary>
    /// Gets or sets a value indicating whether to include uppercase letters(A-Z) in the generated string.
    /// </summary>
    [ObservableProperty]
    private bool _hasUppercaseLetter = true;

    /// <summary>
    /// Gets or sets a value indicating whether to include lowercase letters(a-z) in the generated string.
    /// </summary>
    [ObservableProperty]
    private bool _hasLowercaseLetter = true;

    /// <summary>
    /// Gets or sets the length of the generated string.
    /// </summary>
    [ObservableProperty]
    private int _length = 1;
}
