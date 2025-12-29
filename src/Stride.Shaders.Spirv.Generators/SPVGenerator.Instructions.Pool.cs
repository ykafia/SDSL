using System.Collections.Concurrent;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace Stride.Shaders.Spirv.Generators;


internal class StringBuilderPool
{
    public static StringBuilderPool Instance { get; } = new StringBuilderPool();
    ConcurrentBag<StringBuilder> pool = [];

    private StringBuilderPool(){}
    public StringBuilder Get()
    {
        var sb = pool.TryTake(out var builder) ? builder : new StringBuilder();
        sb.Clear();
        return sb;
    }

    public void Return(StringBuilder sb)
    {
        pool.Add(sb);
    }
}