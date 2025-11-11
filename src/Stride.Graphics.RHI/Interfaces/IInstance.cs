namespace Stride.Graphics.RHI;

public struct InstanceDescriptor;
public struct InstanceLimits;
public struct InstanceSupportedFeatures;
public struct RequestAdapterOptions;
public enum RequestAdapterStatus;
public unsafe delegate void RequestAdapterDelegate(RequestAdapterStatus status, IAdapter adapter, string message, void* userData);

public interface IInstance
{
    IAdapter RequestAdapter(in RequestAdapterOptions options, RequestAdapterDelegate callback);
    abstract static IInstance Create(InstanceDescriptor descriptor);
    abstract static InstanceSupportedFeatures GetSupportedFeatures();
    abstract static InstanceLimits GetLimits();
    abstract static string GetName();
}

