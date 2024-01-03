using System.Diagnostics;
using System.Text;

namespace Ling.Tools.Random;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class GuidGenerator : IGenerator<string>
{
    private CaseType _case = CaseType.Lowercase;
    private bool _excludeHyphens;

    private string DebuggerDisplay => new StringBuilder()
        .Append("Casing: ")
        .Append(_case is CaseType.Lowercase ? "Lowercase" : "Uppercase")
        .Append(", ExcludeHyphens: ")
        .Append(_excludeHyphens)
        .ToString();

    public GuidGenerator UseCase(CaseType @case = CaseType.Lowercase)
    {
        _case = @case;
        return this;
    }

    public GuidGenerator ExcludeHyphens(bool exclude = false)
    {
        _excludeHyphens = exclude;
        return this;
    }

    public string Generate()
    {
        var guid = Guid.NewGuid();
        var text = guid.ToString(_excludeHyphens ? "D" : "N");
        return _case is CaseType.Lowercase ? text : text.ToUpperInvariant();
    }
}
