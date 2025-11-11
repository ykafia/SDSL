namespace Stride.Graphics.RHI;


public struct BufferDescriptor;

public enum MapMode;
public struct MapState;
public struct Usage;


public struct MappedRange
{
    public MapMode Mode { get; set; }
    public Memory<byte> Data { get; set; }
}

public struct ReadonlyMappedRanger
{
    public MapMode Mode { get; set; }
    public ReadOnlyMemory<byte> Data { get; set; }
}


public interface IBuffer : IResource
{
    int Size { get; }
    MapState MapState { get; }
    Usage Usage { get; }
    ReadonlyMappedRanger GetConstMappedRange(int offset, int size);
    Task<MappedRange> GetMappedRange(MapMode mode, int offset, int size);
    void Unmap();
    void Destroy();
}