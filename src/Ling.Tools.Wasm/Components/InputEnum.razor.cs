using System.Diagnostics.CodeAnalysis;

namespace Ling.Tools.Wasm.Components;

public sealed partial class InputEnum<TEnum> : FluentInputBase<TEnum> where TEnum : struct
{
    private readonly bool _isNullable = Nullable.GetUnderlyingType(typeof(TEnum)) is not null;
    private readonly Type _enumType = Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);

    public Dictionary<TEnum, string> Options { get; private set; } = [];

    [Parameter]
    public Orientation Orientation { get; set; } = Orientation.Horizontal;

    protected override Task OnInitializedAsync()
    {
        Options = Enum.GetValues(_enumType)
            .Cast<TEnum>()
            .ToDictionary(x => x, x => x.ToString()!);

        return base.OnInitializedAsync();
    }

    protected override bool TryParseValueFromString(
        string? value,
        [MaybeNullWhen(false)] out TEnum result,
        [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (Enum.TryParse(_enumType, value, out var result1) ||
            Enum.TryParse(_enumType, value, true, out result1))
        {
            result = (TEnum)result1;
            validationErrorMessage = null;
            return true;
        }

        result = default;
        if (_isNullable)
        {
            validationErrorMessage = null;
            return true;
        }
        else
        {
            validationErrorMessage = "Invalid enum value";
            return false;
        }
    }
}
