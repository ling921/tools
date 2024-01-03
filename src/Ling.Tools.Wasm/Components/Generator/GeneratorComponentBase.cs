using Ling.Tools.Random;

namespace Ling.Tools.Wasm.Components.Generator;

/// <summary>
/// Represents a base class for generator components.
/// </summary>
/// <typeparam name="TValue">The type of the generated value.</typeparam>
public abstract class GeneratorComponentBase<TValue> : ComponentBase
    where TValue : notnull
{
    /// <summary>
    /// The string localizer. Injected by dependency injection.
    /// </summary>
    [Inject]
    protected IStringLocalizer L { get; set; } = default!;

    /// <summary>
    /// Gets the generator for type <typeparamref name="TValue"/>.
    /// </summary>
    public abstract IGenerator<TValue> Generator { get; }
}
