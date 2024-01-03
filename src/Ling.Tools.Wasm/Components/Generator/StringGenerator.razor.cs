using Ling.Tools.Random;
using Gen = Ling.Tools.Random.StringGenerator;

namespace Ling.Tools.Wasm.Components.Generator;

public sealed partial class StringGenerator : GeneratorComponentBase<string>
{
    [Parameter]
    public int Length { get; set; } = 6;

    [Parameter]
    public bool HasNumber { get; set; } = true;

    [Parameter]
    public bool HasUppercaseLetter { get; set; } = true;

    [Parameter]
    public bool HasLowercaseLetter { get; set; } = true;

    public override IGenerator<string> Generator => new Gen()
        .SetLength(Length)
        .AllowIf(HasNumber, "0123456789")
        .AllowIf(HasUppercaseLetter, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        .AllowIf(HasLowercaseLetter, "abcdefghijklmnopqrstuvwxyz");
}
