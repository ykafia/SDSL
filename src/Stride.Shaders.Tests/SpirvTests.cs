using Stride.Shaders.Spirv.Core;
using static Stride.Shaders.Spirv.Specification;
namespace Stride.Shaders.Parsing.Tests;


public class SpirvTests
{

    [Fact]
    public void DecorationInstructions()
    {
        var decoration = new OpDecorate(1, Decoration.LinkSDSL, [.."Hello world".AsDisposableLiteralValue().Words]);

        foreach(var operand in decoration.OpData)
        {
            if(operand.IsParameterizedEnumerant && operand.Name == "name")
            {
                Assert.Equal("Hello world", operand.ToLiteral<string>());
            }
        }
    }

}