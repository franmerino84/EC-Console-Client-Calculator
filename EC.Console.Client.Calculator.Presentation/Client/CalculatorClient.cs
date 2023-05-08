using EC.Console.Client.Calculator.Presentation;
using EC.Console.Client.Calculator.Presentation.Client;
using EC.Console.Client.Calculator.Presentation.Processors;

public class CalculatorClient : ICalculatorClient
{
    private readonly IOperationProcessorFactory _operationProcessorFactory;

    public CalculatorClient(IOperationProcessorFactory operationProcessorFactory)
    {
        _operationProcessorFactory = operationProcessorFactory;
    }

    public async Task Process(CalculatorClientConsoleArguments consoleArguments, CalculatorSettings applicationConfig)
    {
        var processor = _operationProcessorFactory.Build(consoleArguments.Operation);

        await processor.Process(consoleArguments.Arguments, consoleArguments.TrackingId);
    }
}