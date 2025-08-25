using static Spv.Specification;
using CommunityToolkit.HighPerformance;
using CommunityToolkit.HighPerformance.Buffers;
using Stride.Shaders.Spirv.Core.Buffers;

namespace Stride.Shaders.Spirv.Core;
public struct OpTypeVoid : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeVoid(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeVoid(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeVoid, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeVoid(OpDataIndex odi) => new(odi);
}

public struct OpTypeBool : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeBool(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeBool(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeBool, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeBool(OpDataIndex odi) => new(odi);
}

public struct OpTypeInt : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger Width
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger Signedness
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeInt(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "width")
                Width = o.To<LiteralInteger>();
            if (o.Name == "signedness")
                Signedness = o.To<LiteralInteger>();
        }
    }

    public OpTypeInt(IdResult resultId, LiteralInteger width, LiteralInteger signedness)
    {
        ResultId = resultId;
        Width = width;
        Signedness = signedness;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeInt, ..ResultId.AsSpirvSpan(), ..Width.AsSpirvSpan(), ..Signedness.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeInt(OpDataIndex odi) => new(odi);
}

public struct OpTypeFloat : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger Width
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public FPEncoding FloatingPointEncoding
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeFloat(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "width")
                Width = o.To<LiteralInteger>();
            if (o.Name == "floatingPointEncoding")
                FloatingPointEncoding = o.ToEnum<FPEncoding>();
        }
    }

    public OpTypeFloat(IdResult resultId, LiteralInteger width, FPEncoding floatingPointEncoding)
    {
        ResultId = resultId;
        Width = width;
        FloatingPointEncoding = floatingPointEncoding;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeFloat, ..ResultId.AsSpirvSpan(), ..Width.AsSpirvSpan(), ..FloatingPointEncoding.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeFloat(OpDataIndex odi) => new(odi);
}

public struct OpTypeVector : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ComponentType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger ComponentCount
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeVector(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "componentType")
                ComponentType = o.To<IdRef>();
            if (o.Name == "componentCount")
                ComponentCount = o.To<LiteralInteger>();
        }
    }

    public OpTypeVector(IdResult resultId, IdRef componentType, LiteralInteger componentCount)
    {
        ResultId = resultId;
        ComponentType = componentType;
        ComponentCount = componentCount;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeVector, ..ResultId.AsSpirvSpan(), ..ComponentType.AsSpirvSpan(), ..ComponentCount.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeVector(OpDataIndex odi) => new(odi);
}

public struct OpTypeMatrix : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ColumnType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger ColumnCount
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeMatrix(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "columnType")
                ColumnType = o.To<IdRef>();
            if (o.Name == "columnCount")
                ColumnCount = o.To<LiteralInteger>();
        }
    }

    public OpTypeMatrix(IdResult resultId, IdRef columnType, LiteralInteger columnCount)
    {
        ResultId = resultId;
        ColumnType = columnType;
        ColumnCount = columnCount;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeMatrix, ..ResultId.AsSpirvSpan(), ..ColumnType.AsSpirvSpan(), ..ColumnCount.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeMatrix(OpDataIndex odi) => new(odi);
}

public struct OpTypeImage : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef SampledType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public Dim Dim
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger Depth
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger Arrayed
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger MS
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralInteger Sampled
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public ImageFormat ImageFormat
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public AccessQualifier AccessQualifier
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeImage(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "sampledType")
                SampledType = o.To<IdRef>();
            if (o.Name == "dim")
                Dim = o.ToEnum<Dim>();
            if (o.Name == "depth")
                Depth = o.To<LiteralInteger>();
            if (o.Name == "arrayed")
                Arrayed = o.To<LiteralInteger>();
            if (o.Name == "mS")
                MS = o.To<LiteralInteger>();
            if (o.Name == "sampled")
                Sampled = o.To<LiteralInteger>();
            if (o.Name == "imageformat")
                ImageFormat = o.ToEnum<ImageFormat>();
            if (o.Name == "accessqualifier")
                AccessQualifier = o.ToEnum<AccessQualifier>();
        }
    }

    public OpTypeImage(IdResult resultId, IdRef sampledType, Dim dim, LiteralInteger depth, LiteralInteger arrayed, LiteralInteger mS, LiteralInteger sampled, ImageFormat imageformat, AccessQualifier accessqualifier)
    {
        ResultId = resultId;
        SampledType = sampledType;
        Dim = dim;
        Depth = depth;
        Arrayed = arrayed;
        MS = mS;
        Sampled = sampled;
        ImageFormat = imageformat;
        AccessQualifier = accessqualifier;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeImage, ..ResultId.AsSpirvSpan(), ..SampledType.AsSpirvSpan(), ..Dim.AsSpirvSpan(), ..Depth.AsSpirvSpan(), ..Arrayed.AsSpirvSpan(), ..MS.AsSpirvSpan(), ..Sampled.AsSpirvSpan(), ..ImageFormat.AsSpirvSpan(), ..AccessQualifier.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeImage(OpDataIndex odi) => new(odi);
}

public struct OpTypeSampler : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeSampler(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeSampler(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeSampler, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeSampler(OpDataIndex odi) => new(odi);
}

public struct OpTypeSampledImage : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ImageType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeSampledImage(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "imageType")
                ImageType = o.To<IdRef>();
        }
    }

    public OpTypeSampledImage(IdResult resultId, IdRef imageType)
    {
        ResultId = resultId;
        ImageType = imageType;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeSampledImage, ..ResultId.AsSpirvSpan(), ..ImageType.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeSampledImage(OpDataIndex odi) => new(odi);
}

public struct OpTypeArray : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ElementType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Length
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeArray(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "elementType")
                ElementType = o.To<IdRef>();
            if (o.Name == "length")
                Length = o.To<IdRef>();
        }
    }

    public OpTypeArray(IdResult resultId, IdRef elementType, IdRef length)
    {
        ResultId = resultId;
        ElementType = elementType;
        Length = length;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeArray, ..ResultId.AsSpirvSpan(), ..ElementType.AsSpirvSpan(), ..Length.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeArray(OpDataIndex odi) => new(odi);
}

public struct OpTypeRuntimeArray : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ElementType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeRuntimeArray(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "elementType")
                ElementType = o.To<IdRef>();
        }
    }

    public OpTypeRuntimeArray(IdResult resultId, IdRef elementType)
    {
        ResultId = resultId;
        ElementType = elementType;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeRuntimeArray, ..ResultId.AsSpirvSpan(), ..ElementType.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeRuntimeArray(OpDataIndex odi) => new(odi);
}

public struct OpTypeStruct : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Member0typemember1type
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeStruct(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "member0typemember1type")
                Member0typemember1type = o.To<IdRef>();
        }
    }

    public OpTypeStruct(IdResult resultId, IdRef member0typemember1type)
    {
        ResultId = resultId;
        Member0typemember1type = member0typemember1type;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeStruct, ..ResultId.AsSpirvSpan(), ..Member0typemember1type.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeStruct(OpDataIndex odi) => new(odi);
}

public struct OpTypeOpaque : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public LiteralString Thenameoftheopaquetype
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeOpaque(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "thenameoftheopaquetype")
                Thenameoftheopaquetype = o.To<LiteralString>();
        }
    }

    public OpTypeOpaque(IdResult resultId, LiteralString thenameoftheopaquetype)
    {
        ResultId = resultId;
        Thenameoftheopaquetype = thenameoftheopaquetype;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeOpaque, ..ResultId.AsSpirvSpan(), ..Thenameoftheopaquetype.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeOpaque(OpDataIndex odi) => new(odi);
}

public struct OpTypePointer : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public StorageClass StorageClass
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Type
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypePointer(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "storageclass")
                StorageClass = o.ToEnum<StorageClass>();
            if (o.Name == "type")
                Type = o.To<IdRef>();
        }
    }

    public OpTypePointer(IdResult resultId, StorageClass storageclass, IdRef type)
    {
        ResultId = resultId;
        StorageClass = storageclass;
        Type = type;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypePointer, ..ResultId.AsSpirvSpan(), ..StorageClass.AsSpirvSpan(), ..Type.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypePointer(OpDataIndex odi) => new(odi);
}

public struct OpTypeFunction : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ReturnType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Parameter0TypeParameter1Type
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeFunction(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "returnType")
                ReturnType = o.To<IdRef>();
            if (o.Name == "parameter0TypeParameter1Type")
                Parameter0TypeParameter1Type = o.To<IdRef>();
        }
    }

    public OpTypeFunction(IdResult resultId, IdRef returnType, IdRef parameter0TypeParameter1Type)
    {
        ResultId = resultId;
        ReturnType = returnType;
        Parameter0TypeParameter1Type = parameter0TypeParameter1Type;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeFunction, ..ResultId.AsSpirvSpan(), ..ReturnType.AsSpirvSpan(), ..Parameter0TypeParameter1Type.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeFunction(OpDataIndex odi) => new(odi);
}

public struct OpTypeEvent : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeEvent(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeEvent(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeEvent, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeEvent(OpDataIndex odi) => new(odi);
}

public struct OpTypeDeviceEvent : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeDeviceEvent(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeDeviceEvent(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeDeviceEvent, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeDeviceEvent(OpDataIndex odi) => new(odi);
}

public struct OpTypeReserveId : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeReserveId(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeReserveId(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeReserveId, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeReserveId(OpDataIndex odi) => new(odi);
}

public struct OpTypeQueue : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeQueue(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeQueue(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeQueue, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeQueue(OpDataIndex odi) => new(odi);
}

public struct OpTypePipe : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public AccessQualifier Qualifier
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypePipe(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "qualifier")
                Qualifier = o.ToEnum<AccessQualifier>();
        }
    }

    public OpTypePipe(IdResult resultId, AccessQualifier qualifier)
    {
        ResultId = resultId;
        Qualifier = qualifier;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypePipe, ..ResultId.AsSpirvSpan(), ..Qualifier.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypePipe(OpDataIndex odi) => new(odi);
}

public struct OpTypeForwardPointer : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdRef PointerType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public StorageClass StorageClass
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeForwardPointer(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "pointerType")
                PointerType = o.To<IdRef>();
            if (o.Name == "storageclass")
                StorageClass = o.ToEnum<StorageClass>();
        }
    }

    public OpTypeForwardPointer(IdRef pointerType, StorageClass storageclass)
    {
        PointerType = pointerType;
        StorageClass = storageclass;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeForwardPointer, ..PointerType.AsSpirvSpan(), ..StorageClass.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeForwardPointer(OpDataIndex odi) => new(odi);
}

public struct OpTypePipeStorage : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypePipeStorage(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypePipeStorage(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypePipeStorage, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypePipeStorage(OpDataIndex odi) => new(odi);
}

public struct OpTypeNamedBarrier : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeNamedBarrier(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeNamedBarrier(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeNamedBarrier, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeNamedBarrier(OpDataIndex odi) => new(odi);
}

public struct OpTypeUntypedPointerKHR : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public StorageClass StorageClass
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeUntypedPointerKHR(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "storageclass")
                StorageClass = o.ToEnum<StorageClass>();
        }
    }

    public OpTypeUntypedPointerKHR(IdResult resultId, StorageClass storageclass)
    {
        ResultId = resultId;
        StorageClass = storageclass;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeUntypedPointerKHR, ..ResultId.AsSpirvSpan(), ..StorageClass.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeUntypedPointerKHR(OpDataIndex odi) => new(odi);
}

public struct OpTypeCooperativeMatrixKHR : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ComponentType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdScope Scope
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Rows
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Columns
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Use
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeCooperativeMatrixKHR(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "componentType")
                ComponentType = o.To<IdRef>();
            if (o.Name == "scope")
                Scope = o.To<IdScope>();
            if (o.Name == "rows")
                Rows = o.To<IdRef>();
            if (o.Name == "columns")
                Columns = o.To<IdRef>();
            if (o.Name == "use")
                Use = o.To<IdRef>();
        }
    }

    public OpTypeCooperativeMatrixKHR(IdResult resultId, IdRef componentType, IdScope scope, IdRef rows, IdRef columns, IdRef use)
    {
        ResultId = resultId;
        ComponentType = componentType;
        Scope = scope;
        Rows = rows;
        Columns = columns;
        Use = use;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeCooperativeMatrixKHR, ..ResultId.AsSpirvSpan(), ..ComponentType.AsSpirvSpan(), ..Scope.AsSpirvSpan(), ..Rows.AsSpirvSpan(), ..Columns.AsSpirvSpan(), ..Use.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeCooperativeMatrixKHR(OpDataIndex odi) => new(odi);
}

public struct OpTypeRayQueryKHR : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeRayQueryKHR(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeRayQueryKHR(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeRayQueryKHR, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeRayQueryKHR(OpDataIndex odi) => new(odi);
}

public struct OpTypeNodePayloadArrayAMDX : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef PayloadType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeNodePayloadArrayAMDX(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "payloadType")
                PayloadType = o.To<IdRef>();
        }
    }

    public OpTypeNodePayloadArrayAMDX(IdResult resultId, IdRef payloadType)
    {
        ResultId = resultId;
        PayloadType = payloadType;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeNodePayloadArrayAMDX, ..ResultId.AsSpirvSpan(), ..PayloadType.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeNodePayloadArrayAMDX(OpDataIndex odi) => new(odi);
}

public struct OpTypeHitObjectNV : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeHitObjectNV(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeHitObjectNV(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeHitObjectNV, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeHitObjectNV(OpDataIndex odi) => new(odi);
}

public struct OpTypeAccelerationStructureKHR : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAccelerationStructureKHR(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAccelerationStructureKHR(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAccelerationStructureKHR, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAccelerationStructureKHR(OpDataIndex odi) => new(odi);
}

public struct OpTypeCooperativeMatrixNV : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ComponentType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdScope Execution
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Rows
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Columns
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeCooperativeMatrixNV(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "componentType")
                ComponentType = o.To<IdRef>();
            if (o.Name == "execution")
                Execution = o.To<IdScope>();
            if (o.Name == "rows")
                Rows = o.To<IdRef>();
            if (o.Name == "columns")
                Columns = o.To<IdRef>();
        }
    }

    public OpTypeCooperativeMatrixNV(IdResult resultId, IdRef componentType, IdScope execution, IdRef rows, IdRef columns)
    {
        ResultId = resultId;
        ComponentType = componentType;
        Execution = execution;
        Rows = rows;
        Columns = columns;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeCooperativeMatrixNV, ..ResultId.AsSpirvSpan(), ..ComponentType.AsSpirvSpan(), ..Execution.AsSpirvSpan(), ..Rows.AsSpirvSpan(), ..Columns.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeCooperativeMatrixNV(OpDataIndex odi) => new(odi);
}

public struct OpTypeTensorLayoutNV : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Dim
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ClampMode
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeTensorLayoutNV(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "dim")
                Dim = o.To<IdRef>();
            if (o.Name == "clampMode")
                ClampMode = o.To<IdRef>();
        }
    }

    public OpTypeTensorLayoutNV(IdResult resultId, IdRef dim, IdRef clampMode)
    {
        ResultId = resultId;
        Dim = dim;
        ClampMode = clampMode;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeTensorLayoutNV, ..ResultId.AsSpirvSpan(), ..Dim.AsSpirvSpan(), ..ClampMode.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeTensorLayoutNV(OpDataIndex odi) => new(odi);
}

public struct OpTypeTensorViewNV : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef Dim
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef HasDimensions
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef P
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeTensorViewNV(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "dim")
                Dim = o.To<IdRef>();
            if (o.Name == "hasDimensions")
                HasDimensions = o.To<IdRef>();
            if (o.Name == "p")
                P = o.To<IdRef>();
        }
    }

    public OpTypeTensorViewNV(IdResult resultId, IdRef dim, IdRef hasDimensions, IdRef p)
    {
        ResultId = resultId;
        Dim = dim;
        HasDimensions = hasDimensions;
        P = p;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeTensorViewNV, ..ResultId.AsSpirvSpan(), ..Dim.AsSpirvSpan(), ..HasDimensions.AsSpirvSpan(), ..P.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeTensorViewNV(OpDataIndex odi) => new(odi);
}

public struct OpTypeVmeImageINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public IdRef ImageType
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeVmeImageINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "imageType")
                ImageType = o.To<IdRef>();
        }
    }

    public OpTypeVmeImageINTEL(IdResult resultId, IdRef imageType)
    {
        ResultId = resultId;
        ImageType = imageType;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeVmeImageINTEL, ..ResultId.AsSpirvSpan(), ..ImageType.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeVmeImageINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcImePayloadINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcImePayloadINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcImePayloadINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcImePayloadINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcImePayloadINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcRefPayloadINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcRefPayloadINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcRefPayloadINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcRefPayloadINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcRefPayloadINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcSicPayloadINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcSicPayloadINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcSicPayloadINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcSicPayloadINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcSicPayloadINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcMcePayloadINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcMcePayloadINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcMcePayloadINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcMcePayloadINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcMcePayloadINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcMceResultINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcMceResultINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcMceResultINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcMceResultINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcMceResultINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcImeResultINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcImeResultINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcImeResultINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcImeResultINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcImeResultINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcImeResultSingleReferenceStreamoutINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcImeResultSingleReferenceStreamoutINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcImeResultSingleReferenceStreamoutINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcImeResultSingleReferenceStreamoutINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcImeResultSingleReferenceStreamoutINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcImeResultDualReferenceStreamoutINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcImeResultDualReferenceStreamoutINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcImeResultDualReferenceStreamoutINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcImeResultDualReferenceStreamoutINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcImeResultDualReferenceStreamoutINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcImeSingleReferenceStreaminINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcImeSingleReferenceStreaminINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcImeSingleReferenceStreaminINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcImeSingleReferenceStreaminINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcImeSingleReferenceStreaminINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcImeDualReferenceStreaminINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcImeDualReferenceStreaminINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcImeDualReferenceStreaminINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcImeDualReferenceStreaminINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcImeDualReferenceStreaminINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcRefResultINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcRefResultINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcRefResultINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcRefResultINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcRefResultINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeAvcSicResultINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeAvcSicResultINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
        }
    }

    public OpTypeAvcSicResultINTEL(IdResult resultId)
    {
        ResultId = resultId;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeAvcSicResultINTEL, ..ResultId.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeAvcSicResultINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeBufferSurfaceINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdResult ResultId
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public AccessQualifier AccessQualifier
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeBufferSurfaceINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "resultId")
                ResultId = o.To<IdResult>();
            if (o.Name == "accessQualifier")
                AccessQualifier = o.ToEnum<AccessQualifier>();
        }
    }

    public OpTypeBufferSurfaceINTEL(IdResult resultId, AccessQualifier accessQualifier)
    {
        ResultId = resultId;
        AccessQualifier = accessQualifier;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeBufferSurfaceINTEL, ..ResultId.AsSpirvSpan(), ..AccessQualifier.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeBufferSurfaceINTEL(OpDataIndex odi) => new(odi);
}

public struct OpTypeStructContinuedINTEL : IHandyInstruction2
{
    public OpDataIndex? DataIndex { get; set; }

    public MemoryOwner<int> Memory
    {
        readonly get
        {
            if (DataIndex is OpDataIndex odi)
                return odi.Buffer[odi.Index].Memory;
            else
                return field;
        }

        private set
        {
            if (DataIndex is OpDataIndex odi)
            {
                odi.Buffer[odi.Index].Memory.Dispose();
                odi.Buffer[odi.Index].Memory = value;
            }
            else
                field = value;
        }
    }

    public IdRef Member0typemember1type
    {
        get;
        set
        {
            field = value;
            UpdateMemory();
        }
    }

    public OpTypeStructContinuedINTEL(OpDataIndex index)
    {
        DataIndex = index;
        foreach (var o in index.Buffer[index.Index])
        {
            if (o.Name == "member0typemember1type")
                Member0typemember1type = o.To<IdRef>();
        }
    }

    public OpTypeStructContinuedINTEL(IdRef member0typemember1type)
    {
        Member0typemember1type = member0typemember1type;
        UpdateMemory();
    }

    public void UpdateMemory()
    {
        Span<int> instruction = [(int)SDSLOp.OpTypeStructContinuedINTEL, ..Member0typemember1type.AsSpirvSpan()];
        instruction[0] |= instruction.Length << 16;
        var tmp = MemoryOwner<int>.Allocate(instruction.Length);
        instruction.CopyTo(tmp.Span);
        Memory?.Dispose();
        Memory = tmp;
    }

    public static implicit operator OpTypeStructContinuedINTEL(OpDataIndex odi) => new(odi);
}