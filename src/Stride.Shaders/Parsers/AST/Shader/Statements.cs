﻿using Eto.Parse;
using Spv.Generator;
using Stride.Shaders.Parsing.AST.Shader;
using Stride.Shaders.Parsing.AST.Shader.Analysis;
using Stride.Shaders.Spirv;
using Stride.Shaders.ThreeAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stride.Shaders.Parsing.AST.Shader;


public abstract class Statement : ShaderTokenTyped
{
    
    public IEnumerable<Register> LowCode {get;set;}
    public override string InferredType{get => throw new NotImplementedException();set => throw new NotImplementedException();}

    public string GetInferredType()
    {
        return InferredType;
    }

    public override void TypeCheck(SymbolTable symbols, string expected = "")
    {
        throw new NotImplementedException();
    }
}

public class EmptyStatement : Statement
{
    public override string InferredType => "void";
    public override void TypeCheck(SymbolTable symbols, string expected = ""){}
}

public abstract class Declaration : Statement
{
    public override string InferredType => "void";
    public string? TypeName {get;set;}
    public string VariableName { get; set; }
    public ShaderTokenTyped Value { get; set; }

}

public class DeclareAssign : Declaration, IStaticCheck, IStreamCheck
{
    public AssignOpToken AssignOp { get; set; }
    public bool UsesStream { get; set;}
    public bool UsesShaderVar {get;set;}

    public DeclareAssign(){}
    public DeclareAssign(Match m )
    {
        Match = m;
        AssignOp = m["AssignOp"].StringValue.ToAssignOp();
        TypeName = m["Type"].StringValue;
        VariableName = m["Variable"].StringValue;
        Value = (ShaderTokenTyped)GetToken(m["Value"]);
    }

    public void CheckStatic(SymbolTable s)
    {
        if(Value is IStaticCheck sc)
            sc.CheckStatic(s);
    }

    public void CheckStream(SymbolTable s)
    {
        if(Value is IStreamCheck sc)
            sc.CheckStream(s);
    }
}

public class AssignChain : Statement
{
    public override string InferredType => "void";

    public AssignOpToken AssignOp { get; set; }
    public bool StreamValue => AccessNames.Any() && AccessNames.First() == "streams";
    public IEnumerable<string> AccessNames { get; set; }
    public ShaderTokenTyped Value { get; set; }
    public AssignChain(Match m)
    {
        Match = m;
        AssignOp = m["AssignOp"].StringValue.ToAssignOp();
        AccessNames = m.Matches.Where(x => x.Name == "Identifier").Select(x => x.StringValue);
        Value = (ShaderTokenTyped)GetToken(m["PrimaryExpression"]);
    }
}

public class ReturnStatement : Statement
{
    public override string InferredType => ReturnValue?.InferredType ?? "void";
    
    public ShaderTokenTyped? ReturnValue {get;set;}
    public ReturnStatement(Match m)
    {
        Match = m;
        if(m.HasMatches)
            ReturnValue = (ShaderTokenTyped)GetToken(m["PrimaryExpression"]);
    }
}

public class BlockStatement : Statement 
{
    public IEnumerable<Statement> Statements {get;set;}
    public BlockStatement(Match m)
    {
        Match = m;
        Statements = m.Matches.Select(GetToken).Cast<Statement>().ToList();
    }
}
