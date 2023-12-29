using Ling.Tools.Web.Shared.Components.Generator;

namespace Ling.Tools.Web.Shared.States;

/// <summary>
/// Represents the state of component <see cref="GuidGenerate"/>.
/// </summary>
public sealed partial class GuidGenerateState : GeneratorToolStateBase
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
