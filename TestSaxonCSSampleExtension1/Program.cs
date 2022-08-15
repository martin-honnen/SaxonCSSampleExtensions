using Saxon.Api;
using SaxonCSSampleExtensions;

Processor processor = new();
processor.RegisterExtensionFunction(new Sqrt());

var compiler = processor.NewXPathCompiler();
compiler.DeclareNamespace("ex", "http://example.com/math");

Console.WriteLine(compiler.EvaluateSingle("ex:sqrt(4)", null));
