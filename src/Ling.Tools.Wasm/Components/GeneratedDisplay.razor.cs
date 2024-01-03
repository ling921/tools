namespace Ling.Tools.Wasm.Components;

public sealed partial class GeneratedDisplay : ComponentBase
{
    [Parameter]
    public IEnumerable<string> Values { get; set; } = [];
}
