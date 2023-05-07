
using CommandLine;

var result = Parser.Default.ParseArguments<CalculatorClientConsoleArguments>(args);

Validate(result);

await Launch(result.Value);

static void Validate(ParserResult<CalculatorClientConsoleArguments> result)
{
    if (result.Tag == ParserResultType.NotParsed)
    {
        Console.Error.WriteLine("ERROR CCC001: Wrong application usage. Run 'dotnet EC.Console.Client.Calculator.Presentation.dll --help for more information.");
        Environment.Exit(-1);
    }
}

static async Task Launch(CalculatorClientConsoleArguments consoleArguments)
{
    try
    {
        var client = new CalculatorClient();

        await client.Process(consoleArguments);

        Environment.Exit(0);
    }
    catch { }
}
