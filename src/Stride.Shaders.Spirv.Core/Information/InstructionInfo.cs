using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Shaders.Spirv.Core.Buffers;
using static Stride.Shaders.Spirv.Specification;

namespace Stride.Shaders.Spirv.Core;


/// <summary>
/// Singleton object containing informations on every spirv instructions, used for spirv parsing.
/// </summary>
public partial class InstructionInfo
{
    public static InstructionInfo Instance { get; } = new();
    readonly Dictionary<Op, LogicalOperandArray> Info = [];

    /// <summary>
    /// Register information about a SPIR-V instruction
    /// </summary>
    /// <param name="op"></param>
    /// <param name="kind"></param>
    /// <param name="quantifier"></param>
    /// <param name="name"></param>
    /// <param name="spvClass"></param>
    internal void Register(Op op, OperandKind? kind, OperandQuantifier? quantifier, string? name = null, string? spvClass = null, OperandParameters? parameters = null)
    {
        if (Info.TryGetValue(op, out var list))
            list.Add(new(name, kind, quantifier, parameters ?? []));
        else
            Info.Add(op, new(spvClass, [new(name, kind, quantifier, parameters ?? [])]));
    }

    public static LogicalOperandArray GetInfo(Op op)
        => Instance.Info[op];
    public static LogicalOperandArray GetInfo(Span<int> words) 
        => GetInfo((Op)(words[0] & 0xFFFF));

    public static LogicalOperandArray GetInfo(Instruction instruction) 
        => GetInfo(instruction.Words);
        

    // public static LogicalOperandArray GetInfo(Instruction instruction)
    // {
    //     return instruction switch
    //     {
    //         { OpCode: Op.OpExecutionMode or Op.OpExecutionModeId } => GetInfo(new OperandKey<ExecutionMode>(instruction.OpCode, (ExecutionMode)instruction.Operands[2])),
    //         { OpCode: Op.OpDecorate or Op.OpDecorateId } => GetInfo(new OperandKey<Decoration>(instruction.OpCode, (Decoration)instruction.Operands[1])),
    //         { OpCode: Op.OpDecorateString } => GetInfo(new OperandKey<Decoration>(instruction.OpCode, (Decoration)instruction.Operands[1])),
    //         { OpCode: Op.OpMemberDecorate } => GetInfo(new OperandKey<Decoration>(instruction.OpCode, (Decoration)instruction.Operands[2])),
    //         { OpCode: Op.OpMemberDecorateString } => GetInfo(new OperandKey<Decoration>(instruction.OpCode, (Decoration)instruction.Operands[2])),
    //         { OpCode: Op.OpLoopMerge } => GetInfo(new OperandKey<LoopControlMask>(instruction.OpCode, (LoopControlMask)instruction.Operands[2])),
    //         { OpCode: Op.OpLoad } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[4])),
    //         { OpCode: Op.OpStore } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[3])),
    //         { OpCode: Op.OpCopyMemory } when instruction.Operands.Length > 2 => GetInfo(new OperandKey<MemoryAccessMask, MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[3], (MemoryAccessMask)instruction.Operands[4])),
    //         { OpCode: Op.OpCopyMemorySized } when instruction.Operands.Length > 3 => GetInfo(new OperandKey<MemoryAccessMask, MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[4], (MemoryAccessMask)instruction.Operands[5])),
    //         { OpCode: Op.OpCooperativeMatrixLoadKHR } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[6])),
    //         { OpCode: Op.OpCooperativeMatrixStoreKHR } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[5])),
    //         { OpCode: Op.OpCooperativeMatrixLoadNV } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[6])),
    //         { OpCode: Op.OpCooperativeMatrixStoreNV } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[5])),
    //         { OpCode: Op.OpCooperativeMatrixLoadTensorNV } => GetInfo(new OperandKey<MemoryAccessMask, TensorAddressingOperandsMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[6], (TensorAddressingOperandsMask)instruction.Operands[7])),
    //         { OpCode: Op.OpCooperativeMatrixStoreTensorNV } => GetInfo(new OperandKey<MemoryAccessMask, TensorAddressingOperandsMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[4], (TensorAddressingOperandsMask)instruction.Operands[5])),
    //         { OpCode: Op.OpSubgroupBlockPrefetchINTEL } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.OpCode, (MemoryAccessMask)instruction.Operands[3])),
    //         { OpCode: var op } => GetInfo(op),
    //     };
    // }
    public static LogicalOperandArray GetInfo(OpData instruction)
    {
        return GetInfo(instruction.Op);
        // return instruction switch
        // {
        //     { Op: Op.OpExecutionMode or Op.OpExecutionModeId } => GetInfo(new OperandKey<ExecutionMode>(instruction.Op, (ExecutionMode)instruction.Memory.Span[2])),
        //     { Op: Op.OpDecorate or Op.OpDecorateId } => GetInfo(new OperandKey<Decoration>(instruction.Op, (Decoration)instruction.Memory.Span[1])),
        //     { Op: Op.OpDecorateString } => GetInfo(new OperandKey<Decoration>(instruction.Op, (Decoration)instruction.Memory.Span[1])),
        //     { Op: Op.OpMemberDecorate } => GetInfo(new OperandKey<Decoration>(instruction.Op, (Decoration)instruction.Memory.Span[2])),
        //     { Op: Op.OpMemberDecorateString } => GetInfo(new OperandKey<Decoration>(instruction.Op, (Decoration)instruction.Memory.Span[2])),
        //     { Op: Op.OpLoopMerge } => GetInfo(new OperandKey<LoopControlMask>(instruction.Op, (LoopControlMask)instruction.Memory.Span[2])),
        //     { Op: Op.OpLoad } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[4])),
        //     { Op: Op.OpStore } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[3])),
        //     { Op: Op.OpCopyMemory } when instruction.Memory.Length > 2 => GetInfo(new OperandKey<MemoryAccessMask, MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[3], (MemoryAccessMask)instruction.Memory.Span[4])),
        //     { Op: Op.OpCopyMemorySized } when instruction.Memory.Length > 3 => GetInfo(new OperandKey<MemoryAccessMask, MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[4], (MemoryAccessMask)instruction.Memory.Span[5])),
        //     { Op: Op.OpCooperativeMatrixLoadKHR } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[6])),
        //     { Op: Op.OpCooperativeMatrixStoreKHR } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[5])),
        //     { Op: Op.OpCooperativeMatrixLoadNV } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[6])),
        //     { Op: Op.OpCooperativeMatrixStoreNV } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[5])),
        //     { Op: Op.OpCooperativeMatrixLoadTensorNV } => GetInfo(new OperandKey<MemoryAccessMask, TensorAddressingOperandsMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[6], (TensorAddressingOperandsMask)instruction.Memory.Span[7])),
        //     { Op: Op.OpCooperativeMatrixStoreTensorNV } => GetInfo(new OperandKey<MemoryAccessMask, TensorAddressingOperandsMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[4], (TensorAddressingOperandsMask)instruction.Memory.Span[5])),
        //     { Op: Op.OpSubgroupBlockPrefetchINTEL } => GetInfo(new OperandKey<MemoryAccessMask>(instruction.Op, (MemoryAccessMask)instruction.Memory.Span[3])),
        //     { Op: var op } => GetInfo(op),
        // };
    }
}
