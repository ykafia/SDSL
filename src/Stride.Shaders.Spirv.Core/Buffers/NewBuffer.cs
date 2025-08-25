#pragma warning disable CS9264 // Non-nullable property must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or safely handling the case where 'field' is null in the 'get' accessor.

using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance;
using CommunityToolkit.HighPerformance.Buffers;
using Stride.Shaders.Spirv.Core.Parsing;

namespace Stride.Shaders.Spirv.Core.Buffers;


public struct OpData : IDisposable
{
    public MemoryOwner<int> Memory { get; internal set { field?.Dispose(); field = value; } }
    public readonly SDSLOp Op => (SDSLOp)(Memory.Span[0] & 0xFFFF);

    public OpData()
    {
        Memory = MemoryOwner<int>.Empty;
    }

    public OpData(MemoryOwner<int> memory)
    {
        Memory = memory;
    }

    public readonly void Dispose() => Memory.Dispose();

    public readonly T Get<T>(string name)
        where T : struct, IFromSpirv<T>
    {
        foreach (var o in this)
        {
            if (name == o.Name && (o.Kind.ToString().Contains("Literal") || o.Kind.ToString().Contains("Id")))
                return o.To<T>();
        }
        throw new Exception($"No operand '{name}' in op {Op}");
    }
    public readonly T GetEnum<T>(string name)
        where T : Enum
    {
        foreach (var o in this)
        {
            if (name == o.Name && !o.Kind.ToString().Contains("Literal") && !o.Kind.ToString().Contains("Id"))
                return o.ToEnum<T>();
        }
        throw new Exception($"No enum operand '{name}' in op {Op}");
    }

    public readonly OpDataEnumerator GetEnumerator() => new(Memory.Span);
}


public record struct OpDataIndex(int Index, NewSpirvBuffer Buffer)
{
    public readonly ref OpData Data => ref Buffer[Index];
}

// public struct OpName : IHandyInstruction2
// {
//     public OpDataIndex? DataIndex { get; set; }
//     public string Name { get; set { field = value; UpdateMemory(); } }
//     public int Target { get; set { field = value; Memory.Span[1] = value; } }
//     public MemoryOwner<int> Memory
//     {
//         readonly get
//         {
//             if (DataIndex is OpDataIndex odi)
//                 return odi.Buffer[odi.Index].Memory;
//             else return field;
//         }

//         private set
//         {
//             if (DataIndex is OpDataIndex odi)
//             {
//                 odi.Buffer[odi.Index].Memory.Dispose();
//                 odi.Buffer[odi.Index].Memory = value;
//             }
//             else field = value;
//         }
//     }
//     public OpName(OpDataIndex index)
//     {
//         DataIndex = index;
//         foreach (var o in index.Buffer[index.Index])
//         {
//             if (o.Name == "target")
//                 Target = o.To<IdRef>();
//             else if (o.Name == "name")
//                 Name = o.To<LiteralString>();
//         }
//     }
//     public OpName(int target, string name)
//     {
//         Name = name;
//         Target = target;
//         Memory = MemoryOwner<int>.Allocate(3);
//         Memory.Span[0] = 2 << 16 & ((int)SDSLOp.OpName);
//         UpdateMemory();
//     }


//     public void UpdateMemory()
//     {
//         Span<int> instruction = [(int)SDSLOp.OpName, .. Target.AsSpirvSpan(), .. Name.AsSpirvSpan()];
//         instruction[0] |= instruction.Length << 16;
//         var tmp = MemoryOwner<int>.Allocate(instruction.Length);
//         instruction.CopyTo(tmp.Span);
//         Memory?.Dispose();
//         Memory = tmp;
//     }

//     public override readonly string ToString() => $"OpName : {Name}";

//     public static implicit operator OpName(OpDataIndex odi) => new(odi);
// }

public class NewSpirvBuffer
{
    List<OpData> Memory { get; set; } = [];

    internal ref OpData this[int index] => ref CollectionsMarshal.AsSpan(Memory)[index];
    // internal OpDataIndex this[int index] => new(index, this);

    public void Add(OpData data)
        => Memory.Add(data);

    public void Add<T>(ref T instruction) where T : IHandyInstruction2
    {
        if (instruction.DataIndex is OpDataIndex odi)
        {
            if (odi.Buffer == this)
                return;
            else
                Memory.Add(new(instruction.Memory));
        }
        else Memory.Add(new(instruction.Memory));
        instruction.DataIndex = new(Memory.Count - 1, this);
        
    }

    public void Insert(int index, OpData data)
        => Memory.Insert(index, data);

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= Memory.Count)
            return false;
        Memory[index].Dispose();
        Memory.RemoveAt(index);
        return true;
    }

    public Enumerator GetEnumerator() => new(this);

    public ref struct Enumerator(NewSpirvBuffer buffer)
    {
        readonly NewSpirvBuffer buffer = buffer;
        private readonly List<OpData> span = buffer.Memory;
        private int index = -1;

        public readonly OpDataIndex Current => new(index, buffer);

        public bool MoveNext()
        {
            if (index < span.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }
    }
}