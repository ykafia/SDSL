﻿using Eto.Parse;
using Stride.Shaders.Parsing.AST.Shader.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stride.Shaders.Parsing.AST.Shader;


public class ShaderLiteral : Expression
{
    public override string InferredType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public object Value {get;set;}
}

public class NumberLiteral : ShaderLiteral
{
    public bool Negative { get; set; } = false;
    public string? Suffix { get; set; }

    protected string? inferredType;

    public override string InferredType 
    {
        get
        {
            if (inferredType is not null)
                return inferredType;
            else
            {
                return Suffix switch
                {
                    "u" => "uint",
                    "l" => "long",
                    "f" => "float",
                    "d" => "double",
                    _ => "int"
                };
            }
        }
        set => inferredType = value; 
    }

    public NumberLiteral() { }

    public NumberLiteral(Match match)
    {
        Match = match;
        if (!match.HasMatches)
        {
            Value = match.Value;
        }
        else
        {
            if (match.Name == "SignedTermExpression")
            {

            }
            else
            {
                Value = match.Matches[0].Value;
                Suffix = match["Suffix"].StringValue;
            }
        }
    }
}
public class HexLiteral : NumberLiteral
{
    public override string InferredType 
    {
        get => inferredType ?? "long";
        set => inferredType = value;
    }


    public HexLiteral() { }

    public HexLiteral(Match match)
    {
        Match = match;
        Value = Convert.ToUInt64(match.StringValue, 16);
    }
}
public class StringLiteral : ShaderLiteral
{
    public override string InferredType { get => "string"; set => throw new NotImplementedException(); }

    public StringLiteral() { }

    public StringLiteral(Match match)
    {
        Match = match;
        Value = match.StringValue;
    }
}

public class BoolLiteral : ShaderLiteral
{
    public override string InferredType { get => "bool"; set => throw new NotImplementedException(); }

    public BoolLiteral() { }

    public BoolLiteral(Match match)
    {
        Match = match;
        Value = (bool)match.Value;
    }
}


public class TypeNameLiteral : ShaderLiteral
{
    public string Name { get; set; }

    public TypeNameLiteral(Match m)
    {
        Name = m.StringValue;
    }
}

public class VariableNameLiteral : ShaderLiteral
{
    public string Name { get; set; }

    public override string InferredType { get => inferredType ?? throw new NotImplementedException(); set => inferredType = value; }

    public VariableNameLiteral(string name)
    {
        Name = name;
    }

    public VariableNameLiteral(Match m)
    {
        Name = m.StringValue;
    }

    public override void TypeCheck(SymbolTable symbols)
    {
        if(symbols.TryGetType(Name, out var type))
        {
            this.inferredType = type;
        }
        else throw new NotImplementedException();
    }
    public override string ToString()
    {
        return $"{{ Variable : {Name} }}" ;
    }
}