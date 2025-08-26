using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers;

namespace Stride.Shaders.Spirv.Core;

internal static class LineBufferBuilder
{
    internal static LiteralArray<T> Create<T>(ReadOnlySpan<T> values)
        where T : ISpirvElement, IFromSpirv<T>
        => new(values);
}
[CollectionBuilder(typeof(LineBufferBuilder), "Create")]
public struct LiteralArray<T> : ISpirvElement, IFromSpirv<LiteralArray<T>>
    where T : ISpirvElement, IFromSpirv<T>
{
    MemoryOwner<T> Memory { get; set; }

    public int WordCount
    {
        get
        {
            int wordCount = 0;
            foreach (var item in Memory.Span)
                wordCount += item.WordCount;
            return wordCount;
        }
    }

    public LiteralArray(ReadOnlySpan<T> values)
    {
        Memory = MemoryOwner<T>.Allocate(values.Length);
        values.CopyTo(Memory.Span);
    }

    public SpanOwner<int> AsSpanOwner()
    {
        throw new NotImplementedException();
    }

    public static LiteralArray<T> From(Span<int> words)
    {
        throw new NotImplementedException();
    }

    public static LiteralArray<T> From(string value)
    {
        throw new NotImplementedException();
    }
}