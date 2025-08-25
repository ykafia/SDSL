using Stride.Shaders.Core;
using Stride.Shaders.Experiments;
using Stride.Shaders.Parsing;
using Stride.Shaders.Parsing.SDSL;
using Stride.Shaders.Parsing.SDSL.AST;
using Stride.Shaders.Spirv.Core.Buffers;
using Stride.Shaders.Spirv.Core;

static void TryNewBuffer()
{
    var buff = new NewSpirvBuffer();

    OpTypeFloat t_float = new(0, 32, Spv.Specification.FPEncoding.Max);
    buff.Add(ref t_float);

    t_float.ResultId = 14;
    Console.WriteLine(t_float.ToString());
    foreach (var e in buff)
    {
        OpTypeFloat tmp = e;
        tmp.ResultId = 13;
        Console.WriteLine(e);
    }
}

TryNewBuffer();

// Examples.CompileSDSL();
// Examples.TryAllFiles();
// Examples.CreateShader();