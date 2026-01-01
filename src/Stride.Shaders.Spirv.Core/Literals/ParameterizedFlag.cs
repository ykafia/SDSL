using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers;
using Stride.Shaders.Spirv.Core.Buffers;

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


public ref struct UserSemantic : IEnumerantParameter<UserSemantic>
{

    public string SemanticName { get; set; }

    public static UserSemantic Create(Span<int> words)
    {
        return new UserSemantic();
    }
}

public ref partial struct EnumerantParameters
{
    public MemoryOwner<int> Words { get; private set; }
    public Span<int> Span => Words.Span;
    public EnumerantParameters()
    {
        Words = MemoryOwner<int>.Empty;
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
}

// public ref struct OpMyInstruction
// {
//     public Specification.Decoration Decoration { get; set; }
//     public EnumerantParameters Parameters
//     {
//         get => field;
//         set
//         {
//             field.Words.Dispose();
//             field = value;
//             UpdateInstructionMemory();
//         }
//     }
// }

public static class Example
{
    public static void Something()
    {
        var opdata = new OpData();
        var p = new EnumerantParameters();
        var userSemantic = p.To<UserSemantic>();
    }
}