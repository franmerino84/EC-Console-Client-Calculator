namespace EC.Console.Client.Calculator.Presentation.Client
{
    public interface ICalculatorClient
    {
        Task Process(CalculatorClientConsoleArguments consoleArguments, CalculatorSettings applicationConfig);
    }
}
