namespace Stride.Graphics.RHI;


public struct SupportedFeatures;
public struct AdapterInfo;
public struct Limits;
public struct FeatureName;
public struct DeviceDescriptor;
public struct RequestDeviceCallbackInfo;
public enum RequestDeviceStatus;
public delegate void RequestDeviceCallback<TData1, TData2>(RequestDeviceStatus status, IDevice device, string message, ref TData1 userdata1, ref TData2 userdata2);


public interface IAdapter : IDisposable
{
    AdapterInfo GetAdapterInfo();
    Limits GetLimits();
    SupportedFeatures GetSupportedFeatures();
    bool IsFeatureSupported(FeatureName feature);
    void RequestDevice(in DeviceDescriptor descriptor, in RequestDeviceCallbackInfo callbackInfo);
}