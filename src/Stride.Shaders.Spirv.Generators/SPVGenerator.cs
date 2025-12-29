using Microsoft.CodeAnalysis;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Concurrent;

namespace Stride.Shaders.Spirv.Generators;


[Generator]
public partial class SPVGenerator : IIncrementalGenerator
{
    static readonly JsonSerializerOptions options = new();

    static ConcurrentBag<(string filename, string content)> generatedFiles = new();

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        if (!options.Converters.Any(x => x is EquatableListJsonConverter<OperandData>))
            options.Converters.Add(new EquatableListJsonConverter<OperandData>());
        if (!options.Converters.Any(x => x is EquatableListJsonConverter<InstructionData>))
            options.Converters.Add(new EquatableListJsonConverter<InstructionData>());
        if (!options.Converters.Any(x => x is EquatableListJsonConverter<OpKind>))
            options.Converters.Add(new EquatableListJsonConverter<OpKind>());
        if (!options.Converters.Any(x => x is EquatableListJsonConverter<Enumerant>))
            options.Converters.Add(new EquatableListJsonConverter<Enumerant>());
        if (!options.Converters.Any(x => x is EquatableListJsonConverter<string>))
            options.Converters.Add(new EquatableListJsonConverter<string>());
        if (!options.Converters.Any(x => x is EquatableListJsonConverter<EnumerantParameter>))
            options.Converters.Add(new EquatableListJsonConverter<EnumerantParameter>());
        var grammarData =
            context
            .AdditionalTextsProvider
            .Where(IsSpirvSpecification)
            .Collect()
            .Select(PreProcessGrammar)
            .Select(PreProcessEnumerants)
            .Select(PreProcessInstructions);

        
        GenerateKinds(context, grammarData);
        CreateInfo(context, grammarData);
        CreateSDSLOp(context, grammarData);
        GenerateStructs(context, grammarData);
        CreateSpecification(context, grammarData);
        CreateParameterizedFuncs(context, grammarData);
    }
}