using System.Runtime.CompilerServices;

namespace Stride.Shaders.Spirv.Core;

/// <summary>
/// Spirv operand representation, used for parsing spirv.
/// </summary>
public ref struct SpvOperand
{
    public OperandKind Kind { get; init; }
    public OperandQuantifier Quantifier { get; init; }
    public Span<int> Words { get; init; }
    public int Offset { get; init; }

    public SpvOperand(OperandKind kind, OperandQuantifier quantifier, Span<int> words, int idRefOffset = 0)
    {
        Kind = kind;
        Quantifier = quantifier;
        Words = words;
        Offset = idRefOffset;
    }

    public void ReplaceIdResult(int replacement)
    {
        if(Kind == OperandKind.IdResult && replacement > 0)
            Words[0] = replacement;
    }
    public T ToEnum<T>() where T : Enum
    {
        return Unsafe.As<int,T>(ref Words[0]);
    }
    public T To<T>() where T : struct, IFromSpirv<T>
    {
        if (Kind == OperandKind.IdRef && typeof(T) == typeof(IdRef))
        {
            var id = new IdRef(Words[0] + Offset);
            var result = Unsafe.As<IdRef, T>(ref id);
            return result;
        }
        return T.From(Words);
    }

    public override string ToString()
    {
        return Kind switch 
        {
            OperandKind.LiteralString => To<LiteralString>().Value,
            OperandKind.IdRef => $"%{Words[0] + Offset}",
            OperandKind.IdResultType => $"%{Words[0] + Offset}",
            OperandKind.PairLiteralIntegerIdRef => $"{Words[0]} %{Words[0] + Offset}",
            OperandKind.MemoryAccess => $"{ToEnum<Specification.MemoryAccessMask>()}",
            OperandKind.MemoryModel => $"{ToEnum<Specification.MemoryModel>()}",
            OperandKind.MemorySemantics => $"{ToEnum<Specification.MemorySemanticsMask>()}",
            OperandKind.AccessQualifier => $"{ToEnum<Specification.AccessQualifier>()}",
            OperandKind.AddressingModel => $"{ToEnum<Specification.AddressingModel>()}",
            OperandKind.BuiltIn => $"{ToEnum<Specification.BuiltIn>()}",
            OperandKind.Capability => $"{ToEnum<Specification.Capability>()}",
            OperandKind.Decoration => $"{ToEnum<Specification.Decoration>()}",
            OperandKind.Dim => $"{ToEnum<Specification.Dim>()}",
            OperandKind.ExecutionMode => $"{ToEnum<Specification.ExecutionMode>()}",
            OperandKind.ExecutionModel => $"{ToEnum<Specification.ExecutionModel>()}",
            OperandKind.FPFastMathMode => $"{ToEnum<Specification.FPFastMathModeMask>()}",
            OperandKind.FPRoundingMode => $"{ToEnum<Specification.FPRoundingMode>()}",
            OperandKind.FragmentShadingRate => $"{ToEnum<Specification.FragmentShadingRateMask>()}",
            OperandKind.FunctionControl => $"{ToEnum<Specification.FunctionControlMask>()}",
            OperandKind.FunctionParameterAttribute => $"{ToEnum<Specification.FunctionParameterAttribute>()}",
            OperandKind.GroupOperation => $"{ToEnum<Specification.GroupOperation>()}",
            OperandKind.ImageChannelDataType => $"{ToEnum<Specification.ImageChannelDataType>()}",
            OperandKind.ImageChannelOrder => $"{ToEnum<Specification.ImageChannelOrder>()}",
            OperandKind.ImageFormat => $"{ToEnum<Specification.ImageFormat>()}",
            OperandKind.ImageOperands => $"{ToEnum<Specification.ImageOperandsMask>()}",
            OperandKind.KernelEnqueueFlags => $"{ToEnum<Specification.KernelEnqueueFlags>()}",
            OperandKind.KernelProfilingInfo => $"{ToEnum<Specification.KernelProfilingInfoMask>()}",
            OperandKind.LinkageType => $"{ToEnum<Specification.LinkageType>()}",
            OperandKind.None => "",
            _ => Words[0].ToString()
        };
    }
}