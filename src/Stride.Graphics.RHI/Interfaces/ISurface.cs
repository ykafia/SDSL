namespace Stride.Graphics.RHI;


public struct SurfaceCapabilities;
public struct SurfaceConfiguration;
public interface ISurface
{
    IAdapter Adapter { get; }
    SurfaceCapabilities GetCapabilities();
    void Configure(in SurfaceConfiguration configuration);
}
