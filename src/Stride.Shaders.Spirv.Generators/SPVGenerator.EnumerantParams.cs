using AngleSharp.Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Concurrent;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Stride.Shaders.Spirv.Generators;

public partial class SPVGenerator : IIncrementalGenerator
{

    public void GenerateEnumerantParameters(IncrementalGeneratorInitializationContext context, IncrementalValueProvider<SpirvGrammar> grammarProvider)
    {
        context.RegisterImplementationSourceOutput(
            grammarProvider,
            GenerateEnumerantParametersStructs
        );
    }

    public static void GenerateEnumerantParametersStructs(SourceProductionContext spc, SpirvGrammar grammar)
    {
        if (grammar.OperandKinds?.AsDictionary()?.Values?.ToList() is List<OpKind> opkinds)
        {
            spc.AddSource(
                $"EnumerantParameters.gen.cs",
                SourceText.From(
                    SyntaxFactory
                    .ParseCompilationUnit(@$"
                        using static Stride.Shaders.Spirv.Specification;
                        using CommunityToolkit.HighPerformance;
                        using CommunityToolkit.HighPerformance.Buffers;
                        using Stride.Shaders.Spirv.Core.Buffers;
                        using System.Numerics;
                        using System.Runtime.CompilerServices;

                        namespace Stride.Shaders.Spirv.Core;
                        
                        {string.Join("\n", opkinds.Where(k => (k.Enumerants?.AsList() ?? []).Any(e => (e.Parameters?.AsList() ?? []).Count > 0)).Select(i => GenerateEnumerantParametersKind(i, grammar)))}
                        
                    ")
                    .NormalizeWhitespace()
                    .ToFullString(),
                    Encoding.UTF8
                )
            );
        }
    }
    public static string GenerateEnumerantParametersKind(in OpKind opkind, in SpirvGrammar grammar)
    {
        var sb = StringBuilderPool.Get();
        sb.AppendLine($"\tpublic static class {opkind.Kind}Parameters")
            .AppendLine("{");
        foreach (var enumerant in (opkind.Enumerants?.AsList() ?? []).Where(e => (e.Parameters?.AsList() ?? []).Count > 0))
        {
            

            if (enumerant.Parameters?.AsList() is List<EnumerantParameter> { Count: > 0 } parameters)
            {
                var structName = enumerant.Name switch
                {
                    "FPFastMathMode" => "FPFastMathModeParameter",
                    "FPRoundingMode" => "FPRoundingModeParameter",
                    "BuiltIn" => "BuiltInParameter",
                    _ => enumerant.Name
                };
                sb.AppendLine($"public ref struct {structName} : IEnumerantParameter<{structName}>")
                    .AppendLine("{");

                

                if(parameters is [{} onlyParam] && (onlyParam.Kind == enumerant.Name || $"{onlyParam.Name?[0..1].ToUpperInvariant()}{onlyParam.Name?[1..]}" == enumerant.Name))
                {
                    var typename = onlyParam.Kind switch
                    {
                        "LiteralString" => "string",
                        "LiteralInteger" or "IdRef" => "int",
                        "LiteralFloat" => "float",
                        "FPFastMathMode" => "FPFastMathModeMask",
                        _ => onlyParam.Kind
                    };
                    sb.AppendLine($"public {typename} Value {{ get; set; }}");
                }
                else
                {
                    
                    foreach (var parameter in parameters)
                    {
                        var typename = parameter.Kind switch
                        {
                            "LiteralString" => "string",
                            "LiteralInteger" or "IdRef" => "int",
                            "LiteralFloat" => "float",
                            "FPFastMathMode" => "FPFastMathModeMask",
                            _ => parameter.Kind
                        };
                        sb.AppendLine($"\tpublic {typename} {parameter.Name?[0..1].ToUpperInvariant()}{parameter.Name?[1..]} {{ get; set; }}");

                    }
                }
                sb.Append(@$"
                public static {structName} Create(Span<int> words)
                {{
                    var parameter = new {structName}();
                    return parameter;
                }}

                public static implicit operator EnumerantParameters({structName} parameter)
                {{
                    Span<int> span = [");

                foreach(var parameter in parameters)
                {
                    if(parameter != parameters[0])
                        sb.Append(", ");
                    var typename = parameter.Kind switch
                        {
                            "LiteralString" => "string",
                            "LiteralInteger" or "IdRef" => "int",
                            "LiteralFloat" => "float",
                            "FPFastMathMode" => "FPFastMathModeMask",
                            _ => parameter.Kind
                        };
                    var pName = $"parameter.{parameter.Name?[0..1].ToUpperInvariant()}{parameter.Name?[1..]}";
                    if(parameters.Count == 1 && (parameter.Kind == enumerant.Name || $"{parameter.Name?[0..1].ToUpperInvariant()}{parameter.Name?[1..]}" == enumerant.Name))
                        pName = "parameter.Value";

                    
                    if(parameter.Kind is "LiteralInteger" or "IdRef")
                        sb.Append($"{pName}");
                    else if(parameter.Kind is "LiteralFloat")
                        sb.Append($"BitConverter.SingleToInt32Bits({pName})");
                    else if(parameter.Kind is "LiteralString")
                        sb.Append($"..{pName}.AsDisposableLiteralValue().Words");
                    else 
                        sb.Append($"(int){pName}");
                }
                sb.AppendLine("];");
                sb.AppendLine(@"
                    MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
                    span.CopyTo(buffer.Span);
                    var result = new EnumerantParameters(buffer);
                    return result;
                }
                ");

                sb.AppendLine("}");
            }
        }
        sb.AppendLine("}");
        StringBuilderPool.Return(sb);
        return sb.ToString();
    }

}