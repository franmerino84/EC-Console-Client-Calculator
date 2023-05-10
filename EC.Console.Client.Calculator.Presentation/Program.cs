using CommandLine;
using EC.Console.Client.Calculator.Presentation.Client;
using EC.Console.Client.Calculator.Presentation.Configuration;
using EC.Console.Client.Calculator.Presentation.Ioc;
using EC.Console.Client.Calculator.Presentation.Validation;
using EC.Console.Client.Calculator.Services.Exceptions;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

var result = Parser.Default.ParseArguments<CalculatorClientConsoleArguments>(args);

var settings = CalculatorSettingsRetriever.GetSettings();

ValidateArguments(result);

ValidateSettings(settings);

await Launch(result.Value, settings);

static void ValidateArguments(ParserResult<CalculatorClientConsoleArguments> result)
{
    if (result.Tag == ParserResultType.NotParsed)
    {
        Console.Error.WriteLine("ERROR CCC001: Wrong application usage. Run 'dotnet EC.Console.Client.Calculator.Presentation.dll --help for more information.");
        Environment.Exit(-1);
    }
}

static async Task Launch(CalculatorClientConsoleArguments consoleArguments, CalculatorSettings settings)
{
    try
    {
        var serviceProvider = ServiceProviderBuilder.Build(settings);

        var client = serviceProvider.GetService<ICalculatorClient>();

        await client.Process(consoleArguments, settings);

        Environment.Exit(0);
    }
    catch (ApplicationNumberedErrorException ex)
    {
        Console.Error.WriteLine(ex.ConsoleErrorMessage);
        Environment.Exit(0 - ex.ErrorNumber);
    }
    catch (Exception ex)
    {
        var writableException = new ApplicationNumberedErrorException(999, $"Unhandled exception: {ex}");
        Console.Error.WriteLine(writableException.ConsoleErrorMessage);
        Environment.Exit(-999);
    }
}

static void ValidateSettings(CalculatorSettings settings)
{
    var errors = settings.GetValidationErrorsMessages();

    if (errors.Any())
    {
        Console.Error.WriteLine("ERROR CCC012:");
        errors.ToList().ForEach(Console.Error.WriteLine);
        Environment.Exit(-12);
    }
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.
