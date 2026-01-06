using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers;

namespace Stride.Shaders.Spirv.Core;

public record struct ParameterizedFlag<T>(T Value, MemoryOwner<int> Parameters) : IDisposable
    where T : Enum
{
    public readonly Span<int> Span => Parameters.Span;
    public ParameterizedFlag(T value, ReadOnlySpan<int> parameters)
        : this(value, MemoryOwner<int>.Allocate(parameters.Length))
    {
        parameters.CopyTo(Parameters.Span);
    }
    public readonly void Dispose() => Parameters.Dispose();
    public readonly Span<int>.Enumerator GetEnumerator() => Parameters.Span.GetEnumerator();
    public static implicit operator ParameterizedFlag<T>(T value) => new(value, MemoryOwner<int>.Empty);

    public readonly override string ToString()
    {
        return $"{Value}";
    }
}

public interface IEnumerantParameter<T> where T : IEnumerantParameter<T>, allows ref struct
{
    abstract static T Create(Span<int> words);
}


public static class EnumerantParametersBuilder
{
    public static EnumerantParameters Create(ReadOnlySpan<int> words)
    {
        return new EnumerantParameters(words);
    }
}




[CollectionBuilder(typeof(EnumerantParametersBuilder), "Create")]
public ref partial struct EnumerantParameters
{
    public MemoryOwner<int> Words { get; private set; }
    public Span<int> Span => Words.Span;
    public EnumerantParameters()
    {
        Words = MemoryOwner<int>.Empty;
    }

    public EnumerantParameters(ReadOnlySpan<int> words)
    {
        Words = MemoryOwner<int>.Allocate(words.Length);
        words.CopyTo(Words.Span);
    }
    public EnumerantParameters(Span<int> words)
    {
        Words = MemoryOwner<int>.Allocate(words.Length);
        words.CopyTo(Words.Span);
    }

    public EnumerantParameters(MemoryOwner<int> words)
    {
        Words = words;
    }
    public readonly Span<int>.Enumerator GetEnumerator() => Words.Span.GetEnumerator();

    public readonly T To<T>()
        where T : IEnumerantParameter<T>, allows ref struct
    {
        return T.Create(Words.Span);
    }

    public readonly void Dispose()
    {
        Words?.Dispose();
    }
}


internal ref struct EnumerantParametersReader(Span<int> words)
{
    readonly Span<int> words = words;
    int position = 0;
    public bool End => position >= words.Length;
    public int ReadInt()
        => words[position++];
    public T ReadEnum<T>() where T : Enum
        => Unsafe.As<int, T>(ref words[position++]);
    public long ReadLong()
        => words[position++] | (words[position++] << 32);
    public float ReadFloat()
        => BitConverter.Int32BitsToSingle(words[position++]);
    public double ReadDouble()
        => BitConverter.Int64BitsToDouble(words[position++] | (words[position++] << 32));

    public string ReadString()
    {
        using var lit = new LiteralValue<string>(words[position..]);
        position += lit.Words.Length;
        return lit.Value;
    }
}
