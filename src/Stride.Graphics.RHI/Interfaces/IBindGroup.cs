namespace Stride.Graphics.RHI;


public interface IBindGroup : IDisposable
{
    string Label { get; set; }
}

public interface IBindGroupLayout : IDisposable
{
    string Label { get; set; }
}