using Silk.NET.WebGPU;

using WebGPUApi = Silk.NET.WebGPU.WebGPU;

namespace Stride.Graphics.RHI.WebGPU;


public unsafe class WGPUInstance : IInstance
{
    Instance* wgpuInstance;

    public IAdapter RequestAdapter(in RequestAdapterOptions options, RequestAdapterDelegate callback)
    {
        var opt = options.ToWebGPU();
        RequestAdapterCallback cb = (status, adapter, data, userData) =>
        {
            throw new NotImplementedException();
            // callback((RequestAdapterStatus)a, new WGPUAdapter { wgpuAdapter = *b }, SilkMarshal.PtrToString((nint)c), d);
        };
        Adapter* wgpuAdapter = null;
        api.InstanceRequestAdapter(wgpuInstance, &opt, cb, wgpuAdapter);
        return new WGPUAdapter(wgpuAdapter);
    }


    static WebGPUApi api = null!;

    public static IInstance Create(InstanceDescriptor descriptor)
    {
        api ??= WebGPUApi.GetApi();
        WGPUInstance instance = new();
        var wgpuInstanceDesc = descriptor.ToWebGPU();
        instance.wgpuInstance = api.CreateInstance(&wgpuInstanceDesc);
        return instance;
    }

    public static InstanceSupportedFeatures GetSupportedFeatures()
    {
        throw new NotImplementedException();
    }

    public static InstanceLimits GetLimits()
    {
        throw new NotImplementedException();
    }

    public static string GetName()
    {
        throw new NotImplementedException();
    }
}

static class WebGPUExtensions
{
    public static Silk.NET.WebGPU.InstanceDescriptor ToWebGPU(this InstanceDescriptor descriptor)
    {
        Silk.NET.WebGPU.InstanceDescriptor webgpuDescriptor = new()
        {
        };
        return webgpuDescriptor;
    }
    public static Silk.NET.WebGPU.RequestAdapterOptions ToWebGPU(this RequestAdapterOptions options)
    {
        Silk.NET.WebGPU.RequestAdapterOptions webgpuOptions = new()
        {
        };
        return webgpuOptions;
    }
}