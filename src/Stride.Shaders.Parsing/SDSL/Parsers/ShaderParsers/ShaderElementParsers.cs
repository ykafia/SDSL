using Stride.Shaders.Parsing.SDSL.AST;

namespace Stride.Shaders.Parsing.SDSL;


public record struct ShaderElementParsers : IParser<ShaderElement>
{
    public readonly bool Match<TScanner>(ref TScanner scanner, ParseResult result, out ShaderElement parsed, in ParseError? orError = null)
        where TScanner : struct, IScanner
    {
        var position = scanner.Position;
        if (BufferParsers.Buffer(ref scanner, result, out var buffer))
        {
            parsed = buffer;
            return true;
        }
        else if(Struct(ref scanner, result, out var structElement))
        {
            parsed = structElement;
            return true;
        }
        else
        {
            bool isStaged = false;
            bool isStreamed = false;
            bool hasAttributes = ShaderAttributeListParser.AttributeList(ref scanner, result, out var attributes, orError);
            var tmpPos = scanner.Position;
            
            if (Terminals.Literal("stage", ref scanner, advance: true) && CommonParsers.Spaces1(ref scanner, result, out _))
            {
                isStaged = true;
                tmpPos = scanner.Position;
            }
            else
                scanner.Position = tmpPos;
            if (Terminals.Literal("stream", ref scanner, advance: true) && CommonParsers.Spaces1(ref scanner, result, out _))
                isStreamed = true;
            else
                scanner.Position = tmpPos;
            if (ShaderMemberParser.Member(ref scanner, result, out var member))
            {
                member.IsStream = isStreamed;
                member.IsStaged = isStaged;
                if(hasAttributes)
                    member.Attributes = attributes.Attributes;
                parsed = member;
                return true;
            }
            else if (Method(ref scanner, result, out var method))
            {
                method.IsStaged = isStaged;
                if(hasAttributes)
                    member.Attributes = attributes.Attributes;
                parsed = method;
                return true;
            }
            else if(Compose(ref scanner, result, out var compose))
            {
                compose.IsStaged = isStaged;
                if(hasAttributes)
                    compose.Attributes = attributes.Attributes;
                parsed = compose;
                return true;
            }
            else return CommonParsers.Exit(ref scanner, result, out parsed, position);
        }
        
    }
    public static bool Compose<TScanner>(ref TScanner scanner, ParseResult result, out ShaderCompose parsed, in ParseError? orError = null)
        where TScanner : struct, IScanner
        => new CompositionParser().Match(ref scanner, result, out parsed, in orError);
    public static bool Struct<TScanner>(ref TScanner scanner, ParseResult result, out ShaderStruct parsed, in ParseError? orError = null)
        where TScanner : struct, IScanner
        => new ShaderStructParser().Match(ref scanner, result, out parsed, in orError);
    public static bool ShaderElement<TScanner>(ref TScanner scanner, ParseResult result, out ShaderElement parsed, in ParseError? orError = null)
        where TScanner : struct, IScanner
        => new ShaderElementParsers().Match(ref scanner, result, out parsed, in orError);

    public static bool Method<TScanner>(ref TScanner scanner, ParseResult result, out ShaderMethod parsed, in ParseError? orError = null)
        where TScanner : struct, IScanner
        => new ShaderMethodParsers().Match(ref scanner, result, out parsed, in orError);
}