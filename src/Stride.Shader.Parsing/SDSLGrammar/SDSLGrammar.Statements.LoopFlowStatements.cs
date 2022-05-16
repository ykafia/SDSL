using Eto.Parse;
using Eto.Parse.Parsers;
using static Eto.Parse.Terminals;

namespace Stride.Shader.Parsing;
public partial class SDSLGrammar : Grammar
{
    public AlternativeParser WhileLoop = new() { Name = "ForLoop"};
    public AlternativeParser ForEachLoop = new() { Name = "ForLoop"};
    public SequenceParser ForLoop = new() { Name = "ForLoop"};

    public void CreateLoopFlowStatements()
    {
        var ws = WhiteSpace.Repeat(0);
        var ws1 = WhiteSpace.Repeat(1);

        var valueDeclare = new SequenceParser(
            ((ValueTypes | Identifier) & Identifier).SeparatedBy(ws1),
            "=",
            PrimaryExpression
        )
        { Separator = ws };
        var valueAssign = new SequenceParser(
            Identifier,
            AssignOperators,
            PrimaryExpression
        )
        { Separator = ws };

        ForLoop.Add(
            For,
            LeftParen,
            valueDeclare,
            Semi,
            PrimaryExpression,
            Semi,
            valueAssign | PrimaryExpression,
            RightParen,
            Semi 
            | (
                LeftBrace &
                Statement.Repeat(0).SeparatedBy(ws) &
                RightBrace
            ).SeparatedBy(ws)

        );
        ForLoop.Separator = ws;

    }
}