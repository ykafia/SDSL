namespace SDSL.Parsing.AST.Shader.Symbols;

public record struct VariableSymbol(string Name, SymbolType Type)
{
    public static VariableSymbol None => new(null!, SymbolType.Void);
}

