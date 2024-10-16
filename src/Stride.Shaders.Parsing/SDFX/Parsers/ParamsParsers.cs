using Stride.Shaders.Parsing.SDSL;
using Stride.Shaders.Parsing.SDFX.AST;

namespace Stride.Shaders.Parsing.SDFX.Parsers;


public record struct ParamsParsers : IParser<EffectParameters>
{
    public readonly bool Match<TScanner>(ref TScanner scanner, ParseResult result, out EffectParameters parsed, in ParseError? orError = null) where TScanner : struct, IScanner
    {
        var position = scanner.Position;
        if (Terminals.Literal("params", ref scanner, advance: true) && CommonParsers.Spaces1(ref scanner, result, out _))
        {
            if (LiteralsParser.TypeName(ref scanner, result, out var paramsName))
            {
                parsed = new(paramsName, new());
                CommonParsers.Spaces0(ref scanner, result, out _);
                if (Terminals.Char('{', ref scanner, advance: true))
                {
                    CommonParsers.Spaces0(ref scanner, result, out _);
                    while (!scanner.IsEof)
                    {
                        if (Parameter(ref scanner, result, out var p))
                            parsed.Parameters.Add(p);
                        else if (CommonParsers.FollowedBy(ref scanner, Terminals.Char(';'), withSpaces: true, advance: true))
                        {
                            parsed.Info = scanner.GetLocation(position..scanner.Position);
                            return true;
                        }
                        else
                            CommonParsers.Exit(ref scanner, result, out parsed, position, new("Expected parameter definition or closing curly brace", scanner.CreateError(scanner.Position)));
                        CommonParsers.Spaces0(ref scanner, result, out _);
                    }
                }
            }
        }
        return CommonParsers.Exit(ref scanner, result, out parsed, position, orError);
    }
    public static bool Parameter<TScanner>(ref TScanner scanner, ParseResult result, out EffectParameter parsed, in ParseError? orError = null) where TScanner : struct, IScanner
            => new ParameterParser().Match(ref scanner, result, out parsed, orError);
}

public record struct ParameterParser : IParser<EffectParameter>
{
    public readonly bool Match<TScanner>(ref TScanner scanner, ParseResult result, out EffectParameter parsed, in ParseError? orError = null) where TScanner : struct, IScanner
    {
        var position = scanner.Position;

        if (LiteralsParser.TypeName(ref scanner, result, out var typename) && CommonParsers.Spaces1(ref scanner, result, out _))
        {
            if (LiteralsParser.Identifier(ref scanner, result, out var identifier))
            {
                if (CommonParsers.FollowedBy(ref scanner, Terminals.Char('='), withSpaces: true, advance: true))
                {
                    CommonParsers.Spaces0(ref scanner, result, out _);
                    if (ExpressionParser.Expression(ref scanner, result, out var expression) && CommonParsers.Spaces0(ref scanner, result, out _))
                    {
                        if (!Terminals.Char(';', ref scanner, advance: true))
                            return CommonParsers.Exit(ref scanner, result, out parsed, position, new("Expected semi colon", scanner.CreateError(scanner.Position)));
                        parsed = new(typename, identifier, scanner.GetLocation(position..scanner.Position), expression);
                        return true;
                    }
                }
                else if (CommonParsers.FollowedBy(ref scanner, Terminals.Char(';'), withSpaces: true, advance: true))
                {
                    parsed = new(typename, identifier, scanner.GetLocation(position..scanner.Position));
                    return true;
                }
                else return CommonParsers.Exit(ref scanner, result, out parsed, position, new("expected assignment or semi colon", scanner.CreateError(scanner.Position)));
            }
        }
        return CommonParsers.Exit(ref scanner, result, out parsed, position, orError);

    }
}