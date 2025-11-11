namespace Stride.Graphics.RHI.WebGPU;

using Silk.NET.WebGPU;

public unsafe class WGPUAdapter : IAdapter
{
    Adapter wgpuAdapter;

    internal WGPUAdapter(Adapter* adapter)
    {
        wgpuAdapter = *adapter;
    }
    public RHI.AdapterInfo GetAdapterInfo()
    {
        throw new NotImplementedException();
    }

    public RHI.Limits GetLimits()
    {
        throw new NotImplementedException();
    }

    public SupportedFeatures GetSupportedFeatures()
    {
        throw new NotImplementedException();
    }

    public bool IsFeatureSupported(RHI.FeatureName feature)
    {
        throw new NotImplementedException();
    }

    public void RequestDevice(in RHI.DeviceDescriptor descriptor, in RequestDeviceCallbackInfo callbackInfo)
    {
        throw new NotImplementedException();
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }

}