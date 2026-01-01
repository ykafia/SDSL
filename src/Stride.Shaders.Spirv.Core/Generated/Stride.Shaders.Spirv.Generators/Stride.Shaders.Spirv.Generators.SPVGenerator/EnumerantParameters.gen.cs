using static Stride.Shaders.Spirv.Specification;
using CommunityToolkit.HighPerformance;
using CommunityToolkit.HighPerformance.Buffers;
using Stride.Shaders.Spirv.Core.Buffers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Stride.Shaders.Spirv.Core;
public static class DecorationParameters
{
    public ref struct LinkSDSL : IEnumerantParameter<LinkSDSL>
    {
        public string Name { get; set; }

        public static LinkSDSL Create(Span<int> words)
        {
            var parameter = new LinkSDSL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LinkSDSL parameter)
        {
            Span<int> span = [..parameter.Name.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LinkIdSDSL : IEnumerantParameter<LinkIdSDSL>
    {
        public int IdRef0 { get; set; }

        public static LinkIdSDSL Create(Span<int> words)
        {
            var parameter = new LinkIdSDSL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LinkIdSDSL parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ResourceGroupSDSL : IEnumerantParameter<ResourceGroupSDSL>
    {
        public string ResourceGroup { get; set; }

        public static ResourceGroupSDSL Create(Span<int> words)
        {
            var parameter = new ResourceGroupSDSL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ResourceGroupSDSL parameter)
        {
            Span<int> span = [..parameter.ResourceGroup.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ResourceGroupIdSDSL : IEnumerantParameter<ResourceGroupIdSDSL>
    {
        public int ResourceGroup { get; set; }

        public static ResourceGroupIdSDSL Create(Span<int> words)
        {
            var parameter = new ResourceGroupIdSDSL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ResourceGroupIdSDSL parameter)
        {
            Span<int> span = [parameter.ResourceGroup];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LogicalGroupSDSL : IEnumerantParameter<LogicalGroupSDSL>
    {
        public string LogicalGroup { get; set; }

        public static LogicalGroupSDSL Create(Span<int> words)
        {
            var parameter = new LogicalGroupSDSL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LogicalGroupSDSL parameter)
        {
            Span<int> span = [..parameter.LogicalGroup.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateFilter : IEnumerantParameter<SamplerStateFilter>
    {
        public SamplerFilterSDSL Samplerfiltersdsl0 { get; set; }

        public static SamplerStateFilter Create(Span<int> words)
        {
            var parameter = new SamplerStateFilter();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateFilter parameter)
        {
            Span<int> span = [(int)parameter.Samplerfiltersdsl0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateAddressU : IEnumerantParameter<SamplerStateAddressU>
    {
        public SamplerTextureAddressModeSDSL Samplertextureaddressmodesdsl0 { get; set; }

        public static SamplerStateAddressU Create(Span<int> words)
        {
            var parameter = new SamplerStateAddressU();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateAddressU parameter)
        {
            Span<int> span = [(int)parameter.Samplertextureaddressmodesdsl0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateAddressV : IEnumerantParameter<SamplerStateAddressV>
    {
        public SamplerTextureAddressModeSDSL Samplertextureaddressmodesdsl0 { get; set; }

        public static SamplerStateAddressV Create(Span<int> words)
        {
            var parameter = new SamplerStateAddressV();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateAddressV parameter)
        {
            Span<int> span = [(int)parameter.Samplertextureaddressmodesdsl0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateAddressW : IEnumerantParameter<SamplerStateAddressW>
    {
        public SamplerTextureAddressModeSDSL Samplertextureaddressmodesdsl0 { get; set; }

        public static SamplerStateAddressW Create(Span<int> words)
        {
            var parameter = new SamplerStateAddressW();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateAddressW parameter)
        {
            Span<int> span = [(int)parameter.Samplertextureaddressmodesdsl0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateMipLODBias : IEnumerantParameter<SamplerStateMipLODBias>
    {
        public string Literalstring0 { get; set; }

        public static SamplerStateMipLODBias Create(Span<int> words)
        {
            var parameter = new SamplerStateMipLODBias();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateMipLODBias parameter)
        {
            Span<int> span = [..parameter.Literalstring0.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateMaxAnisotropy : IEnumerantParameter<SamplerStateMaxAnisotropy>
    {
        public int Literalinteger0 { get; set; }

        public static SamplerStateMaxAnisotropy Create(Span<int> words)
        {
            var parameter = new SamplerStateMaxAnisotropy();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateMaxAnisotropy parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateComparisonFunc : IEnumerantParameter<SamplerStateComparisonFunc>
    {
        public SamplerComparisonFuncSDSL Samplercomparisonfuncsdsl0 { get; set; }

        public static SamplerStateComparisonFunc Create(Span<int> words)
        {
            var parameter = new SamplerStateComparisonFunc();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateComparisonFunc parameter)
        {
            Span<int> span = [(int)parameter.Samplercomparisonfuncsdsl0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateMinLOD : IEnumerantParameter<SamplerStateMinLOD>
    {
        public string Literalstring0 { get; set; }

        public static SamplerStateMinLOD Create(Span<int> words)
        {
            var parameter = new SamplerStateMinLOD();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateMinLOD parameter)
        {
            Span<int> span = [..parameter.Literalstring0.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SamplerStateMaxLOD : IEnumerantParameter<SamplerStateMaxLOD>
    {
        public string Literalstring0 { get; set; }

        public static SamplerStateMaxLOD Create(Span<int> words)
        {
            var parameter = new SamplerStateMaxLOD();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SamplerStateMaxLOD parameter)
        {
            Span<int> span = [..parameter.Literalstring0.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SpecId : IEnumerantParameter<SpecId>
    {
        public int SpecializationConstantID { get; set; }

        public static SpecId Create(Span<int> words)
        {
            var parameter = new SpecId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SpecId parameter)
        {
            Span<int> span = [parameter.SpecializationConstantID];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ArrayStride : IEnumerantParameter<ArrayStride>
    {
        public int Value { get; set; }

        public static ArrayStride Create(Span<int> words)
        {
            var parameter = new ArrayStride();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ArrayStride parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MatrixStride : IEnumerantParameter<MatrixStride>
    {
        public int Value { get; set; }

        public static MatrixStride Create(Span<int> words)
        {
            var parameter = new MatrixStride();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MatrixStride parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct BuiltInParameter : IEnumerantParameter<BuiltInParameter>
    {
        public BuiltIn Value { get; set; }

        public static BuiltInParameter Create(Span<int> words)
        {
            var parameter = new BuiltInParameter();
            return parameter;
        }

        public static implicit operator EnumerantParameters(BuiltInParameter parameter)
        {
            Span<int> span = [(int)parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct UniformId : IEnumerantParameter<UniformId>
    {
        public IdScope Execution { get; set; }

        public static UniformId Create(Span<int> words)
        {
            var parameter = new UniformId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(UniformId parameter)
        {
            Span<int> span = [(int)parameter.Execution];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Stream : IEnumerantParameter<Stream>
    {
        public int StreamNumber { get; set; }

        public static Stream Create(Span<int> words)
        {
            var parameter = new Stream();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Stream parameter)
        {
            Span<int> span = [parameter.StreamNumber];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Location : IEnumerantParameter<Location>
    {
        public int Value { get; set; }

        public static Location Create(Span<int> words)
        {
            var parameter = new Location();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Location parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Component : IEnumerantParameter<Component>
    {
        public int Value { get; set; }

        public static Component Create(Span<int> words)
        {
            var parameter = new Component();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Component parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Index : IEnumerantParameter<Index>
    {
        public int Value { get; set; }

        public static Index Create(Span<int> words)
        {
            var parameter = new Index();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Index parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Binding : IEnumerantParameter<Binding>
    {
        public int BindingPoint { get; set; }

        public static Binding Create(Span<int> words)
        {
            var parameter = new Binding();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Binding parameter)
        {
            Span<int> span = [parameter.BindingPoint];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct DescriptorSet : IEnumerantParameter<DescriptorSet>
    {
        public int Value { get; set; }

        public static DescriptorSet Create(Span<int> words)
        {
            var parameter = new DescriptorSet();
            return parameter;
        }

        public static implicit operator EnumerantParameters(DescriptorSet parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Offset : IEnumerantParameter<Offset>
    {
        public int ByteOffset { get; set; }

        public static Offset Create(Span<int> words)
        {
            var parameter = new Offset();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Offset parameter)
        {
            Span<int> span = [parameter.ByteOffset];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct XfbBuffer : IEnumerantParameter<XfbBuffer>
    {
        public int XFBBufferNumber { get; set; }

        public static XfbBuffer Create(Span<int> words)
        {
            var parameter = new XfbBuffer();
            return parameter;
        }

        public static implicit operator EnumerantParameters(XfbBuffer parameter)
        {
            Span<int> span = [parameter.XFBBufferNumber];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct XfbStride : IEnumerantParameter<XfbStride>
    {
        public int XFBStride { get; set; }

        public static XfbStride Create(Span<int> words)
        {
            var parameter = new XfbStride();
            return parameter;
        }

        public static implicit operator EnumerantParameters(XfbStride parameter)
        {
            Span<int> span = [parameter.XFBStride];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FuncParamAttr : IEnumerantParameter<FuncParamAttr>
    {
        public FunctionParameterAttribute FunctionParameterAttribute { get; set; }

        public static FuncParamAttr Create(Span<int> words)
        {
            var parameter = new FuncParamAttr();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FuncParamAttr parameter)
        {
            Span<int> span = [(int)parameter.FunctionParameterAttribute];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FPRoundingModeParameter : IEnumerantParameter<FPRoundingModeParameter>
    {
        public FPRoundingMode Value { get; set; }

        public static FPRoundingModeParameter Create(Span<int> words)
        {
            var parameter = new FPRoundingModeParameter();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FPRoundingModeParameter parameter)
        {
            Span<int> span = [(int)parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FPFastMathModeParameter : IEnumerantParameter<FPFastMathModeParameter>
    {
        public FPFastMathModeMask Value { get; set; }

        public static FPFastMathModeParameter Create(Span<int> words)
        {
            var parameter = new FPFastMathModeParameter();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FPFastMathModeParameter parameter)
        {
            Span<int> span = [(int)parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LinkageAttributes : IEnumerantParameter<LinkageAttributes>
    {
        public string Name { get; set; }
        public LinkageType LinkageType { get; set; }

        public static LinkageAttributes Create(Span<int> words)
        {
            var parameter = new LinkageAttributes();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LinkageAttributes parameter)
        {
            Span<int> span = [..parameter.Name.AsDisposableLiteralValue().Words, (int)parameter.LinkageType];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct InputAttachmentIndex : IEnumerantParameter<InputAttachmentIndex>
    {
        public int AttachmentIndex { get; set; }

        public static InputAttachmentIndex Create(Span<int> words)
        {
            var parameter = new InputAttachmentIndex();
            return parameter;
        }

        public static implicit operator EnumerantParameters(InputAttachmentIndex parameter)
        {
            Span<int> span = [parameter.AttachmentIndex];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Alignment : IEnumerantParameter<Alignment>
    {
        public int Value { get; set; }

        public static Alignment Create(Span<int> words)
        {
            var parameter = new Alignment();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Alignment parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxByteOffset : IEnumerantParameter<MaxByteOffset>
    {
        public int Value { get; set; }

        public static MaxByteOffset Create(Span<int> words)
        {
            var parameter = new MaxByteOffset();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxByteOffset parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct AlignmentId : IEnumerantParameter<AlignmentId>
    {
        public int Alignment { get; set; }

        public static AlignmentId Create(Span<int> words)
        {
            var parameter = new AlignmentId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(AlignmentId parameter)
        {
            Span<int> span = [parameter.Alignment];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxByteOffsetId : IEnumerantParameter<MaxByteOffsetId>
    {
        public int MaxByteOffset { get; set; }

        public static MaxByteOffsetId Create(Span<int> words)
        {
            var parameter = new MaxByteOffsetId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxByteOffsetId parameter)
        {
            Span<int> span = [parameter.MaxByteOffset];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NodeSharesPayloadLimitsWithAMDX : IEnumerantParameter<NodeSharesPayloadLimitsWithAMDX>
    {
        public int PayloadType { get; set; }

        public static NodeSharesPayloadLimitsWithAMDX Create(Span<int> words)
        {
            var parameter = new NodeSharesPayloadLimitsWithAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NodeSharesPayloadLimitsWithAMDX parameter)
        {
            Span<int> span = [parameter.PayloadType];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NodeMaxPayloadsAMDX : IEnumerantParameter<NodeMaxPayloadsAMDX>
    {
        public int Maxnumberofpayloads { get; set; }

        public static NodeMaxPayloadsAMDX Create(Span<int> words)
        {
            var parameter = new NodeMaxPayloadsAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NodeMaxPayloadsAMDX parameter)
        {
            Span<int> span = [parameter.Maxnumberofpayloads];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PayloadNodeNameAMDX : IEnumerantParameter<PayloadNodeNameAMDX>
    {
        public int NodeName { get; set; }

        public static PayloadNodeNameAMDX Create(Span<int> words)
        {
            var parameter = new PayloadNodeNameAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PayloadNodeNameAMDX parameter)
        {
            Span<int> span = [parameter.NodeName];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PayloadNodeBaseIndexAMDX : IEnumerantParameter<PayloadNodeBaseIndexAMDX>
    {
        public int BaseIndex { get; set; }

        public static PayloadNodeBaseIndexAMDX Create(Span<int> words)
        {
            var parameter = new PayloadNodeBaseIndexAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PayloadNodeBaseIndexAMDX parameter)
        {
            Span<int> span = [parameter.BaseIndex];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PayloadNodeArraySizeAMDX : IEnumerantParameter<PayloadNodeArraySizeAMDX>
    {
        public int ArraySize { get; set; }

        public static PayloadNodeArraySizeAMDX Create(Span<int> words)
        {
            var parameter = new PayloadNodeArraySizeAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PayloadNodeArraySizeAMDX parameter)
        {
            Span<int> span = [parameter.ArraySize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SecondaryViewportRelativeNV : IEnumerantParameter<SecondaryViewportRelativeNV>
    {
        public int Offset { get; set; }

        public static SecondaryViewportRelativeNV Create(Span<int> words)
        {
            var parameter = new SecondaryViewportRelativeNV();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SecondaryViewportRelativeNV parameter)
        {
            Span<int> span = [parameter.Offset];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SIMTCallINTEL : IEnumerantParameter<SIMTCallINTEL>
    {
        public int N { get; set; }

        public static SIMTCallINTEL Create(Span<int> words)
        {
            var parameter = new SIMTCallINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SIMTCallINTEL parameter)
        {
            Span<int> span = [parameter.N];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ClobberINTEL : IEnumerantParameter<ClobberINTEL>
    {
        public string Register { get; set; }

        public static ClobberINTEL Create(Span<int> words)
        {
            var parameter = new ClobberINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ClobberINTEL parameter)
        {
            Span<int> span = [..parameter.Register.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FuncParamIOKindINTEL : IEnumerantParameter<FuncParamIOKindINTEL>
    {
        public int Kind { get; set; }

        public static FuncParamIOKindINTEL Create(Span<int> words)
        {
            var parameter = new FuncParamIOKindINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FuncParamIOKindINTEL parameter)
        {
            Span<int> span = [parameter.Kind];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct GlobalVariableOffsetINTEL : IEnumerantParameter<GlobalVariableOffsetINTEL>
    {
        public int Offset { get; set; }

        public static GlobalVariableOffsetINTEL Create(Span<int> words)
        {
            var parameter = new GlobalVariableOffsetINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(GlobalVariableOffsetINTEL parameter)
        {
            Span<int> span = [parameter.Offset];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct CounterBuffer : IEnumerantParameter<CounterBuffer>
    {
        public int Value { get; set; }

        public static CounterBuffer Create(Span<int> words)
        {
            var parameter = new CounterBuffer();
            return parameter;
        }

        public static implicit operator EnumerantParameters(CounterBuffer parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct UserSemantic : IEnumerantParameter<UserSemantic>
    {
        public string Semantic { get; set; }

        public static UserSemantic Create(Span<int> words)
        {
            var parameter = new UserSemantic();
            return parameter;
        }

        public static implicit operator EnumerantParameters(UserSemantic parameter)
        {
            Span<int> span = [..parameter.Semantic.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct UserTypeGOOGLE : IEnumerantParameter<UserTypeGOOGLE>
    {
        public string UserType { get; set; }

        public static UserTypeGOOGLE Create(Span<int> words)
        {
            var parameter = new UserTypeGOOGLE();
            return parameter;
        }

        public static implicit operator EnumerantParameters(UserTypeGOOGLE parameter)
        {
            Span<int> span = [..parameter.UserType.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FunctionRoundingModeINTEL : IEnumerantParameter<FunctionRoundingModeINTEL>
    {
        public int TargetWidth { get; set; }
        public FPRoundingMode FPRoundingMode { get; set; }

        public static FunctionRoundingModeINTEL Create(Span<int> words)
        {
            var parameter = new FunctionRoundingModeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FunctionRoundingModeINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth, (int)parameter.FPRoundingMode];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FunctionDenormModeINTEL : IEnumerantParameter<FunctionDenormModeINTEL>
    {
        public int TargetWidth { get; set; }
        public FPDenormMode FPDenormMode { get; set; }

        public static FunctionDenormModeINTEL Create(Span<int> words)
        {
            var parameter = new FunctionDenormModeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FunctionDenormModeINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth, (int)parameter.FPDenormMode];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MemoryINTEL : IEnumerantParameter<MemoryINTEL>
    {
        public string MemoryType { get; set; }

        public static MemoryINTEL Create(Span<int> words)
        {
            var parameter = new MemoryINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MemoryINTEL parameter)
        {
            Span<int> span = [..parameter.MemoryType.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NumbanksINTEL : IEnumerantParameter<NumbanksINTEL>
    {
        public int Banks { get; set; }

        public static NumbanksINTEL Create(Span<int> words)
        {
            var parameter = new NumbanksINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NumbanksINTEL parameter)
        {
            Span<int> span = [parameter.Banks];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct BankwidthINTEL : IEnumerantParameter<BankwidthINTEL>
    {
        public int BankWidth { get; set; }

        public static BankwidthINTEL Create(Span<int> words)
        {
            var parameter = new BankwidthINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(BankwidthINTEL parameter)
        {
            Span<int> span = [parameter.BankWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxPrivateCopiesINTEL : IEnumerantParameter<MaxPrivateCopiesINTEL>
    {
        public int MaximumCopies { get; set; }

        public static MaxPrivateCopiesINTEL Create(Span<int> words)
        {
            var parameter = new MaxPrivateCopiesINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxPrivateCopiesINTEL parameter)
        {
            Span<int> span = [parameter.MaximumCopies];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxReplicatesINTEL : IEnumerantParameter<MaxReplicatesINTEL>
    {
        public int MaximumReplicates { get; set; }

        public static MaxReplicatesINTEL Create(Span<int> words)
        {
            var parameter = new MaxReplicatesINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxReplicatesINTEL parameter)
        {
            Span<int> span = [parameter.MaximumReplicates];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MergeINTEL : IEnumerantParameter<MergeINTEL>
    {
        public string MergeKey { get; set; }
        public string MergeType { get; set; }

        public static MergeINTEL Create(Span<int> words)
        {
            var parameter = new MergeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MergeINTEL parameter)
        {
            Span<int> span = [..parameter.MergeKey.AsDisposableLiteralValue().Words, ..parameter.MergeType.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct BankBitsINTEL : IEnumerantParameter<BankBitsINTEL>
    {
        public int BankBits { get; set; }

        public static BankBitsINTEL Create(Span<int> words)
        {
            var parameter = new BankBitsINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(BankBitsINTEL parameter)
        {
            Span<int> span = [parameter.BankBits];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ForcePow2DepthINTEL : IEnumerantParameter<ForcePow2DepthINTEL>
    {
        public int ForceKey { get; set; }

        public static ForcePow2DepthINTEL Create(Span<int> words)
        {
            var parameter = new ForcePow2DepthINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ForcePow2DepthINTEL parameter)
        {
            Span<int> span = [parameter.ForceKey];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct StridesizeINTEL : IEnumerantParameter<StridesizeINTEL>
    {
        public int StrideSize { get; set; }

        public static StridesizeINTEL Create(Span<int> words)
        {
            var parameter = new StridesizeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(StridesizeINTEL parameter)
        {
            Span<int> span = [parameter.StrideSize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct WordsizeINTEL : IEnumerantParameter<WordsizeINTEL>
    {
        public int WordSize { get; set; }

        public static WordsizeINTEL Create(Span<int> words)
        {
            var parameter = new WordsizeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(WordsizeINTEL parameter)
        {
            Span<int> span = [parameter.WordSize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct CacheSizeINTEL : IEnumerantParameter<CacheSizeINTEL>
    {
        public int CacheSizeinbytes { get; set; }

        public static CacheSizeINTEL Create(Span<int> words)
        {
            var parameter = new CacheSizeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(CacheSizeINTEL parameter)
        {
            Span<int> span = [parameter.CacheSizeinbytes];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PrefetchINTEL : IEnumerantParameter<PrefetchINTEL>
    {
        public int PrefetcherSizeinbytes { get; set; }

        public static PrefetchINTEL Create(Span<int> words)
        {
            var parameter = new PrefetchINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PrefetchINTEL parameter)
        {
            Span<int> span = [parameter.PrefetcherSizeinbytes];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MathOpDSPModeINTEL : IEnumerantParameter<MathOpDSPModeINTEL>
    {
        public int Mode { get; set; }
        public int Propagate { get; set; }

        public static MathOpDSPModeINTEL Create(Span<int> words)
        {
            var parameter = new MathOpDSPModeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MathOpDSPModeINTEL parameter)
        {
            Span<int> span = [parameter.Mode, parameter.Propagate];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct AliasScopeINTEL : IEnumerantParameter<AliasScopeINTEL>
    {
        public int AliasingScopesList { get; set; }

        public static AliasScopeINTEL Create(Span<int> words)
        {
            var parameter = new AliasScopeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(AliasScopeINTEL parameter)
        {
            Span<int> span = [parameter.AliasingScopesList];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NoAliasINTEL : IEnumerantParameter<NoAliasINTEL>
    {
        public int AliasingScopesList { get; set; }

        public static NoAliasINTEL Create(Span<int> words)
        {
            var parameter = new NoAliasINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NoAliasINTEL parameter)
        {
            Span<int> span = [parameter.AliasingScopesList];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct InitiationIntervalINTEL : IEnumerantParameter<InitiationIntervalINTEL>
    {
        public int Cycles { get; set; }

        public static InitiationIntervalINTEL Create(Span<int> words)
        {
            var parameter = new InitiationIntervalINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(InitiationIntervalINTEL parameter)
        {
            Span<int> span = [parameter.Cycles];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxConcurrencyINTEL : IEnumerantParameter<MaxConcurrencyINTEL>
    {
        public int Invocations { get; set; }

        public static MaxConcurrencyINTEL Create(Span<int> words)
        {
            var parameter = new MaxConcurrencyINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxConcurrencyINTEL parameter)
        {
            Span<int> span = [parameter.Invocations];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PipelineEnableINTEL : IEnumerantParameter<PipelineEnableINTEL>
    {
        public int Enable { get; set; }

        public static PipelineEnableINTEL Create(Span<int> words)
        {
            var parameter = new PipelineEnableINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PipelineEnableINTEL parameter)
        {
            Span<int> span = [parameter.Enable];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct BufferLocationINTEL : IEnumerantParameter<BufferLocationINTEL>
    {
        public int BufferLocationID { get; set; }

        public static BufferLocationINTEL Create(Span<int> words)
        {
            var parameter = new BufferLocationINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(BufferLocationINTEL parameter)
        {
            Span<int> span = [parameter.BufferLocationID];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct IOPipeStorageINTEL : IEnumerantParameter<IOPipeStorageINTEL>
    {
        public int IOPipeID { get; set; }

        public static IOPipeStorageINTEL Create(Span<int> words)
        {
            var parameter = new IOPipeStorageINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(IOPipeStorageINTEL parameter)
        {
            Span<int> span = [parameter.IOPipeID];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FunctionFloatingPointModeINTEL : IEnumerantParameter<FunctionFloatingPointModeINTEL>
    {
        public int TargetWidth { get; set; }
        public FPOperationMode FPOperationMode { get; set; }

        public static FunctionFloatingPointModeINTEL Create(Span<int> words)
        {
            var parameter = new FunctionFloatingPointModeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FunctionFloatingPointModeINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth, (int)parameter.FPOperationMode];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FPMaxErrorDecorationINTEL : IEnumerantParameter<FPMaxErrorDecorationINTEL>
    {
        public float MaxError { get; set; }

        public static FPMaxErrorDecorationINTEL Create(Span<int> words)
        {
            var parameter = new FPMaxErrorDecorationINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FPMaxErrorDecorationINTEL parameter)
        {
            Span<int> span = [BitConverter.SingleToInt32Bits(parameter.MaxError)];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LatencyControlLabelINTEL : IEnumerantParameter<LatencyControlLabelINTEL>
    {
        public int LatencyLabel { get; set; }

        public static LatencyControlLabelINTEL Create(Span<int> words)
        {
            var parameter = new LatencyControlLabelINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LatencyControlLabelINTEL parameter)
        {
            Span<int> span = [parameter.LatencyLabel];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LatencyControlConstraintINTEL : IEnumerantParameter<LatencyControlConstraintINTEL>
    {
        public int RelativeTo { get; set; }
        public int ControlType { get; set; }
        public int RelativeCycle { get; set; }

        public static LatencyControlConstraintINTEL Create(Span<int> words)
        {
            var parameter = new LatencyControlConstraintINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LatencyControlConstraintINTEL parameter)
        {
            Span<int> span = [parameter.RelativeTo, parameter.ControlType, parameter.RelativeCycle];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MMHostInterfaceAddressWidthINTEL : IEnumerantParameter<MMHostInterfaceAddressWidthINTEL>
    {
        public int AddressWidth { get; set; }

        public static MMHostInterfaceAddressWidthINTEL Create(Span<int> words)
        {
            var parameter = new MMHostInterfaceAddressWidthINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MMHostInterfaceAddressWidthINTEL parameter)
        {
            Span<int> span = [parameter.AddressWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MMHostInterfaceDataWidthINTEL : IEnumerantParameter<MMHostInterfaceDataWidthINTEL>
    {
        public int DataWidth { get; set; }

        public static MMHostInterfaceDataWidthINTEL Create(Span<int> words)
        {
            var parameter = new MMHostInterfaceDataWidthINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MMHostInterfaceDataWidthINTEL parameter)
        {
            Span<int> span = [parameter.DataWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MMHostInterfaceLatencyINTEL : IEnumerantParameter<MMHostInterfaceLatencyINTEL>
    {
        public int Latency { get; set; }

        public static MMHostInterfaceLatencyINTEL Create(Span<int> words)
        {
            var parameter = new MMHostInterfaceLatencyINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MMHostInterfaceLatencyINTEL parameter)
        {
            Span<int> span = [parameter.Latency];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MMHostInterfaceReadWriteModeINTEL : IEnumerantParameter<MMHostInterfaceReadWriteModeINTEL>
    {
        public AccessQualifier ReadWriteMode { get; set; }

        public static MMHostInterfaceReadWriteModeINTEL Create(Span<int> words)
        {
            var parameter = new MMHostInterfaceReadWriteModeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MMHostInterfaceReadWriteModeINTEL parameter)
        {
            Span<int> span = [(int)parameter.ReadWriteMode];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MMHostInterfaceMaxBurstINTEL : IEnumerantParameter<MMHostInterfaceMaxBurstINTEL>
    {
        public int MaxBurstCount { get; set; }

        public static MMHostInterfaceMaxBurstINTEL Create(Span<int> words)
        {
            var parameter = new MMHostInterfaceMaxBurstINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MMHostInterfaceMaxBurstINTEL parameter)
        {
            Span<int> span = [parameter.MaxBurstCount];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MMHostInterfaceWaitRequestINTEL : IEnumerantParameter<MMHostInterfaceWaitRequestINTEL>
    {
        public int Waitrequest { get; set; }

        public static MMHostInterfaceWaitRequestINTEL Create(Span<int> words)
        {
            var parameter = new MMHostInterfaceWaitRequestINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MMHostInterfaceWaitRequestINTEL parameter)
        {
            Span<int> span = [parameter.Waitrequest];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct HostAccessINTEL : IEnumerantParameter<HostAccessINTEL>
    {
        public HostAccessQualifier Access { get; set; }
        public string Name { get; set; }

        public static HostAccessINTEL Create(Span<int> words)
        {
            var parameter = new HostAccessINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(HostAccessINTEL parameter)
        {
            Span<int> span = [(int)parameter.Access, ..parameter.Name.AsDisposableLiteralValue().Words];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct InitModeINTEL : IEnumerantParameter<InitModeINTEL>
    {
        public InitializationModeQualifier Trigger { get; set; }

        public static InitModeINTEL Create(Span<int> words)
        {
            var parameter = new InitModeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(InitModeINTEL parameter)
        {
            Span<int> span = [(int)parameter.Trigger];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ImplementInRegisterMapINTEL : IEnumerantParameter<ImplementInRegisterMapINTEL>
    {
        public int Parameter0 { get; set; }

        public static ImplementInRegisterMapINTEL Create(Span<int> words)
        {
            var parameter = new ImplementInRegisterMapINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ImplementInRegisterMapINTEL parameter)
        {
            Span<int> span = [parameter.Parameter0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct CacheControlLoadINTEL : IEnumerantParameter<CacheControlLoadINTEL>
    {
        public int CacheLevel { get; set; }
        public LoadCacheControl CacheControl { get; set; }

        public static CacheControlLoadINTEL Create(Span<int> words)
        {
            var parameter = new CacheControlLoadINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(CacheControlLoadINTEL parameter)
        {
            Span<int> span = [parameter.CacheLevel, (int)parameter.CacheControl];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct CacheControlStoreINTEL : IEnumerantParameter<CacheControlStoreINTEL>
    {
        public int CacheLevel { get; set; }
        public StoreCacheControl CacheControl { get; set; }

        public static CacheControlStoreINTEL Create(Span<int> words)
        {
            var parameter = new CacheControlStoreINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(CacheControlStoreINTEL parameter)
        {
            Span<int> span = [parameter.CacheLevel, (int)parameter.CacheControl];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }
}

public static class ImageOperandsParameters
{
    public ref struct Bias : IEnumerantParameter<Bias>
    {
        public int IdRef0 { get; set; }

        public static Bias Create(Span<int> words)
        {
            var parameter = new Bias();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Bias parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Lod : IEnumerantParameter<Lod>
    {
        public int IdRef0 { get; set; }

        public static Lod Create(Span<int> words)
        {
            var parameter = new Lod();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Lod parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Grad : IEnumerantParameter<Grad>
    {
        public int IdRef0 { get; set; }
        public int IdRef1 { get; set; }

        public static Grad Create(Span<int> words)
        {
            var parameter = new Grad();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Grad parameter)
        {
            Span<int> span = [parameter.IdRef0, parameter.IdRef1];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ConstOffset : IEnumerantParameter<ConstOffset>
    {
        public int IdRef0 { get; set; }

        public static ConstOffset Create(Span<int> words)
        {
            var parameter = new ConstOffset();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ConstOffset parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Offset : IEnumerantParameter<Offset>
    {
        public int IdRef0 { get; set; }

        public static Offset Create(Span<int> words)
        {
            var parameter = new Offset();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Offset parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ConstOffsets : IEnumerantParameter<ConstOffsets>
    {
        public int IdRef0 { get; set; }

        public static ConstOffsets Create(Span<int> words)
        {
            var parameter = new ConstOffsets();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ConstOffsets parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Sample : IEnumerantParameter<Sample>
    {
        public int IdRef0 { get; set; }

        public static Sample Create(Span<int> words)
        {
            var parameter = new Sample();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Sample parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MinLod : IEnumerantParameter<MinLod>
    {
        public int IdRef0 { get; set; }

        public static MinLod Create(Span<int> words)
        {
            var parameter = new MinLod();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MinLod parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MakeTexelAvailable : IEnumerantParameter<MakeTexelAvailable>
    {
        public IdScope Idscope0 { get; set; }

        public static MakeTexelAvailable Create(Span<int> words)
        {
            var parameter = new MakeTexelAvailable();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MakeTexelAvailable parameter)
        {
            Span<int> span = [(int)parameter.Idscope0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MakeTexelVisible : IEnumerantParameter<MakeTexelVisible>
    {
        public IdScope Idscope0 { get; set; }

        public static MakeTexelVisible Create(Span<int> words)
        {
            var parameter = new MakeTexelVisible();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MakeTexelVisible parameter)
        {
            Span<int> span = [(int)parameter.Idscope0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct Offsets : IEnumerantParameter<Offsets>
    {
        public int IdRef0 { get; set; }

        public static Offsets Create(Span<int> words)
        {
            var parameter = new Offsets();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Offsets parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }
}

public static class LoopControlParameters
{
    public ref struct DependencyLength : IEnumerantParameter<DependencyLength>
    {
        public int Literalinteger0 { get; set; }

        public static DependencyLength Create(Span<int> words)
        {
            var parameter = new DependencyLength();
            return parameter;
        }

        public static implicit operator EnumerantParameters(DependencyLength parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MinIterations : IEnumerantParameter<MinIterations>
    {
        public int Literalinteger0 { get; set; }

        public static MinIterations Create(Span<int> words)
        {
            var parameter = new MinIterations();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MinIterations parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxIterations : IEnumerantParameter<MaxIterations>
    {
        public int Literalinteger0 { get; set; }

        public static MaxIterations Create(Span<int> words)
        {
            var parameter = new MaxIterations();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxIterations parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct IterationMultiple : IEnumerantParameter<IterationMultiple>
    {
        public int Literalinteger0 { get; set; }

        public static IterationMultiple Create(Span<int> words)
        {
            var parameter = new IterationMultiple();
            return parameter;
        }

        public static implicit operator EnumerantParameters(IterationMultiple parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PeelCount : IEnumerantParameter<PeelCount>
    {
        public int Literalinteger0 { get; set; }

        public static PeelCount Create(Span<int> words)
        {
            var parameter = new PeelCount();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PeelCount parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PartialCount : IEnumerantParameter<PartialCount>
    {
        public int Literalinteger0 { get; set; }

        public static PartialCount Create(Span<int> words)
        {
            var parameter = new PartialCount();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PartialCount parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct InitiationIntervalINTEL : IEnumerantParameter<InitiationIntervalINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static InitiationIntervalINTEL Create(Span<int> words)
        {
            var parameter = new InitiationIntervalINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(InitiationIntervalINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxConcurrencyINTEL : IEnumerantParameter<MaxConcurrencyINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static MaxConcurrencyINTEL Create(Span<int> words)
        {
            var parameter = new MaxConcurrencyINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxConcurrencyINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct DependencyArrayINTEL : IEnumerantParameter<DependencyArrayINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static DependencyArrayINTEL Create(Span<int> words)
        {
            var parameter = new DependencyArrayINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(DependencyArrayINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct PipelineEnableINTEL : IEnumerantParameter<PipelineEnableINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static PipelineEnableINTEL Create(Span<int> words)
        {
            var parameter = new PipelineEnableINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(PipelineEnableINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LoopCoalesceINTEL : IEnumerantParameter<LoopCoalesceINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static LoopCoalesceINTEL Create(Span<int> words)
        {
            var parameter = new LoopCoalesceINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LoopCoalesceINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxInterleavingINTEL : IEnumerantParameter<MaxInterleavingINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static MaxInterleavingINTEL Create(Span<int> words)
        {
            var parameter = new MaxInterleavingINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxInterleavingINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SpeculatedIterationsINTEL : IEnumerantParameter<SpeculatedIterationsINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static SpeculatedIterationsINTEL Create(Span<int> words)
        {
            var parameter = new SpeculatedIterationsINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SpeculatedIterationsINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LoopCountINTEL : IEnumerantParameter<LoopCountINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static LoopCountINTEL Create(Span<int> words)
        {
            var parameter = new LoopCountINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LoopCountINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxReinvocationDelayINTEL : IEnumerantParameter<MaxReinvocationDelayINTEL>
    {
        public int Literalinteger0 { get; set; }

        public static MaxReinvocationDelayINTEL Create(Span<int> words)
        {
            var parameter = new MaxReinvocationDelayINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxReinvocationDelayINTEL parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }
}

public static class MemoryAccessParameters
{
    public ref struct Aligned : IEnumerantParameter<Aligned>
    {
        public int Literalinteger0 { get; set; }

        public static Aligned Create(Span<int> words)
        {
            var parameter = new Aligned();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Aligned parameter)
        {
            Span<int> span = [parameter.Literalinteger0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MakePointerAvailable : IEnumerantParameter<MakePointerAvailable>
    {
        public IdScope Idscope0 { get; set; }

        public static MakePointerAvailable Create(Span<int> words)
        {
            var parameter = new MakePointerAvailable();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MakePointerAvailable parameter)
        {
            Span<int> span = [(int)parameter.Idscope0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MakePointerVisible : IEnumerantParameter<MakePointerVisible>
    {
        public IdScope Idscope0 { get; set; }

        public static MakePointerVisible Create(Span<int> words)
        {
            var parameter = new MakePointerVisible();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MakePointerVisible parameter)
        {
            Span<int> span = [(int)parameter.Idscope0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct AliasScopeINTELMask : IEnumerantParameter<AliasScopeINTELMask>
    {
        public int IdRef0 { get; set; }

        public static AliasScopeINTELMask Create(Span<int> words)
        {
            var parameter = new AliasScopeINTELMask();
            return parameter;
        }

        public static implicit operator EnumerantParameters(AliasScopeINTELMask parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NoAliasINTELMask : IEnumerantParameter<NoAliasINTELMask>
    {
        public int IdRef0 { get; set; }

        public static NoAliasINTELMask Create(Span<int> words)
        {
            var parameter = new NoAliasINTELMask();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NoAliasINTELMask parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }
}

public static class ExecutionModeParameters
{
    public ref struct Invocations : IEnumerantParameter<Invocations>
    {
        public int NumberofInvocationinvocations { get; set; }

        public static Invocations Create(Span<int> words)
        {
            var parameter = new Invocations();
            return parameter;
        }

        public static implicit operator EnumerantParameters(Invocations parameter)
        {
            Span<int> span = [parameter.NumberofInvocationinvocations];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LocalSize : IEnumerantParameter<LocalSize>
    {
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int Zsize { get; set; }

        public static LocalSize Create(Span<int> words)
        {
            var parameter = new LocalSize();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LocalSize parameter)
        {
            Span<int> span = [parameter.Xsize, parameter.Ysize, parameter.Zsize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LocalSizeHint : IEnumerantParameter<LocalSizeHint>
    {
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int Zsize { get; set; }

        public static LocalSizeHint Create(Span<int> words)
        {
            var parameter = new LocalSizeHint();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LocalSizeHint parameter)
        {
            Span<int> span = [parameter.Xsize, parameter.Ysize, parameter.Zsize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct OutputVertices : IEnumerantParameter<OutputVertices>
    {
        public int Vertexcount { get; set; }

        public static OutputVertices Create(Span<int> words)
        {
            var parameter = new OutputVertices();
            return parameter;
        }

        public static implicit operator EnumerantParameters(OutputVertices parameter)
        {
            Span<int> span = [parameter.Vertexcount];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct VecTypeHint : IEnumerantParameter<VecTypeHint>
    {
        public int Vectortype { get; set; }

        public static VecTypeHint Create(Span<int> words)
        {
            var parameter = new VecTypeHint();
            return parameter;
        }

        public static implicit operator EnumerantParameters(VecTypeHint parameter)
        {
            Span<int> span = [parameter.Vectortype];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SubgroupSize : IEnumerantParameter<SubgroupSize>
    {
        public int Value { get; set; }

        public static SubgroupSize Create(Span<int> words)
        {
            var parameter = new SubgroupSize();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SubgroupSize parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SubgroupsPerWorkgroup : IEnumerantParameter<SubgroupsPerWorkgroup>
    {
        public int Value { get; set; }

        public static SubgroupsPerWorkgroup Create(Span<int> words)
        {
            var parameter = new SubgroupsPerWorkgroup();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SubgroupsPerWorkgroup parameter)
        {
            Span<int> span = [parameter.Value];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SubgroupsPerWorkgroupId : IEnumerantParameter<SubgroupsPerWorkgroupId>
    {
        public int SubgroupsPerWorkgroup { get; set; }

        public static SubgroupsPerWorkgroupId Create(Span<int> words)
        {
            var parameter = new SubgroupsPerWorkgroupId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SubgroupsPerWorkgroupId parameter)
        {
            Span<int> span = [parameter.SubgroupsPerWorkgroup];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LocalSizeId : IEnumerantParameter<LocalSizeId>
    {
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int Zsize { get; set; }

        public static LocalSizeId Create(Span<int> words)
        {
            var parameter = new LocalSizeId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LocalSizeId parameter)
        {
            Span<int> span = [parameter.Xsize, parameter.Ysize, parameter.Zsize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct LocalSizeHintId : IEnumerantParameter<LocalSizeHintId>
    {
        public int Xsizehint { get; set; }
        public int Ysizehint { get; set; }
        public int Zsizehint { get; set; }

        public static LocalSizeHintId Create(Span<int> words)
        {
            var parameter = new LocalSizeHintId();
            return parameter;
        }

        public static implicit operator EnumerantParameters(LocalSizeHintId parameter)
        {
            Span<int> span = [parameter.Xsizehint, parameter.Ysizehint, parameter.Zsizehint];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct DenormPreserve : IEnumerantParameter<DenormPreserve>
    {
        public int TargetWidth { get; set; }

        public static DenormPreserve Create(Span<int> words)
        {
            var parameter = new DenormPreserve();
            return parameter;
        }

        public static implicit operator EnumerantParameters(DenormPreserve parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct DenormFlushToZero : IEnumerantParameter<DenormFlushToZero>
    {
        public int TargetWidth { get; set; }

        public static DenormFlushToZero Create(Span<int> words)
        {
            var parameter = new DenormFlushToZero();
            return parameter;
        }

        public static implicit operator EnumerantParameters(DenormFlushToZero parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SignedZeroInfNanPreserve : IEnumerantParameter<SignedZeroInfNanPreserve>
    {
        public int TargetWidth { get; set; }

        public static SignedZeroInfNanPreserve Create(Span<int> words)
        {
            var parameter = new SignedZeroInfNanPreserve();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SignedZeroInfNanPreserve parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct RoundingModeRTE : IEnumerantParameter<RoundingModeRTE>
    {
        public int TargetWidth { get; set; }

        public static RoundingModeRTE Create(Span<int> words)
        {
            var parameter = new RoundingModeRTE();
            return parameter;
        }

        public static implicit operator EnumerantParameters(RoundingModeRTE parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct RoundingModeRTZ : IEnumerantParameter<RoundingModeRTZ>
    {
        public int TargetWidth { get; set; }

        public static RoundingModeRTZ Create(Span<int> words)
        {
            var parameter = new RoundingModeRTZ();
            return parameter;
        }

        public static implicit operator EnumerantParameters(RoundingModeRTZ parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct IsApiEntryAMDX : IEnumerantParameter<IsApiEntryAMDX>
    {
        public int IsEntry { get; set; }

        public static IsApiEntryAMDX Create(Span<int> words)
        {
            var parameter = new IsApiEntryAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(IsApiEntryAMDX parameter)
        {
            Span<int> span = [parameter.IsEntry];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxNodeRecursionAMDX : IEnumerantParameter<MaxNodeRecursionAMDX>
    {
        public int Numberofrecursions { get; set; }

        public static MaxNodeRecursionAMDX Create(Span<int> words)
        {
            var parameter = new MaxNodeRecursionAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxNodeRecursionAMDX parameter)
        {
            Span<int> span = [parameter.Numberofrecursions];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct StaticNumWorkgroupsAMDX : IEnumerantParameter<StaticNumWorkgroupsAMDX>
    {
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int Zsize { get; set; }

        public static StaticNumWorkgroupsAMDX Create(Span<int> words)
        {
            var parameter = new StaticNumWorkgroupsAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(StaticNumWorkgroupsAMDX parameter)
        {
            Span<int> span = [parameter.Xsize, parameter.Ysize, parameter.Zsize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct ShaderIndexAMDX : IEnumerantParameter<ShaderIndexAMDX>
    {
        public int ShaderIndex { get; set; }

        public static ShaderIndexAMDX Create(Span<int> words)
        {
            var parameter = new ShaderIndexAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(ShaderIndexAMDX parameter)
        {
            Span<int> span = [parameter.ShaderIndex];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxNumWorkgroupsAMDX : IEnumerantParameter<MaxNumWorkgroupsAMDX>
    {
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int Zsize { get; set; }

        public static MaxNumWorkgroupsAMDX Create(Span<int> words)
        {
            var parameter = new MaxNumWorkgroupsAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxNumWorkgroupsAMDX parameter)
        {
            Span<int> span = [parameter.Xsize, parameter.Ysize, parameter.Zsize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SharesInputWithAMDX : IEnumerantParameter<SharesInputWithAMDX>
    {
        public int NodeName { get; set; }
        public int ShaderIndex { get; set; }

        public static SharesInputWithAMDX Create(Span<int> words)
        {
            var parameter = new SharesInputWithAMDX();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SharesInputWithAMDX parameter)
        {
            Span<int> span = [parameter.NodeName, parameter.ShaderIndex];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct OutputPrimitivesEXT : IEnumerantParameter<OutputPrimitivesEXT>
    {
        public int Primitivecount { get; set; }

        public static OutputPrimitivesEXT Create(Span<int> words)
        {
            var parameter = new OutputPrimitivesEXT();
            return parameter;
        }

        public static implicit operator EnumerantParameters(OutputPrimitivesEXT parameter)
        {
            Span<int> span = [parameter.Primitivecount];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SharedLocalMemorySizeINTEL : IEnumerantParameter<SharedLocalMemorySizeINTEL>
    {
        public int Size { get; set; }

        public static SharedLocalMemorySizeINTEL Create(Span<int> words)
        {
            var parameter = new SharedLocalMemorySizeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SharedLocalMemorySizeINTEL parameter)
        {
            Span<int> span = [parameter.Size];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct RoundingModeRTPINTEL : IEnumerantParameter<RoundingModeRTPINTEL>
    {
        public int TargetWidth { get; set; }

        public static RoundingModeRTPINTEL Create(Span<int> words)
        {
            var parameter = new RoundingModeRTPINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(RoundingModeRTPINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct RoundingModeRTNINTEL : IEnumerantParameter<RoundingModeRTNINTEL>
    {
        public int TargetWidth { get; set; }

        public static RoundingModeRTNINTEL Create(Span<int> words)
        {
            var parameter = new RoundingModeRTNINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(RoundingModeRTNINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FloatingPointModeALTINTEL : IEnumerantParameter<FloatingPointModeALTINTEL>
    {
        public int TargetWidth { get; set; }

        public static FloatingPointModeALTINTEL Create(Span<int> words)
        {
            var parameter = new FloatingPointModeALTINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FloatingPointModeALTINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FloatingPointModeIEEEINTEL : IEnumerantParameter<FloatingPointModeIEEEINTEL>
    {
        public int TargetWidth { get; set; }

        public static FloatingPointModeIEEEINTEL Create(Span<int> words)
        {
            var parameter = new FloatingPointModeIEEEINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FloatingPointModeIEEEINTEL parameter)
        {
            Span<int> span = [parameter.TargetWidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxWorkgroupSizeINTEL : IEnumerantParameter<MaxWorkgroupSizeINTEL>
    {
        public int Maxxsize { get; set; }
        public int Maxysize { get; set; }
        public int Maxzsize { get; set; }

        public static MaxWorkgroupSizeINTEL Create(Span<int> words)
        {
            var parameter = new MaxWorkgroupSizeINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxWorkgroupSizeINTEL parameter)
        {
            Span<int> span = [parameter.Maxxsize, parameter.Maxysize, parameter.Maxzsize];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaxWorkDimINTEL : IEnumerantParameter<MaxWorkDimINTEL>
    {
        public int Maxdimensions { get; set; }

        public static MaxWorkDimINTEL Create(Span<int> words)
        {
            var parameter = new MaxWorkDimINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaxWorkDimINTEL parameter)
        {
            Span<int> span = [parameter.Maxdimensions];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NumSIMDWorkitemsINTEL : IEnumerantParameter<NumSIMDWorkitemsINTEL>
    {
        public int Vectorwidth { get; set; }

        public static NumSIMDWorkitemsINTEL Create(Span<int> words)
        {
            var parameter = new NumSIMDWorkitemsINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NumSIMDWorkitemsINTEL parameter)
        {
            Span<int> span = [parameter.Vectorwidth];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct SchedulerTargetFmaxMhzINTEL : IEnumerantParameter<SchedulerTargetFmaxMhzINTEL>
    {
        public int Targetfmax { get; set; }

        public static SchedulerTargetFmaxMhzINTEL Create(Span<int> words)
        {
            var parameter = new SchedulerTargetFmaxMhzINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(SchedulerTargetFmaxMhzINTEL parameter)
        {
            Span<int> span = [parameter.Targetfmax];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct FPFastMathDefault : IEnumerantParameter<FPFastMathDefault>
    {
        public int TargetType { get; set; }
        public int FastMathMode { get; set; }

        public static FPFastMathDefault Create(Span<int> words)
        {
            var parameter = new FPFastMathDefault();
            return parameter;
        }

        public static implicit operator EnumerantParameters(FPFastMathDefault parameter)
        {
            Span<int> span = [parameter.TargetType, parameter.FastMathMode];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct StreamingInterfaceINTEL : IEnumerantParameter<StreamingInterfaceINTEL>
    {
        public int StallFreeReturn { get; set; }

        public static StreamingInterfaceINTEL Create(Span<int> words)
        {
            var parameter = new StreamingInterfaceINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(StreamingInterfaceINTEL parameter)
        {
            Span<int> span = [parameter.StallFreeReturn];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct RegisterMapInterfaceINTEL : IEnumerantParameter<RegisterMapInterfaceINTEL>
    {
        public int WaitForDoneWrite { get; set; }

        public static RegisterMapInterfaceINTEL Create(Span<int> words)
        {
            var parameter = new RegisterMapInterfaceINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(RegisterMapInterfaceINTEL parameter)
        {
            Span<int> span = [parameter.WaitForDoneWrite];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NamedBarrierCountINTEL : IEnumerantParameter<NamedBarrierCountINTEL>
    {
        public int BarrierCount { get; set; }

        public static NamedBarrierCountINTEL Create(Span<int> words)
        {
            var parameter = new NamedBarrierCountINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NamedBarrierCountINTEL parameter)
        {
            Span<int> span = [parameter.BarrierCount];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaximumRegistersINTEL : IEnumerantParameter<MaximumRegistersINTEL>
    {
        public int NumberofRegisters { get; set; }

        public static MaximumRegistersINTEL Create(Span<int> words)
        {
            var parameter = new MaximumRegistersINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaximumRegistersINTEL parameter)
        {
            Span<int> span = [parameter.NumberofRegisters];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct MaximumRegistersIdINTEL : IEnumerantParameter<MaximumRegistersIdINTEL>
    {
        public int NumberofRegisters { get; set; }

        public static MaximumRegistersIdINTEL Create(Span<int> words)
        {
            var parameter = new MaximumRegistersIdINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(MaximumRegistersIdINTEL parameter)
        {
            Span<int> span = [parameter.NumberofRegisters];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct NamedMaximumRegistersINTEL : IEnumerantParameter<NamedMaximumRegistersINTEL>
    {
        public NamedMaximumNumberOfRegisters NamedMaximumNumberofRegisters { get; set; }

        public static NamedMaximumRegistersINTEL Create(Span<int> words)
        {
            var parameter = new NamedMaximumRegistersINTEL();
            return parameter;
        }

        public static implicit operator EnumerantParameters(NamedMaximumRegistersINTEL parameter)
        {
            Span<int> span = [(int)parameter.NamedMaximumNumberofRegisters];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }
}

public static class TensorAddressingOperandsParameters
{
    public ref struct TensorView : IEnumerantParameter<TensorView>
    {
        public int IdRef0 { get; set; }

        public static TensorView Create(Span<int> words)
        {
            var parameter = new TensorView();
            return parameter;
        }

        public static implicit operator EnumerantParameters(TensorView parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }

    public ref struct DecodeFunc : IEnumerantParameter<DecodeFunc>
    {
        public int IdRef0 { get; set; }

        public static DecodeFunc Create(Span<int> words)
        {
            var parameter = new DecodeFunc();
            return parameter;
        }

        public static implicit operator EnumerantParameters(DecodeFunc parameter)
        {
            Span<int> span = [parameter.IdRef0];
            MemoryOwner<int> buffer = MemoryOwner<int>.Allocate(span.Length);
            span.CopyTo(buffer.Span);
            var result = new EnumerantParameters(buffer);
            return result;
        }
    }
}