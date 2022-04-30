﻿using Eto.Parse;
using Eto.Parse.Grammars;
using Stride.Shader.Parser;
using System.Diagnostics;


var shaderf = File.ReadAllText("./SDSL/Expressions.sdsl");

// var parser = new SDSLGrammar();
var parser = StrideGrammar.New("expr");
var tokens = StrideGrammar.HlslGrammar("expression");
var sdslParser = new SDSLGrammar().UsingDirectiveExpression();
var s = new Stopwatch();
var match = sdslParser.Match("(8)");
s.Start();
match = sdslParser.Match(".5d");
s.Stop();

Console.WriteLine(match.ErrorMessage[..Math.Min(1000,match.ErrorMessage.Length)]);
match.Matches.ForEach(x => Console.WriteLine(x.Name + " : " + x.Value));
Console.WriteLine($"parsing time : {s.Elapsed}");
Console.Write("");


