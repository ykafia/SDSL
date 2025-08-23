using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OmniSharp.Extensions.LanguageServer.Protocol;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using Stride.Shaders.Parsing.SDSL.AST;


namespace Stride.Shaders.Parsing.LSP;

public class SemanticTokensHandler(ILogger<SemanticTokensHandler> logger) : SemanticTokensHandlerBase
{
    private readonly ILogger _logger = logger;

    public override async Task<SemanticTokens?> Handle(
        SemanticTokensParams request, CancellationToken cancellationToken
    )
    {
        var result = await base.Handle(request, cancellationToken).ConfigureAwait(false);
        return result;
    }

    public override async Task<SemanticTokens?> Handle(
        SemanticTokensRangeParams request, CancellationToken cancellationToken
    )
    {
        var result = await base.Handle(request, cancellationToken).ConfigureAwait(false);
        return result;
    }

    public override async Task<SemanticTokensFullOrDelta?> Handle(
        SemanticTokensDeltaParams request,
        CancellationToken cancellationToken
    )
    {
        var result = await base.Handle(request, cancellationToken).ConfigureAwait(false);
        return result;
    }

    protected override async Task Tokenize(
        SemanticTokensBuilder builder, ITextDocumentIdentifierParams identifier,
        CancellationToken cancellationToken
    )
    {
        using var typesEnumerator = RotateEnum(SemanticTokenType.Defaults).GetEnumerator();
        using var modifiersEnumerator = RotateEnum(SemanticTokenModifier.Defaults).GetEnumerator();
        // you would normally get this from a common source that is managed by current open editor, current active editor, etc.
        var content = await File.ReadAllTextAsync(DocumentUri.GetFileSystemPath(identifier), cancellationToken).ConfigureAwait(false);
        await Task.Yield();

        var result = SDSLParser.Parse(content);
        if (result.AST is ShaderFile sf && sf.Namespaces.Count > 0)
        {
            foreach (var ns in sf.Namespaces)
            {
                _logger.LogInformation($"Handling namespace : {ns.Namespace}");
                foreach (var nsId in ns.NamespacePath)
                    builder.Push(nsId.Info.Line, nsId.Info.Column, nsId.Info.Length, SemanticTokenType.Namespace, SemanticTokenModifier.Static);

                foreach (var declaration in ns.Declarations)
                {
                    if (declaration is ShaderClass shaderClass)
                        shaderClass.Tokenize(builder, identifier, cancellationToken, logger);
                }
            }
        }

        // foreach (var (line, text) in content.Split('\n').Select((text, line) => (line, text)))
        // {
        //     var parts = text.TrimEnd().Split(';', ' ', '.', '"', '(', ')');
        //     var index = 0;
        //     foreach (var part in parts)
        //     {
        //         typesEnumerator.MoveNext();
        //         modifiersEnumerator.MoveNext();
        //         if (string.IsNullOrWhiteSpace(part)) continue;
        //         index = text.IndexOf(part, index, StringComparison.Ordinal);
        //         builder.Push(line, index, part.Length, typesEnumerator.Current, modifiersEnumerator.Current);
        //     }
        // }
    }

    protected override Task<SemanticTokensDocument>
        GetSemanticTokensDocument(ITextDocumentIdentifierParams @params, CancellationToken cancellationToken)
    {
        return Task.FromResult(new SemanticTokensDocument(RegistrationOptions.Legend));
    }


    private IEnumerable<T> RotateEnum<T>(IEnumerable<T> values)
    {
        while (true)
        {
            foreach (var item in values)
                yield return item;
        }
    }

    protected override SemanticTokensRegistrationOptions CreateRegistrationOptions(
        SemanticTokensCapability capability, ClientCapabilities clientCapabilities
    )
    {
        return new SemanticTokensRegistrationOptions
        {
            DocumentSelector = TextDocumentSelector.ForLanguage("sdsl"),
            Legend = new SemanticTokensLegend
            {
                TokenModifiers = capability.TokenModifiers,
                TokenTypes = capability.TokenTypes
            },
            Full = new SemanticTokensCapabilityRequestFull
            {
                Delta = true
            },
            Range = true
        };
    }
}


public static class SemanticTokenizerExtensions
{
    public static void Tokenize(this ShaderClass @class, SemanticTokensBuilder builder, ITextDocumentIdentifierParams identifier, CancellationToken cancellationToken, ILogger? logger = null)
    {
        logger?.LogInformation("Tokenizing class: {ClassName}", @class.Name.Name);
        builder.Push(@class.Name.Info.Line, @class.Name.Info.Column, @class.Name.Info.Length, SemanticTokenType.Class, SemanticTokenModifier.Static);
        foreach (var member in @class.Elements)
        {
            if (member is ShaderMethod method)
                method.Tokenize(builder, identifier, cancellationToken, logger);
            else if (member is ShaderStruct shaderStruct)
                shaderStruct.Tokenize(builder, identifier, cancellationToken, logger);
        }
    }
    public static void Tokenize(this ShaderMethod method, SemanticTokensBuilder builder, ITextDocumentIdentifierParams identifier, CancellationToken cancellationToken, ILogger? logger = null)
    {
        logger?.LogInformation("Tokenizing method: {MethodName}", method.Name.Name);
        builder.Push(method.Name.Info.Line, method.Name.Info.Column, method.Name.Info.Length, SemanticTokenType.Method, SemanticTokenModifier.Static);
        if (method.ReturnTypeName is not null)
        {
            builder.Push(method.ReturnTypeName.Info.Line, method.ReturnTypeName.Info.Column, method.ReturnTypeName.Info.Length, SemanticTokenType.Type, SemanticTokenModifier.Static);
        }
        foreach (var parameter in method.Parameters)
        {
            builder.Push(parameter.Name.Info.Line, parameter.Name.Info.Column, parameter.Name.Info.Length, SemanticTokenType.Parameter, SemanticTokenModifier.Static);
            if (parameter.TypeName is not null)
            {
                builder.Push(parameter.TypeName.Info.Line, parameter.TypeName.Info.Column, parameter.TypeName.Info.Length, SemanticTokenType.Type, SemanticTokenModifier.Static);
            }
        }
    }
    public static void Tokenize(this ShaderStruct shaderStruct, SemanticTokensBuilder builder, ITextDocumentIdentifierParams identifier, CancellationToken cancellationToken, ILogger? logger = null)
    {
        logger?.LogInformation("Tokenizing struct: {Struct}", shaderStruct.Info);
        builder.Push(shaderStruct.Info.Line, shaderStruct.Info.Column, 6, SemanticTokenType.Keyword, SemanticTokenModifier.Static);
        builder.Push(shaderStruct.TypeName.Info.Line, shaderStruct.TypeName.Info.Column, shaderStruct.TypeName.Info.Length, SemanticTokenType.Struct, SemanticTokenModifier.Static);
        foreach (var member in shaderStruct.Members)
        {
            if (member is ShaderStructMember shaderMember)
            {
                builder.Push(shaderMember.Name.Info.Line, shaderMember.Name.Info.Column, shaderMember.Name.Info.Length, SemanticTokenType.Variable, SemanticTokenModifier.Static);
                if (shaderMember.TypeName is not null)
                {
                    builder.Push(shaderMember.TypeName.Info.Line, shaderMember.TypeName.Info.Column, shaderMember.TypeName.Info.Length, SemanticTokenType.Type, SemanticTokenModifier.Static);
                }
            }
        }
    }
}