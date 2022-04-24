lexer grammar HlslTokens;

@lexer::header {#pragma warning disable 3021}

AppendStructuredBuffer : 'AppendStructuredBuffer';
Bool : 'bool';
Bool1 : 'bool1';
Bool2 : 'bool2';
Bool3 : 'bool3';
Bool4 : 'bool4';
Bool1x1 : 'bool1x1';
Bool1x2 : 'bool1x2';
Bool1x3 : 'bool1x3';
Bool1x4 : 'bool1x4';
Bool2x1 : 'bool2x1';
Bool2x2 : 'bool2x2';
Bool2x3 : 'bool2x3';
Bool2x4 : 'bool2x4';
Bool3x1 : 'bool3x1';
Bool3x2 : 'bool3x2';
Bool3x3 : 'bool3x3';
Bool3x4 : 'bool3x4';
Bool4x1 : 'bool4x1';
Bool4x2 : 'bool4x2';
Bool4x3 : 'bool4x3';
Bool4x4 : 'bool4x4';
Buffer : 'Buffer';
ByteAddressBuffer : 'ByteAddressBuffer';
Break : 'break';
Case : 'case';
CBuffer : 'cbuffer';
Centroid : 'centroid';
Class : 'class';
ColumnMajor : 'column_major';
Const : 'const';
ConsumeStructuredBuffer : 'ConsumeStructuredBuffer';
Continue : 'continue';
Default : 'default';
Discard : 'discard';
Do : 'do';
Double : 'double';
Double1 : 'double1';
Double2 : 'double2';
Double3 : 'double3';
Double4 : 'double4';
Double1x1 : 'double1x1';
Double1x2 : 'double1x2';
Double1x3 : 'double1x3';
Double1x4 : 'double1x4';
Double2x1 : 'double2x1';
Double2x2 : 'double2x2';
Double2x3 : 'double2x3';
Double2x4 : 'double2x4';
Double3x1 : 'double3x1';
Double3x2 : 'double3x2';
Double3x3 : 'double3x3';
Double3x4 : 'double3x4';
Double4x1 : 'double4x1';
Double4x2 : 'double4x2';
Double4x3 : 'double4x3';
Double4x4 : 'double4x4';
Else : 'else';
Extern : 'extern';
Float : 'float';
Float1 : 'float1';
Float2 : 'float2';
Float3 : 'float3';
Float4 : 'float4';
Float1x1 : 'float1x1';
Float1x2 : 'float1x2';
Float1x3 : 'float1x3';
Float1x4 : 'float1x4';
Float2x1 : 'float2x1';
Float2x2 : 'float2x2';
Float2x3 : 'float2x3';
Float2x4 : 'float2x4';
Float3x1 : 'float3x1';
Float3x2 : 'float3x2';
Float3x3 : 'float3x3';
Float3x4 : 'float3x4';
Float4x1 : 'float4x1';
Float4x2 : 'float4x2';
Float4x3 : 'float4x3';
Float4x4 : 'float4x4';
For : 'for';
Groupshared : 'groupshared';
Half : 'half';
Half1 : 'half1';
Half2 : 'half2';
Half3 : 'half3';
Half4 : 'half4';
Half1x1 : 'half1x1';
Half1x2 : 'half1x2';
Half1x3 : 'half1x3';
Half1x4 : 'half1x4';
Half2x1 : 'half2x1';
Half2x2 : 'half2x2';
Half2x3 : 'half2x3';
Half2x4 : 'half2x4';
Half3x1 : 'half3x1';
Half3x2 : 'half3x2';
Half3x3 : 'half3x3';
Half3x4 : 'half3x4';
Half4x1 : 'half4x1';
Half4x2 : 'half4x2';
Half4x3 : 'half4x3';
Half4x4 : 'half4x4';
If : 'if';
In : 'in';
Inout : 'inout' | 'in out';
InputPatch : 'InputPatch';
Int : 'int';
Int1 : 'int1';
Int2 : 'int2';
Int3 : 'int3';
Int4 : 'int4';
Int1x1 : 'int1x1';
Int1x2 : 'int1x2';
Int1x3 : 'int1x3';
Int1x4 : 'int1x4';
Int2x1 : 'int2x1';
Int2x2 : 'int2x2';
Int2x3 : 'int2x3';
Int2x4 : 'int2x4';
Int3x1 : 'int3x1';
Int3x2 : 'int3x2';
Int3x3 : 'int3x3';
Int3x4 : 'int3x4';
Int4x1 : 'int4x1';
Int4x2 : 'int4x2';
Int4x3 : 'int4x3';
Int4x4 : 'int4x4';
Interface : 'interface';
Line_ : 'line';
LineAdj : 'lineadj';
Linear : 'linear';
LineStream : 'LineStream';
Long : 'long';
Matrix : 'matrix';
Nointerpolation : 'nointerpolation';
Noperspective : 'noperspective';
Out : 'out';
OutputPatch : 'OutputPatch';
Packoffset : 'packoffset';
Point : 'point';
PointStream : 'PointStream';
Precise : 'precise';
Register : 'register';
Return : 'return';
RowMajor : 'row_major';
RWBuffer : 'RWBuffer';
RWByteAddressBuffer : 'RWByteAddressBuffer';
RWStructuredBuffer : 'RWStructuredBuffer';
Sample : 'sample';
Sampler : 'sampler';
SamplerComparisonState : 'SamplerComparisonState';
SamplerState : 'SamplerState';
Shared : 'shared';
Static : 'static';
Struct : 'struct';
StructuredBuffer : 'StructuredBuffer';
Switch : 'switch';
Texture1D : 'Texture1D';
Texture1DArray : 'Texture1DArray';
Texture2D : 'Texture2D';
Texture2DArray : 'Texture2DArray';
Texture2DMS : 'Texture2DMS';
Texture2DMSArray : 'Texture2DMSArray';
Texture3D : 'Texture3D';
TextureCube : 'TextureCube';
TextureCubeArray : 'TextureCubeArray';
Triangle : 'triangle';
TriangleAdj : 'triangleadj';
TriangleStream : 'TriangleStream';
Uniform : 'uniform';
Uint : 'uint' | 'unsigned int' | 'dword';
Uint1 : 'uint1';
Uint2 : 'uint2';
Uint3 : 'uint3';
Uint4 : 'uint4';
Uint1x1 : 'uint1x1';
Uint1x2 : 'uint1x2';
Uint1x3 : 'uint1x3';
Uint1x4 : 'uint1x4';
Uint2x1 : 'uint2x1';
Uint2x2 : 'uint2x2';
Uint2x3 : 'uint2x3';
Uint2x4 : 'uint2x4';
Uint3x1 : 'uint3x1';
Uint3x2 : 'uint3x2';
Uint3x3 : 'uint3x3';
Uint3x4 : 'uint3x4';
Uint4x1 : 'uint4x1';
Uint4x2 : 'uint4x2';
Uint4x3 : 'uint4x3';
Uint4x4 : 'uint4x4';
Vector : 'vector';
Volatile : 'volatile';
Void : 'void';
While : 'while';

LeftParen : '(';
RightParen : ')';
LeftBracket : '[';
RightBracket : ']';
LeftBrace : '{';
RightBrace : '}';

Less : '<';
LessEqual : '<=';
Greater : '>';
GreaterEqual : '>=';
LeftShift : '<<';
RightShift : '>>';

Plus : '+';
PlusPlus : '++';
Minus : '-';
MinusMinus : '--';
Star : '*';
Div : '/';
Mod : '%';

And : '&';
Or : '|';
AndAnd : '&&';
OrOr : '||';
Caret : '^';
Not : '!';
Tilde : '~';

Question : '?';
Colon : ':';
ColonColon : '::';
Semi : ';';
Comma : ',';

Assign : '=';
// '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|='
StarAssign : '*=';
DivAssign : '/=';
ModAssign : '%=';
PlusAssign : '+=';
MinusAssign : '-=';
LeftShiftAssign : '<<=';
RightShiftAssign : '>>=';
AndAssign : '&=';
XorAssign : '^=';
OrAssign : '|=';

Equal : '==';
NotEqual : '!=';

Dot : '.';

True : 'true';
False : 'false';

Identifier
    :   Nondigit (Nondigit | Digit)*
    ;

fragment
Nondigit
    :   [a-zA-Z_]
    ;

fragment
Digit
    :   [0-9]
    ;

fragment
NonzeroDigit
    :   '0' | Digit
    ;

IntegerLiteral
    :   DecimalIntegerLiteral IntegerSuffix?
    |   HexadecimalIntegerLiteral IntegerSuffix?
    ;

fragment
DecimalIntegerLiteral
	:   Digit+
    ;

fragment
HexadecimalIntegerLiteral
    :   ('0x' | '0X') HexadecimalDigit+
    ;

fragment
HexadecimalDigit
    :   [0-9a-fA-F]
    ;

fragment
IntegerSuffix
    :   [uUlL]
    ;

FloatLiteral
    :   FractionalConstant ExponentPart? FloatingSuffix?
    |   DigitSequence ExponentPart FloatingSuffix?
    ;

fragment
FractionalConstant
    :   DigitSequence? '.' DigitSequence
    |   DigitSequence '.'
    ;

fragment
ExponentPart
    :   'e' Sign? DigitSequence
    |   'E' Sign? DigitSequence
    ;

fragment
Sign
    :   '+' | '-'
    ;

fragment
DigitSequence
    :   Digit+
    ;

fragment
HexadecimalDigitSequence
    :   HexadecimalDigit+
    ;

fragment
FloatingSuffix
    :   [flFL]
    ;

fragment
EscapeSequence
    :   SimpleEscapeSequence
    ;

fragment
SimpleEscapeSequence
    :   '\\' ['"?abfnrtv\\]
    ;

StringLiteral
    :   '"' SCharSequence? '"'
    ;

fragment
SCharSequence
    :   SChar+
    ;

fragment
SChar
    :   ~["\\\r\n]
    |   EscapeSequence
    ;

LineDirective
    :   '#line' Whitespace? DecimalIntegerLiteral Whitespace? StringLiteral ~[\r\n]*
	    {
			var regex = new System.Text.RegularExpressions.Regex("#line\\s(\\d+)\\s");
			Line = System.Convert.ToInt32(regex.Match(Text).Groups[1].Value) - 1;
		}
        -> skip
    ;

PragmaDirective
    :   '#' Whitespace? 'pragma' Whitespace ~[\r\n]*
        -> skip
    ;

Whitespace
    :   [ \t]+
    ;

Newline
    :   (   '\r' '\n'?
        |   '\n'
        )
    ;

PreprocessorDirective
	:   '#' Whitespace? PreprocessorDirectiveName
	;

fragment
PreprocessorDirectiveName
	:   'define'
	|   'elif'
	|   'else'
	|   'endif'
	|   'error'
	|   'if'
	|   'ifdef'
	|   'ifndef'
	|   'include'
	|   'line'
	|   'pragma'
	|   'undef'
    ;

StartBlockComment
    :   '/*' -> more, mode(BlockCommentMode)
    ;

LineComment
    :   '//' ~[\r\n]*
    ;

// --------------------------------------
// MODES
// --------------------------------------

mode BlockCommentMode;

	//BlockCommentNewline : Newline -> type(Newline);
	BlockCommentContent : . -> more;
	BlockCommentEndOfFile : EOF;
	BlockComment : '*/' -> mode(DEFAULT_MODE);