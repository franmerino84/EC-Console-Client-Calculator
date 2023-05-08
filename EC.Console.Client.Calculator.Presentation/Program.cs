using CommandLine;
using EC.Console.Client.Calculator.Presentation.Client;
using EC.Console.Client.Calculator.Presentation.Configuration;
using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Presentation.Validation;
using EC.Console.Client.Calculator.Services.Exceptions;
using EC.Console.Client.Calculator.Services.Processors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var result = Parser.Default.ParseArguments<CalculatorClientConsoleArguments>(args);

var settings = GetSettings();

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
        var serviceProvider = BuildServiceProvider(settings);

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

static ServiceProvider BuildServiceProvider(CalculatorSettings settings)
{
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddSingleton<IOperationProcessorFactory, OperationProcessorFactory>();
    serviceCollection.AddSingleton<ICalculatorApiManager, CalculatorApiManager>(x => new CalculatorApiManager(settings.CalculatorApiUrl));
    serviceCollection.AddSingleton<ICalculatorClient, CalculatorClient>();

    return serviceCollection.BuildServiceProvider();
}

static CalculatorSettings GetSettings()
{
    var configuration = new ConfigurationBuilder()
         .AddJsonFile($"appsettings.json");

    var configurationRoot = configuration.Build();
    var settings = new CalculatorSettings();
    configurationRoot.GetSection("CalculatorSettings").Bind(settings);

    return settings;
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


