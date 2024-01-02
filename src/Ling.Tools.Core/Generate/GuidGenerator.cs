using Ling.Tools.Generate;
using System.Diagnostics;
using System.Text;

namespace Ling.Tools;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class GuidGenerator : IGenerator<string>
{
    private CaseType _case = CaseType.Lowercase;
    private bool _excludeHyphen;

    private string DebuggerDisplay => new StringBuilder()
        .Append("Casing: ")
        .Append(_case is CaseType.Lowercase ? "Lowercase" : "Uppercase")
        .Append(", ExcludeHyphen: ")
        .Append(_excludeHyphen)
        .ToString();

    public GuidGenerator UseCase(CaseType @case = CaseType.Lowercase)
    {
        _case = @case;
        return this;
    }

    public GuidGenerator ExcludeHyphen(bool exclude = false)
    {
        _excludeHyphen = exclude;
        return this;
    }

    public string Generate()
    {
        var guid = Guid.NewGuid();
        var text = guid.ToString(_excludeHyphen ? "D" : "N");
        return _case is CaseType.Lowercase ? text : text.ToUpperInvariant();
    }
}
