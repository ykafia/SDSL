namespace Stride.Graphics.RHI;


public interface IDevice
{
    void RunGarbageCollection();
    ICommandList CreateCommandList();
    IBuffer CreateTexture(TextureDescriptor descriptor);
    ITexture CreateBuffer(BufferDescriptor descriptor);
}