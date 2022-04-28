namespace Stride.Shader.Parser;

using Eto.Parse;
using Eto.Parse.Grammars;
using System.Text;
public static class StrideGrammar
{
    public static Grammar New()
    {
        return new EbnfGrammar(EbnfStyle.W3c).Build(Encoding.UTF8.GetString(GrammarResource.grammar),"shader");
    }
    public static Grammar New(string parser)
    {
        return new EbnfGrammar(EbnfStyle.W3c).Build(Encoding.UTF8.GetString(GrammarResource.grammar),parser);
    }
    public static Grammar Token()
    {
        return new EbnfGrammar(EbnfStyle.W3c).Build(Encoding.UTF8.GetString(GrammarResource.SDSLTokens),"BaseTypes");
    }
    public static Grammar HlslGrammar()
    {
        var s = new StringBuilder();
        s
            .Append(Encoding.UTF8.GetString(GrammarResource.SDSLTokens))
            .Append(Encoding.UTF8.GetString(GrammarResource.SDSLExpr));
        
        return new EbnfGrammar(EbnfStyle.W3c).Build(s.ToString(),"identifierOrKeyword");
    }
    public static Grammar HlslGrammar(string startParser)
    {
        var s = new StringBuilder();
        s
            .AppendLine(Encoding.UTF8.GetString(GrammarResource.SDSLTokens))
            .AppendLine(Encoding.UTF8.GetString(GrammarResource.SDSLDirective))
            .AppendLine(Encoding.UTF8.GetString(GrammarResource.SDSLExpr));
        
        return new EbnfGrammar(EbnfStyle.W3c).Build(s.ToString(),startParser);
    }
    
}   