using Eto.Parse;

namespace Stride.Shaders.Parsing.AST.Shader.Analysis;

public interface ISymbolType : ISymbol, IEquatable<ISymbolType>
{
    public bool IsAccessorValid(string accessor);
    public bool IsIndexingValid(string index);
    public bool TryAccessType(string accessor, out ISymbolType typeOfAccessed);
}

public class ArrayType : ISymbolType
{
    public ISymbolType TypeName { get; set; }


    public bool Equals(ISymbolType? other)
    {
        return other is ArrayType a && a.TypeName.Equals(TypeName);
    }

    public bool IsAccessorValid(string accessor)
    {
        return false;
    }

    public bool IsIndexingValid(string index)
    {
        return true;
    }

    public bool TryAccessType(string accessor, out ISymbolType typeOfAccessed)
    {
        typeOfAccessed = ScalarType.VoidType;
        if (int.TryParse(accessor, out var _))
        {
            typeOfAccessed = TypeName;
            return true;
        }
        return false;
    }
}

public class CompositeType : ISymbolType
{
    public string Name { get; set; }
    public Dictionary<string, ISymbolType> Fields { get; set; } = new();

    public CompositeType(string name, Dictionary<string, ISymbolType> fields)
    {
        Name = name;
        Fields = fields;
    }

    public bool Equals(ISymbolType? other)
    {
        return true;
        // return other is CompositeType a && a.Fields.Keys.All(f => a.Fields[f].Equals());
    }

    public bool IsAccessorValid(string accessor)
    {
        return Fields.ContainsKey(accessor);
    }

    public bool IsIndexingValid(string index)
    {
        return false;
    }
    public bool TryAccessType(string accessor, out ISymbolType typeOfAccessed)
    {
        var result = Fields.TryGetValue(accessor, out var tmp );
        typeOfAccessed = tmp ?? ScalarType.VoidType;
        return result;
    }
}

public class VectorType : ISymbolType
{
    public int Size { get; set; }
    public ISymbolType TypeName { get; set; }
    static string[] accessors = new string[] { "x", "y", "z", "w" };

    public VectorType(string size, ISymbolType type)
    {
        if (int.TryParse(size, out var s))
        {
            Size = s;
            TypeName = type;
        }
        else throw new NotImplementedException();
    }

    public bool IsAccessorValid(string accessor)
    {
        return accessor.All(accessor[0..Size].Contains);
    }

    public bool IsIndexingValid(string index)
    {
        return false;
    }

    public bool Equals(ISymbolType? other)
    {
        throw new NotImplementedException();
    }
    public bool TryAccessType(string accessor, out ISymbolType typeOfAccessed)
    {
        if(IsAccessorValid(accessor))
        {
            typeOfAccessed = TypeName;
            return true;
        }
        typeOfAccessed = ScalarType.VoidType;
        return false;
    }
}
public class MatrixType : ISymbolType
{
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    public ISymbolType TypeName { get; set; }

    static readonly Grammar accessorGrammar = new(
      Terminals.Literal("_")
      .Then("m" & Terminals.Set("0123") & Terminals.Set("0123"))
      .Or(Terminals.Set("1234") & Terminals.Set("1234"))
      .WithName("accessor")
    );

    public bool IsAccessorValid(string accessor)
    {
        return accessorGrammar.Match(accessor).Success;
    }

    public bool IsIndexingValid(string index)
    {
        return false;
    }

    public bool Equals(ISymbolType? other)
    {
        throw new NotImplementedException();
    }
    public bool TryAccessType(string accessor, out ISymbolType typeOfAccessed)
    {
        if(IsAccessorValid(accessor))
        {
            typeOfAccessed = TypeName;
            return true;
        }
        typeOfAccessed = ScalarType.VoidType;
        return false;
    }
}
public class ScalarType : ISymbolType
{
    public static readonly ScalarType VoidType = new("void");
    public string TypeName { get; set; }

    public ScalarType(string type)
    {
        TypeName = type;
    }

    public bool IsAccessorValid(string accessor)
    {
        return false;
    }

    public bool IsIndexingValid(string index)
    {
        return false;
    }

    public bool Equals(ISymbolType? other)
    {
        return other is ScalarType o && TypeName == o.TypeName;
    }
    public bool TryAccessType(string accessor, out ISymbolType typeOfAccessed)
    {
        typeOfAccessed = ScalarType.VoidType;
        return false;
    }
}