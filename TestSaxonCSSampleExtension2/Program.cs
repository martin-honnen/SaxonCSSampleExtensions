using Saxon.Api;

Processor processor;

using (var fs = File.OpenRead("saxon-config-ext-sample.xml"))
{
    processor = new(fs, new Uri(Environment.CurrentDirectory));
}

var compiler = processor.NewXPathCompiler();
compiler.DeclareNamespace("ex", "http://example.com/math");

Console.WriteLine(compiler.EvaluateSingle("ex:sqrt(4)", null));