namespace Ling.Tools.Wasm.States;

/// <summary>
/// Represents the state for the number generator.
/// </summary>
public sealed partial class NumberGeneratorState : GeneratorToolStateBase
{
    /// <summary>
    /// Gets or sets the type of number to generate.
    /// </summary>
    [ObservableProperty]
    private GenerateNumberType _type;

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [ObservableProperty]
    private int _int32Min = int.MinValue;

    /// <summary>
    /// Gets or sets a value indicating whether the minimum value is inclusive.
    /// </summary>
    [ObservableProperty]
    private bool _int32MinInclusive = true;

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [ObservableProperty]
    private int _int32Max = int.MaxValue;

    /// <summary>
    /// Gets or sets a value indicating whether the maximum value is inclusive.
    /// </summary>
    [ObservableProperty]
    private bool _int32MaxInclusive = true;

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [ObservableProperty]
    private long _int64Min = long.MinValue;

    /// <summary>
    /// Gets or sets a value indicating whether the minimum value is inclusive.
    /// </summary>
    [ObservableProperty]
    private bool _int64MinInclusive = true;

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [ObservableProperty]
    private long _int64Max = long.MaxValue;

    /// <summary>
    /// Gets or sets a value indicating whether the maximum value is inclusive.
    /// </summary>
    [ObservableProperty]
    private bool _int64MaxInclusive = true;

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [ObservableProperty]
    private float _floatMin = 0;

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [ObservableProperty]
    private float _floatMax = 1;

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    [ObservableProperty]
    private double _doubleMin = 0;

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [ObservableProperty]
    private double _doubleMax = 1;
}

/// <summary>
/// Represents the type of number to generate.
/// </summary>
public enum GenerateNumberType
{
    /// <summary>
    /// int
    /// </summary>
    Int32,

    /// <summary>
    /// long
    /// </summary>
    Int64,

    /// <summary>
    /// float
    /// </summary>
    Float,

    /// <summary>
    /// double
    /// </summary>
    Double,
}
