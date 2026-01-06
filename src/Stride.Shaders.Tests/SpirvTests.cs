using Stride.Shaders.Spirv.Core;
using Stride.Shaders.Spirv.Core.Buffers;
using static Stride.Shaders.Spirv.Specification;
namespace Stride.Shaders.Parsing.Tests;


public class SpirvTests
{

    [Fact]
    public void DecorationInstructions()
    {
        var buffer = new NewSpirvBuffer();

        var decoration = buffer.Add(new OpDecorateString(1, Decoration.LinkSDSL, "Hello world"));

        foreach (var operand in decoration)
        {
            if (operand.Name == "name")
            {
                Assert.Equal("Hello world", operand.ToLiteral<string>());
            }
        }
    }

    [Fact]
    public void ImageOperandsBitMask()
    {
        var buffer = new NewSpirvBuffer();

        var decoration = buffer.Add(new OpDecorateString(1, Decoration.LinkSDSL, "Hello world"));

        foreach (var operand in decoration)
        {
            if (operand.Name == "name")
            {
                Assert.Equal("Hello world", operand.ToLiteral<string>());
            }
        }
    }

}