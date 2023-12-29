namespace Ling.Tools.Web.Shared.Services;

public sealed class ToolService
{
    private readonly Dictionary<string, ToolInfo> _tools = new(StringComparer.OrdinalIgnoreCase);

    public ToolService(IEnumerable<ToolInfo> tools)
    {
        foreach (var tool in tools)
        {
            var keyName = $"{tool.Category}/{tool.Key}" + Random.Shared.Next();
            _tools[keyName] = tool;
        }
    }

    public IEnumerable<ToolInfo> All() => _tools.Values;

    public ToolInfo? Find(string category, string key)
    {
        var keyName = $"{category}/{key}";
        //return _tools.TryGetValue(keyName, out var tool) ? tool : null;
        return _tools.Values.FirstOrDefault(x => string.Equals(x.Id, keyName, StringComparison.OrdinalIgnoreCase));
    }
}
