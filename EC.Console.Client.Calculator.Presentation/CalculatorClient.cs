using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Presentation.Processors.Additions;
using EC.Console.Client.Calculator.Presentation.Processors.Divisions;
using EC.Console.Client.Calculator.Presentation.Processors.Journals;
using EC.Console.Client.Calculator.Presentation.Processors.Multiplications;
using EC.Console.Client.Calculator.Presentation.Processors.SquareRoots;
using EC.Console.Client.Calculator.Presentation.Processors.Subtractions;

internal class CalculatorClient
{
    internal async Task Process(CalculatorClientConsoleArguments consoleArguments)
    {
        var processor = GetOperationProcessor(consoleArguments.Operation);

        await processor.Process(consoleArguments.Arguments, consoleArguments.TrackingId);
    }

    private IOperationProcessor GetOperationProcessor(string operation)
    {
        var calculatorApiManager = new CalculatorApiManager("https://localhost:7050");

        switch (operation.ToLower())
        {
            case "sum":
                return new AdditionProcessor(calculatorApiManager);
            case "div":
                return new DivisionProcessor(calculatorApiManager);
            case "mul":
                return new MultiplicationProcessor(calculatorApiManager);
            case "sqr":
                return new SquareRootProcessor(calculatorApiManager);
            case "sub":
                return new SubtractionProcessor(calculatorApiManager);
            case "journal":
                return new JournalProcessor(calculatorApiManager);
            default:
                throw new NotImplementedException();
        }
    }
}