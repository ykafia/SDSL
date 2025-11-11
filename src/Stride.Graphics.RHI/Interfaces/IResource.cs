namespace Stride.Graphics.RHI;

public interface IResource : IDisposable
{
    void AddRef();
    void Release();
    T GetNativeObject<T>();
}