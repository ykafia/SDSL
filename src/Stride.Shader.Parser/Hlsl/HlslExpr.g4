parser grammar HlslExpr;

@parser::header {
	#pragma warning disable 3021
}

options {
	tokenVocab = HlslAntlrLexer;
}

compilationUnit
    :    Declarations+=topLevelDeclaration* EndOfFileToken=EOF
    ;

topLevelDeclaration
	:   classDefinition
	|   interfaceDefinition
	|   variableDeclarationStatement
	|   structDefinition
	|   constantBuffer
	|   functionDefinition
	|   functionDeclaration
    ;

classDefinition
	:   ClassKeyword=Class Name=Identifier BaseListOpt=baseList? 
	    OpenBraceToken=LeftBrace classMemberDeclaration* CloseBraceToken=RightBrace
		SemicolonToken=Semi
	;

baseList
	:   ColonToken=Colon BaseType=Identifier
	;

classMemberDeclaration
	:   variableDeclarationStatement
	|   functionDefinition
	|   functionDeclaration
	;

constantBuffer
	:   CBufferKeyword=CBuffer Name=Identifier registerAllocation?
	    OpenBraceToken=LeftBrace (Fields+=variableDeclarationStatement)+ CloseBraceToken=RightBrace
		SemicolonToken=Semi?
	;

variableDeclarationStatement
	:   variableDeclaration SemicolonToken=Semi
	;

functionDefinition
	:   attribute* functionType (ClassName=Identifier ColonColonToken=ColonColon)? Name=Identifier
	    OpenParenToken=LeftParen functionParams? CloseParenToken=RightParen
		SemanticOpt=semantic? block SemicolonTokenOpt=Semi?
	;

functionDeclaration
	:   attribute* functionType Name=Identifier
	    OpenParenToken=LeftParen functionParams? CloseParenToken=RightParen
		SemanticOpt=semantic? SemicolonToken=Semi
	;

functionType
	:   type
	|   Void
	;

functionParams
	:   functionParam (Comma functionParam)*
	;

functionParam
	:   storageFlags type variableDeclarator
	;

interfaceDefinition
	:   InterfaceKeyword=Interface Name=Identifier
	    OpenBraceToken=LeftBrace functionDeclaration* CloseBraceToken=RightBrace
		SemicolonToken=Semi
	;

structDefinition
	:   StructKeyword=Struct Name=Identifier
	    OpenBraceToken=LeftBrace (Fields+=variableDeclarationStatement)+ CloseBraceToken=RightBrace
		SemicolonToken=Semi
	;

semantic
	:   ColonToken=Colon Name=Identifier
	;

// --------------------------------------
// ATTRIBUTES
// --------------------------------------

attributeArguments
	:   literalExpr (Comma literalExpr)*
	;

attributeArgumentList
	:   OpenParenToken=LeftParen attributeArguments CloseParenToken=RightParen
	;

attribute
	:   OpenBracketToken=LeftBracket Name=Identifier attributeArgumentList? CloseBracketToken=RightBracket
	;

// --------------------------------------
// STATEMENTS
// --------------------------------------

block
	:   OpenBrace=LeftBrace Stmts+=statement* CloseBrace=RightBrace
	;

indentedEmbeddedStatement
	:   embeddedStatement // not a block statement
	|   LeftBrace Stmt=block
	;

statement
	:   localDeclarationStatement
	|   embeddedStatement
	|   classDefinition
	|   interfaceDefinition
	|   structDefinition
	;

localDeclarationStatement
	:   variableDeclaration SemicolonToken=Semi
	;

forInitializer
	:   variableDeclaration            # ForStatementDeclaration
	|   expression (Comma expression)* # ForStatementInitializers
	;

forIncrementors
	:   expression (Comma expression)*
	;

switchLabel
	:   CaseKeyword=Case Expr=expression ColonToken=Colon # CaseSwitchLabel
	|   DefaultKeyword=Default ColonToken=Colon           # DefaultSwitchLabel
	;

switchSection
	:   switchLabel+ statement+
	;

embeddedStatement
	:   SemicolonToken=Semi # EmptyStatement
	|   block # BlockStatement
	|   Expr=expression SemicolonToken=Semi # ExpressionStatement

	// Selection statement
	|   attribute* IfKeyword=If OpenParenToken=LeftParen Condition=expression CloseParenToken=RightParen Stmt=indentedEmbeddedStatement elseClause? # IfStatement
	|   attribute* SwitchKeyword=Switch OpenParenToken=LeftParen Expr=expression CloseParenToken=RightParen OpenBraceToken=LeftBrace switchSection* CloseBraceToken=RightBrace     # SwitchStatement
	
	// Iteration statement
	|   attribute* WhileKeyword=While OpenParenToken=LeftParen condition=expression CloseParenToken=RightParen indentedEmbeddedStatement # WhileStatement
	|   attribute* DoKeyword=Do indentedEmbeddedStatement WhileKeyword=While OpenParenToken=LeftParen Condition=expression CloseParenToken=RightParen SemicolonToken=Semi # DoStatement
	|   attribute* ForKeyword=For OpenParenToken=LeftParen forInitializer? FirstSemicolonToken=Semi Condition=expression? SecondSemicolonToken=Semi iterator=forIncrementors? CloseParenToken=RightParen indentedEmbeddedStatement # ForStatement

	// Jump statement
	|   BreakKeyword=Break SemicolonToken=Semi # BreakStatement
	|   ContinueKeyword=Continue SemicolonToken=Semi # ContinueStatement
	|   DiscardKeyword=Discard SemicolonToken=Semi # DiscardStatement
	|   ReturnKeyword=Return Expr=expression? SemicolonToken=Semi # ReturnStatement
	;

elseClause
	:   ElseKeyword=Else Stmt=indentedEmbeddedStatement
	;

// --------------------------------------
// EXPRESSIONS
// --------------------------------------

expression
    :   literalExpr                                                                              # LiteralExpression
	|   Identifier                                                                               # IdentifierExpression
    |   OpenParenToken=LeftParen expression CloseParenToken=RightParen                           # ParenthesizedExpression
    |   OpenParenToken=LeftParen type (ArrayRankSpecifiers+=arrayRankSpecifier)* CloseParenToken=RightParen Expr=expression # CastExpression
    |   Expr=expression DotToken=Dot Member=Identifier                                           # MemberAccessExpression
	|   scalarOrVectorOrMatrixType argumentList                                                  # NumericConstructorExpression
    |   Expr=expression argumentList                                                             # FunctionCallExpression
    |   Expr=expression OpenBracket=LeftBracket Index=expression CloseBracket=RightBracket       # ArrayAccessExpression
    |   Expr=expression Operator=postfixUnaryOperator                                            # PostfixUnaryExpression
    |   Operator=prefixUnaryOperator Expr=expression                                             # PrefixUnaryExpression
    |   Left=expression Operator=binaryOperator Right=expression                                 # BinaryExpression
	|   Condition=expression QuestionToken=Question TrueExpr=expression ColonToken=Colon FalseExpr=expression # ConditionalExpression
    |   <assoc=right> Left=expression Operator=assignmentOperator Right=expression               # AssignmentExpression
	;

literalExpr
	:   literal
	;

postfixUnaryOperator
	:   PlusPlus
	|   MinusMinus
	;

prefixUnaryOperator
	:   Plus
	|   Minus
	|   Not
	|   Tilde
	|   PlusPlus
	|   MinusMinus
	;

binaryOperator
	:   Star
	|   Div
	|   Mod
	|   Plus
	|   Minus
	|   LeftShift
	|   RightShift
	|   Less
	|   Greater
	|   LessEqual
	|   GreaterEqual
	|   Equal
	|   NotEqual
	|   And
	|   Caret
	|   Or
	|   AndAnd
	|   OrOr
	;

assignmentOperator
	:   Assign
	|   StarAssign
	|   DivAssign
	|   ModAssign
	|   PlusAssign
	|   MinusAssign
	|   LeftShiftAssign
	|   RightShiftAssign
	|   AndAssign
	|   XorAssign
	|   OrAssign
	;

argumentList
	:   OpenParenToken=LeftParen arguments? CloseParenToken=RightParen
	;

arguments
	:   expression (Comma expression)*
	;



// --------------------------------------
// TYPES
// --------------------------------------

variableDeclaration
	:   storageFlags type variableDeclarators
	;

variableDeclarators
	:   variableDeclarator (Comma variableDeclarator)*
	;

variableDeclarator
	:   Name=Identifier
        (ArrayRankSpecifiers+=arrayRankSpecifier)*
        packOffsetNode?
        RegisterAllocation=registerAllocation?
        SemanticOpt=semantic?
        variableInitializer?
	;

arrayRankSpecifier
	:   OpenBracketToken=LeftBracket Dimension=expression? CloseBracketToken=RightBracket
	;

packOffsetNode
	:   ColonToken=Colon PackoffsetKeyword=Packoffset OpenParenToken=LeftParen
	    PackOffsetRegister=Identifier (DotToken=Dot PackOffsetComponent=Identifier)?
		CloseParenToken=RightParen
	;

storageFlags
	:   storageFlag*
	;

storageFlag
	// Type modifiers
	:   Const
	|   RowMajor
	|   ColumnMajor
	// Storage classes
	|   Extern
	|   Precise
	|   Shared
	|   Groupshared
	|   Static
	|   Uniform
	|   Volatile
	// Interpolation modifiers
	|   Linear
	|   Centroid
	|   Nointerpolation
	|   Noperspective
	|   Sample
	// Parameter modifiers (only valid on function params)
	|   In
	|   Out
	|   Inout
	// Geometry shader primitive type
	|   Point
	|   Line_
	|   Triangle
	|   LineAdj
	|   TriangleAdj
	;

type
	:   predefinedType
	|   userDefinedType
	;

predefinedType
	:   bufferPredefinedType
	|   byteAddressBufferPredefinedType
	|   inlineStructPredefinedType
	|   patchPredefinedType
	|   matrixType
	|   genericMatrixPredefinedType
	|   samplerStatePredefinedType
	|   scalarType
	|   streamOutputPredefinedType
	|   structuredBufferPredefinedType
	|   texturePredefinedType
	|   genericTexturePredefinedType
	|   msTexturePredefinedType
	|   vectorType
	|   genericVectorType
	;

bufferPredefinedType
	:   bufferType LessThanToken=Less scalarOrVectorType GreaterThanToken=Greater
	;

bufferType
	:   Buffer
	|   RWBuffer
	;

byteAddressBufferPredefinedType
	:   byteAddressBufferType
	;

byteAddressBufferType
	:   ByteAddressBuffer
	|   RWByteAddressBuffer
	;

inlineStructPredefinedType
	:   StructKeyword=Struct OpenBraceToken=LeftBrace
	    (variableDeclarationStatement)+
		CloseBraceToken=RightBrace
	;

patchPredefinedType
	:   Keyword=patchType LessThanToken=Less
	    Name=userDefinedType CommaToken=Comma ControlPoints=IntegerLiteral
		GreaterThanToken=Greater
	;

patchType
	:   InputPatch
	|   OutputPatch
	;

samplerStatePredefinedType
	:   Sampler
	|   SamplerState
	|   SamplerComparisonState
	;

scalarType
	:   Bool
	|   Int
	|   Unsigned Int
	|   Dword
	|   Uint
	|   Half
	|   Float
	|   Double
	;

streamOutputPredefinedType
	:   Keyword=streamOutputObjectType LessThanToken=Less type GreaterThanToken=Greater
	;

streamOutputObjectType
	:   PointStream
	|   LineStream
	|   TriangleStream
	;

structuredBufferPredefinedType
	:   Keyword=structuredBufferName LessThanToken=Less scalarOrVectorOrUserDefinedType GreaterThanToken=Greater
	;

structuredBufferName
	:   AppendStructuredBuffer
	|   ConsumeStructuredBuffer
	|   RWStructuredBuffer
	|   StructuredBuffer
	;

textureType
	:   Texture1D
	|   Texture1DArray
	|   Texture2D
	|   Texture2DArray
	|   Texture3D
	|   TextureCube
	|   TextureCubeArray
	;

texturePredefinedType
	:   textureType
	;

genericTexturePredefinedType
	:   textureType LessThanToken=Less scalarOrVectorType GreaterThanToken=Greater
	;

textureTypeMS
	:   Texture2DMS
	|   Texture2DMSArray
	;

msTexturePredefinedType
	:   textureTypeMS LessThanToken=Less scalarOrVectorType CommaToken=Comma Samples=IntegerLiteral GreaterThanToken=Greater
	;

vectorType
	:   Vector
	|   Bool1
	|   Bool2
	|   Bool3
	|   Bool4
	|   Int1
	|   Int2
	|   Int3
	|   Int4
	|   Uint1
	|   Uint2
	|   Uint3
	|   Uint4
	|   Half1
	|   Half2
	|   Half3
	|   Half4
	|   Float1
	|   Float2
	|   Float3
	|   Float4
	|   Double1
	|   Double2
	|   Double3
	|   Double4
	;

genericVectorType
	:   VectorKeyword=Vector LessThanToken=Less scalarType CommaToken=Comma
	    Size_=IntegerLiteral GreaterThanToken=Greater
	;

scalarOrVectorType
	:   scalarType
	|   vectorType
	;

scalarOrVectorOrUserDefinedType
	:   scalarType
	|   vectorType
	|   userDefinedType
	;

scalarOrVectorOrMatrixType
	:   scalarType
	|   vectorType
	|   matrixType
	;

matrixType
	:   Matrix
	|   Bool1x1
	|   Bool1x2
	|   Bool1x3
	|   Bool1x4
	|   Bool2x1
	|   Bool2x2
	|   Bool2x3
	|   Bool2x4
	|   Bool3x1
	|   Bool3x2
	|   Bool3x3
	|   Bool3x4
	|   Bool4x1
	|   Bool4x2
	|   Bool4x3
	|   Bool4x4
	|   Int1x1
	|   Int1x2
	|   Int1x3
	|   Int1x4
	|   Int2x1
	|   Int2x2
	|   Int2x3
	|   Int2x4
	|   Int3x1
	|   Int3x2
	|   Int3x3
	|   Int3x4
	|   Int4x1
	|   Int4x2
	|   Int4x3
	|   Int4x4
	|   Uint1x1
	|   Uint1x2
	|   Uint1x3
	|   Uint1x4
	|   Uint2x1
	|   Uint2x2
	|   Uint2x3
	|   Uint2x4
	|   Uint3x1
	|   Uint3x2
	|   Uint3x3
	|   Uint3x4
	|   Uint4x1
	|   Uint4x2
	|   Uint4x3
	|   Uint4x4
	|   Half1x1
	|   Half1x2
	|   Half1x3
	|   Half1x4
	|   Half2x1
	|   Half2x2
	|   Half2x3
	|   Half2x4
	|   Half3x1
	|   Half3x2
	|   Half3x3
	|   Half3x4
	|   Half4x1
	|   Half4x2
	|   Half4x3
	|   Half4x4
	|   Float1x1
	|   Float1x2
	|   Float1x3
	|   Float1x4
	|   Float2x1
	|   Float2x2
	|   Float2x3
	|   Float2x4
	|   Float3x1
	|   Float3x2
	|   Float3x3
	|   Float3x4
	|   Float4x1
	|   Float4x2
	|   Float4x3
	|   Float4x4
	|   Double1x1
	|   Double1x2
	|   Double1x3
	|   Double1x4
	|   Double2x1
	|   Double2x2
	|   Double2x3
	|   Double2x4
	|   Double3x1
	|   Double3x2
	|   Double3x3
	|   Double3x4
	|   Double4x1
	|   Double4x2
	|   Double4x3
	|   Double4x4
	;

genericMatrixPredefinedType
	:   MatrixKeyword=Matrix LessThanToken=Less scalarType FirstCommaToken=Comma
	    Rows_=IntegerLiteral SecondCommaToken=Comma Cols_=IntegerLiteral
		GreaterThanToken=Greater
	;

userDefinedType
	:   Name=Identifier
	;

registerAllocation
	:   RegisterColon=Colon RegisterKeyword=Register OpenParenToken=LeftParen Address=Identifier CloseParenToken=RightParen
	;

variableInitializer
	:   EqualsToken=Assign standardVariableInitializer         # StandardVariableInitializer_
	|   OpenBraceToken=LeftBrace samplerStateProperty* CloseBraceToken=RightBrace # SamplerStateInitializer
	;

standardVariableInitializer
	:   OpenBrace=LeftBrace arrayElementInitializers CloseBrace=RightBrace # ArrayVariableInitializer
	|   Expr=expression # ExpressionVariableInitializer
	;

arrayElementInitializers
	:   standardVariableInitializer (Comma standardVariableInitializer)* Comma?
	;

samplerStateProperty
	:   Name=Identifier EqualsToken=Assign Expr=expression SemicolonToken=Semi
	;

literal
	:   True
	|   False
    |   FloatLiteral
    |   IntegerLiteral
    |   StringLiteral
    ;



// --------------------------------------
// PREPROCESSOR DIRECTIVES
// --------------------------------------

directive
	:   ifDirective
	|   ifDefDirective
	|   ifNDefDirective
	|   elseDirective
	|   elifDirective
	|   endIfDirective
	|   objectLikeDefineDirective
	|   includeDirective
	|   lineDirective
	;

ifDirective
	:   HashToken=Hash IfKeyword=If Condition=directiveExpression EndOfDirectiveToken=EndOfDirective
	;

ifDefDirective
	:   HashToken=Hash IfDefKeyword=IfDef Name=Identifier EndOfDirectiveToken=EndOfDirective
	;

ifNDefDirective
	:   HashToken=Hash IfNDefKeyword=IfNDef Name=Identifier EndOfDirectiveToken=EndOfDirective
	;

elseDirective
	:   HashToken=Hash ElseKeyword=Else EndOfDirectiveToken=EndOfDirective
	;

elifDirective
	:   HashToken=Hash ElifKeyword=Elif Condition=directiveExpression EndOfDirectiveToken=EndOfDirective
	;

endIfDirective
	:   HashToken=Hash EndIfKeyword=EndIf EndOfDirectiveToken=EndOfDirective
	;

objectLikeDefineDirective
	:   HashToken=Hash DefineKeyword=Define Name=identifierOrKeyword Values+=~(EndOfDirective)* EndOfDirectiveToken=EndOfDirective
	;

includeDirective
	:   HashToken=Hash IncludeKeyword=Include Filename=StringLiteral EndOfDirectiveToken=EndOfDirective
	;

lineDirective
	:   HashToken=Hash LineKeyword=Line_ LineNumber=IntegerLiteral Filename=StringLiteral EndOfDirectiveToken=EndOfDirective
	;

directiveExpression
    :   literal                                                                     # LiteralDirectiveExpression
	|   identifierOrKeyword                                                         # IdentifierDirectiveExpression
    |   OpenParenToken=LeftParen directiveExpression CloseParenToken=RightParen     # ParenthesizedDirectiveExpression
    |   Function=Defined OpenParenToken=LeftParen Name=. CloseParenToken=RightParen # FunctionCallDirectiveExpression
    |   Expr=directiveExpression Operator=postfixUnaryOperator                      # PostfixUnaryDirectiveExpression
    |   Operator=prefixUnaryOperator Expr=directiveExpression                       # PrefixUnaryDirectiveExpression
    |   Left=directiveExpression Operator=binaryOperator Right=directiveExpression  # BinaryDirectiveExpression
	;

identifierOrKeyword
	:   AppendStructuredBuffer
	|   Bool
	|   Bool1
	|   Bool2
	|   Bool3
	|   Bool4
	|   Bool1x1
	|   Bool1x2
	|   Bool1x3
	|   Bool1x4
	|   Bool2x1
	|   Bool2x2
	|   Bool2x3
	|   Bool2x4
	|   Bool3x1
	|   Bool3x2
	|   Bool3x3
	|   Bool3x4
	|   Bool4x1
	|   Bool4x2
	|   Bool4x3
	|   Bool4x4
	|   Buffer
	|   ByteAddressBuffer
	|   Break
	|   Case
	|   CBuffer
	|   Centroid
	|   Class
	|   ColumnMajor
	|   Const
	|   ConsumeStructuredBuffer
	|   Continue
	|   Default
	|   Discard
	|   Do
	|   Double
	|   Double1
	|   Double2
	|   Double3
	|   Double4
	|   Double1x1
	|   Double1x2
	|   Double1x3
	|   Double1x4
	|   Double2x1
	|   Double2x2
	|   Double2x3
	|   Double2x4
	|   Double3x1
	|   Double3x2
	|   Double3x3
	|   Double3x4
	|   Double4x1
	|   Double4x2
	|   Double4x3
	|   Double4x4
	|   Else
	|   Extern
	|   Float
	|   Float1
	|   Float2
	|   Float3
	|   Float4
	|   Float1x1
	|   Float1x2
	|   Float1x3
	|   Float1x4
	|   Float2x1
	|   Float2x2
	|   Float2x3
	|   Float2x4
	|   Float3x1
	|   Float3x2
	|   Float3x3
	|   Float3x4
	|   Float4x1
	|   Float4x2
	|   Float4x3
	|   Float4x4
	|   For
	|   Groupshared
	|   Half
	|   Half1
	|   Half2
	|   Half3
	|   Half4
	|   Half1x1
	|   Half1x2
	|   Half1x3
	|   Half1x4
	|   Half2x1
	|   Half2x2
	|   Half2x3
	|   Half2x4
	|   Half3x1
	|   Half3x2
	|   Half3x3
	|   Half3x4
	|   Half4x1
	|   Half4x2
	|   Half4x3
	|   Half4x4
	|   If
	|   In
	|   Inout
	|   InputPatch
	|   Int
	|   Int1
	|   Int2
	|   Int3
	|   Int4
	|   Int1x1
	|   Int1x2
	|   Int1x3
	|   Int1x4
	|   Int2x1
	|   Int2x2
	|   Int2x3
	|   Int2x4
	|   Int3x1
	|   Int3x2
	|   Int3x3
	|   Int3x4
	|   Int4x1
	|   Int4x2
	|   Int4x3
	|   Int4x4
	|   Interface
	|   Line_
	|   LineAdj
	|   Linear
	|   LineStream
	|   Matrix
	|   Nointerpolation
	|   Noperspective
	|   Out
	|   OutputPatch
	|   Packoffset
	|   Point
	|   PointStream
	|   Precise
	|   Register
	|   Return
	|   RowMajor
	|   RWBuffer
	|   RWByteAddressBuffer
	|   RWStructuredBuffer
	|   Sample
	|   Sampler
	|   SamplerComparisonState
	|   SamplerState
	|   Shared
	|   Static
	|   Struct
	|   StructuredBuffer
	|   Switch
	|   Texture1D
	|   Texture1DArray
	|   Texture2D
	|   Texture2DArray
	|   Texture2DMS
	|   Texture2DMSArray
	|   Texture3D
	|   TextureCube
	|   TextureCubeArray
	|   Triangle
	|   TriangleAdj
	|   TriangleStream
	|   Uniform
	|   Uint
	|   Uint1
	|   Uint2
	|   Uint3
	|   Uint4
	|   Uint1x1
	|   Uint1x2
	|   Uint1x3
	|   Uint1x4
	|   Uint2x1
	|   Uint2x2
	|   Uint2x3
	|   Uint2x4
	|   Uint3x1
	|   Uint3x2
	|   Uint3x3
	|   Uint3x4
	|   Uint4x1
	|   Uint4x2
	|   Uint4x3
	|   Uint4x4
	|   Vector
	|   Volatile
	|   Void
	|   While
	|   Identifier
	;