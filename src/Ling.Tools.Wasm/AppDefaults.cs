using Ling.Tools.Wasm.Components.Generator;

namespace Ling.Tools.Wasm;

internal static class AppDefaults
{
    public const string MESSAGES_NOTIFICATION_CENTER = "NOTIFICATION_CENTER";
    public const string MESSAGES_TOP = "TOP";
    public const string MESSAGES_DIALOG = "DIALOG";
    public const string MESSAGES_CARD = "CARD";
    public const string TOOL_MESSAGES = "TOOL_MESSAGES";

    public static readonly ToolInfo[] Tools = [
        new(
            Path: "/gen/string",
            Name: "String Generator",
            Description: "Generate random strings",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info()
        ),
        new(
            Path: "/gen/hex",
            Name: "Hexadecimal Generator",
            Description: "Generate random hexadecimal strings",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info()
        ),
        new(
            Path: "/gen/number",
            Name: "Number Generator",
            Description: "Generate random numbers",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info()
        ),
        new(
            Path: "/gen/uuid",
            Name: "UUID Generator",
            Description: "Generate random UUID strings",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info()
        ),
        new(
            Path: "/gen/password",
            Name: "Password Generator",
            Description: "Generate random strong passwords",
            Tags: [],
            Icon: new Icons.Regular.Size24.Info()
        ),
    ];
}
