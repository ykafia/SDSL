namespace Stride.Shaders.Parsing.SDSL.AST;


public abstract class ShaderBodyStaticControlFlow(TextLocation info) : ShaderElement(info)
{
    public abstract Node GenerateBody();
}



public class StaticConditional(Expression condition, List<ShaderElement> ifTrue, List<ShaderElement> elseBody, TextLocation info) : ShaderBodyStaticControlFlow(info)
{
    public Expression Condition { get; set; } = condition;
    public List<ShaderElement> IfTrue { get; set; } = ifTrue;
    public List<Expression> ElseIfConditions { get; set; } = [];
    public List<List<ShaderElement>> ElseIfBodies { get; set; } = [];
    public List<ShaderElement> Else { get; set; } = elseBody;

    public override Node GenerateBody()
    {
        throw new NotImplementedException();
    }
}