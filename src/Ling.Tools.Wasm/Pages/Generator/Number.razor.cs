using Ling.Tools.Wasm.Components.Generator;

namespace Ling.Tools.Wasm.Pages.Generator;

[Route("/gen/number")]
public partial class Number : ToolComponentBase<NumberGeneratorState>
{
    private Int32Generator Int32Generator { get; set; } = default!;
    private Int64Generator Int64Generator { get; set; } = default!;
    private FloatGenerator FloatGenerator { get; set; } = default!;
    private DoubleGenerator DoubleGenerator { get; set; } = default!;

    protected override string GetPersistentKey() => "gen-number";

    void Generate()
    {
        try
        {
            switch (State.Type)
            {
                case GenerateNumberType.Int32:
                    {
                        var generator = Int32Generator.Generator;
                        State.LastGenerated = Enumerable.Range(0, State.Times)
                            .Select(_ => generator.Generate().ToString())
                            .ToList();
                    }
                    break;
                case GenerateNumberType.Int64:
                    {
                        var generator = Int64Generator.Generator;
                        State.LastGenerated = Enumerable.Range(0, State.Times)
                            .Select(_ => generator.Generate().ToString())
                            .ToList();
                    }
                    break;
                case GenerateNumberType.Float:
                    {
                        var generator = FloatGenerator.Generator;
                        State.LastGenerated = Enumerable.Range(0, State.Times)
                            .Select(_ => generator.Generate().ToString())
                            .ToList();
                    }
                    break;
                case GenerateNumberType.Double:
                    {
                        var generator = DoubleGenerator.Generator;
                        State.LastGenerated = Enumerable.Range(0, State.Times)
                            .Select(_ => generator.Generate().ToString())
                            .ToList();
                    }
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            HandleError(ex);
        }
    }
}
