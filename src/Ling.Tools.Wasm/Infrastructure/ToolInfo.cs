namespace Ling.Tools.Wasm.Infrastructure;

/// <summary>
/// Represents information about a tool.
/// </summary>
/// <param name="Path">Key of the tool, shows in the URL.</param>
/// <param name="Name">Name of the tool, also shows in the HTML title tag.</param>
/// <param name="Description">Description of the tool.</param>
/// <param name="Tags">Tags of the tool.</param>
/// <param name="Icon">Icon of the tool.</param>
[MessagePackObject]
public sealed record ToolInfo(
    [property: Key(0)] string Path,
    [property: Key(1)] string Name,
    [property: Key(2)] string Description,
    [property: Key(3)] string[] Tags,
    [property: Key(4)] Icon Icon);
