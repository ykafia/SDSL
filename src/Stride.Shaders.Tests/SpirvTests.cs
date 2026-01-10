using Stride.Shaders.Spirv.Core;
using Stride.Shaders.Spirv.Core.Buffers;
using static Stride.Shaders.Spirv.Specification;
namespace Stride.Shaders.Parsing.Tests;


public class SpirvTests
{


    [Fact]
    public void DecorationLinkInstructions()
    {
        var buffer = new NewSpirvBuffer();

        var decoration = buffer.Add(new OpDecorateString(1, Decoration.LinkSDSL, "Hello world"));
        int count = -1;
        foreach (var operand in decoration)
        {
            count++;
            switch(count, operand.Name)
            {
                case (0, "target"):
                    Assert.Equal(1, operand.ToLiteral<int>());
                    break;
                case (1, "decoration"):
                    Assert.Equal(Decoration.LinkSDSL, operand.ToEnum<Decoration>());
                    break;
                case (2, "value"):
                    Assert.Equal("Hello world", operand.ToLiteral<string>());
                    break;
                default:
                    Assert.Fail($"not the correct operand : {operand.Name} at {count}");
                    break;
            };
        }

        OpDecorateString d = buffer[0];
        Assert.Equal(Decoration.LinkSDSL, d.Decoration);
        Assert.Equal("Hello world", d.Value);
    }

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
    public void ConstantValue()
    {
        var buffer = new NewSpirvBuffer();
        buffer.FluentAdd(new OpTypeFloat(1, 32, null), out var floatType)
        .FluentAdd(new OpConstant<float>(1, 2, 3.0f), out var constant);

        var i = buffer[1];
        Assert.Equal(4, i.Data.Memory.Length);
        foreach (var operand in i.Data)
        {
            if (operand.Name == "value")
            {
                Assert.Equal(3.0f, operand.ToLiteral<float>());
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