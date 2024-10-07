﻿using static Spv.Specification;

namespace Stride.Shaders.Spirv.Core;
public enum OperandKind
{
    None = 0,
    ImageOperands,
    FPFastMathMode,
    SelectionControl,
    LoopControl,
    FunctionControl,
    MemorySemantics,
    MemoryAccess,
    KernelProfilingInfo,
    RayFlags,
    FragmentShadingRate,
    RawAccessChainOperands,
    SourceLanguage,
    ExecutionModel,
    AddressingModel,
    MemoryModel,
    ExecutionMode,
    StorageClass,
    Dim,
    SamplerAddressingMode,
    SamplerFilterMode,
    ImageFormat,
    ImageChannelOrder,
    ImageChannelDataType,
    FPRoundingMode,
    FPDenormMode,
    QuantizationModes,
    FPOperationMode,
    OverflowModes,
    LinkageType,
    AccessQualifier,
    HostAccessQualifier,
    FunctionParameterAttribute,
    Decoration,
    BuiltIn,
    Scope,
    GroupOperation,
    KernelEnqueueFlags,
    Capability,
    RayQueryIntersection,
    RayQueryCommittedIntersectionType,
    RayQueryCandidateIntersectionType,
    PackedVectorFormat,
    CooperativeMatrixOperands,
    CooperativeMatrixLayout,
    CooperativeMatrixUse,
    InitializationModeQualifier,
    LoadCacheControl,
    StoreCacheControl,
    NamedMaximumNumberOfRegisters,
    FPEncoding,
    IdResultType,
    IdResult,
    IdMemorySemantics,
    IdScope,
    IdRef,
    LiteralInteger,
    LiteralString,
    LiteralFloat,
    LiteralContextDependentNumber,
    LiteralExtInstInteger,
    LiteralSpecConstantOpInteger,
    PairLiteralIntegerIdRef,
    PairIdRefLiteralInteger,
    PairIdRefIdRef,
}