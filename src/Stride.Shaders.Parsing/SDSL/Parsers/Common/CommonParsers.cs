using System.Security.Cryptography;
using Stride.Shaders.Parsing.SDSL.AST;

namespace Stride.Shaders.Parsing.SDSL;



public delegate bool ParserDelegate<TScanner>(ref TScanner scanner, ParseResult result)
    where TScanner : struct, IScanner;
public delegate bool ParserValueDelegate<TScanner, TResult>(ref TScanner scanner, ParseResult result, out TResult parsed, ParseError? orError = null)
    where TScanner : struct, IScanner;
public delegate bool ParserOptionalValueDelegate<TScanner, TResult>(ref TScanner scanner, ParseResult result, out TResult? parsed, ParseError? orError = null)
    where TScanner : struct, IScanner;

public static class CommonParsers
{
    public static bool Exit<TScanner, TNode>(ref TScanner scanner, ParseResult result, out TNode parsed, int beginningPosition, in ParseError? orError = null)
        where TScanner : struct, IScanner
        where TNode : class
    {
        if (orError is not null)
        {
            result.Errors.Add(orError.Value);
            scanner.Position = scanner.End;
            parsed = null!;
            return false;
        }
        if (result.Errors.Count == 0)
            scanner.Position = beginningPosition;
        parsed = null!;
        return false;
    }

    public static bool Spaces0<TScanner>(ref TScanner scanner, ParseResult result, out NoNode node, in ParseError? orError = null, bool onlyWhiteSpace = false)
        where TScanner : struct, IScanner
        => new Space0(onlyWhiteSpace).Match(ref scanner, result, out node, in orError);
    public static bool Spaces1<TScanner>(ref TScanner scanner, ParseResult result, out NoNode node, in ParseError? orError = null, bool onlyWhiteSpace = false)
       where TScanner : struct, IScanner
        => new Space1(onlyWhiteSpace).Match(ref scanner, result, out node, in orError);


    public static bool Optional<TScanner, TTerminal>(ref TScanner scanner, TTerminal terminal, bool advance = false)
        where TScanner : struct, IScanner
        where TTerminal : struct, ITerminal
    {
        terminal.Match(ref scanner, advance: advance);
        return true;
    }
    public static bool Optional<TScanner, TNode>(ref TScanner scanner, IParser<TNode> parser, ParseResult result, out TNode? node)
        where TScanner : struct, IScanner
        where TNode : Node
    {
        parser.Match(ref scanner, result, out node);
        return true;
    }

    public static bool FollowedBy<TScanner, TTerminal>(ref TScanner scanner, TTerminal terminal, bool withSpaces = false, bool advance = false)
        where TScanner : struct, IScanner
        where TTerminal : struct, ITerminal
    {
        var position = scanner.Position;
        if (withSpaces)
            Spaces0(ref scanner, null!, out _);
        if (terminal.Match(ref scanner, advance: advance))
        {
            if (!advance)
                scanner.Position = position;
            return true;
        }
        scanner.Position = position;
        return false;
    }
    public static bool FollowedByDel<TScanner>(ref TScanner scanner, ParseResult result, ParserDelegate<TScanner> func, bool withSpaces = false, bool advance = false)
        where TScanner : struct, IScanner
    {
        var position = scanner.Position;
        if (withSpaces)
            Spaces0(ref scanner, null!, out _);
        if (func.Invoke(ref scanner, result))
        {
            if (!advance)
                scanner.Position = position;
            return true;
        }
        scanner.Position = position;
        return false;
    }
    public static bool FollowedBy<TScanner, TResult>(ref TScanner scanner, ParseResult result, ParserValueDelegate<TScanner, TResult> func, out TResult parsed, bool withSpaces = false, bool advance = false)
        where TScanner : struct, IScanner
    {
        var position = scanner.Position;
        if (withSpaces)
            Spaces0(ref scanner, null!, out _);
        if (func.Invoke(ref scanner, result, out parsed))
        {
            if (!advance)
                scanner.Position = position;
            return true;
        }
        scanner.Position = position;
        return false;
    }

    public static bool Until<TScanner>(ref TScanner scanner, char value, bool advance = false)
        where TScanner : struct, IScanner
    {
        while (!scanner.IsEof && !Terminals.Char(value, ref scanner, advance))
            scanner.Advance(1);
        return scanner.IsEof;
    }
    public static bool Until<TScanner>(ref TScanner scanner, string value, bool advance = false)
        where TScanner : struct, IScanner
    {
        while (!scanner.IsEof && !Terminals.Literal(value, ref scanner, advance))
            scanner.Advance(1);
        return scanner.IsEof;
    }
    public static bool Until<TScanner>(ref TScanner scanner, ReadOnlySpan<string> values, bool advance = false)
        where TScanner : struct, IScanner
    {
        while (!scanner.IsEof)
        {
            foreach (var value in values)
                if (Terminals.Literal(value, ref scanner, advance))
                    return scanner.IsEof;
            scanner.Advance(1);
        }
        return scanner.IsEof;
    }
    public static bool Until<TScanner, TTerminal>(ref Scanner scanner, bool advance = false)
        where TScanner : struct, IScanner
        where TTerminal : struct, ITerminal
    {
        var t = new TTerminal();
        while (!scanner.IsEof && !t.Match(ref scanner, advance))
            scanner.Advance(1);
        return !scanner.IsEof;
    }
    public static bool Until<TScanner, TTerminal1, TTerminal2>(ref Scanner scanner, TTerminal1? terminal1 = null, TTerminal2? terminal2 = null, bool advance = false)
        where TScanner : struct, IScanner
        where TTerminal1 : struct, ITerminal
        where TTerminal2 : struct, ITerminal
    {
        var t1 = terminal1 ?? new TTerminal1();
        var t2 = terminal2 ?? new TTerminal2();
        while (!scanner.IsEof && !(t1.Match(ref scanner, advance) || t2.Match(ref scanner, advance)))
            scanner.Advance(1);
        return !scanner.IsEof;
    }
    public static bool Until<TScanner, TTerminal1, TTerminal2, TTerminal3>(ref Scanner scanner, TTerminal1? terminal1 = null, TTerminal2? terminal2 = null, TTerminal3? terminal3 = null, bool advance = false)
        where TScanner : struct, IScanner
        where TTerminal1 : struct, ITerminal
        where TTerminal2 : struct, ITerminal
        where TTerminal3 : struct, ITerminal
    {
        var t1 = terminal1 ?? new TTerminal1();
        var t2 = terminal2 ?? new TTerminal2();
        var t3 = terminal3 ?? new TTerminal3();
        while (!scanner.IsEof && !(t1.Match(ref scanner, advance) || t2.Match(ref scanner, advance) || t3.Match(ref scanner, advance)))
            scanner.Advance(1);
        return !scanner.IsEof;
    }


    public static bool Repeat<TScanner, TParser, TNode>(ref TScanner scanner, TParser parser, ParseResult result, out List<TNode> nodes, int minimum, bool withSpaces = false, string? separator = null, in ParseError? orError = null)
        where TScanner : struct, IScanner
        where TParser : struct, IParser<TNode>
        where TNode : Node
    {
        return Repeat(ref scanner, (ref TScanner s, ParseResult r, out TNode node, ParseError? orError) => new TParser().Match(ref s, r, out node, orError), result, out nodes, minimum, withSpaces, separator, orError);
    }
    public static bool Repeat<TScanner, TNode>(ref TScanner scanner, ParserValueDelegate<TScanner, TNode> parser, ParseResult result, out List<TNode> nodes, int minimum, bool withSpaces = false, string? separator = null, in ParseError? orError = null)
        where TScanner : struct, IScanner
        where TNode : Node
    {
        var position = scanner.Position;
        nodes = [];
        while (!scanner.IsEof)
        {
            if (parser.Invoke(ref scanner, result, out var node))
            {
                nodes.Add(node);
                if (withSpaces)
                    Spaces0(ref scanner, result, out _);
            }
            else break;

            if (separator is not null)
            {
                if (Terminals.Literal(separator, ref scanner, advance: true))
                {
                    if (withSpaces)
                        Spaces0(ref scanner, result, out _);
                }
                else if(nodes.Count >= minimum)
                    return true;
                else return Exit(ref scanner, result, out nodes, position, orError);
            }
        }
        if (nodes.Count >= minimum)
            return true;
        else return Exit(ref scanner, result, out nodes, position, orError);
    }
}