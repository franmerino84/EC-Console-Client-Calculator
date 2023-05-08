using EC.Console.Client.Calculator.Presentation.Configuration;

namespace EC.Console.Client.Calculator.Presentation.Client
{
    public interface ICalculatorClient
    {
        Task Process(CalculatorClientConsoleArguments consoleArguments, CalculatorSettings applicationConfig);
    }
}
