using Ling.Tools.Web.Shared.Components.Generator;

namespace Ling.Tools.Web.Shared;

internal static class AppDefaults
{
    public const string MESSAGES_NOTIFICATION_CENTER = "NOTIFICATION_CENTER";
    public const string MESSAGES_TOP = "TOP";
    public const string MESSAGES_DIALOG = "DIALOG";
    public const string MESSAGES_CARD = "CARD";

    public static readonly ToolInfo[] Tools = [
        new(
            Key: "string",
            Name: "String Generator",
            Category: "generate",
            Description: "",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info(),
            ComponentType: typeof(StringGenerate)
        ),
        new(
            Key: "hex",
            Name: "Hex Generator",
            Category: "generate",
            Description: "",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info(),
            ComponentType: typeof(HexGenerate)
        ),
        new(
            Key: "number",
            Name: "Number Generator",
            Category: "generate",
            Description: "",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info(),
            ComponentType: typeof(NumberGenerate)
        ),
        new(
            Key: "guid",
            Name: "Guid Generator",
            Category: "generate",
            Description: "",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info(),
            ComponentType: typeof(GuidGenerate)
        ),
        new(
            Key: "password",
            Name: "Password Generator",
            Category: "generate",
            Description: "",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info(),
            ComponentType: typeof(StringGenerate)
        ),
    ];
}
