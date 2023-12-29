namespace Ling.Tools.Web.Shared.Infrastructure;

/// <summary>
/// Represents information about a tool.
/// </summary>
/// <param name="Key">Key of the tool, shows in the URL.</param>
/// <param name="Name">Name of the tool, also shows in the HTML title tag.</param>
/// <param name="Category">Category of the tool.</param>
/// <param name="Description">Description of the tool.</param>
/// <param name="Tags">Tags of the tool.</param>
/// <param name="Icon">Icon of the tool.</param>
/// <param name="ComponentType">Type of the tool component.</param>
[MessagePackObject]
public sealed record ToolInfo(
    [property: Key(0)] string Key,
    [property: Key(1)] string Name,
    [property: Key(2)] string Category,
    [property: Key(3)] string Description,
    [property: Key(4)] string[] Tags,
    [property: Key(5)] Icon Icon,
    [property: Key(6)] Type ComponentType)
{
    [IgnoreMember]
    public string Id => $"{Category}/{Key}".ToLower();
}
