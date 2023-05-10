namespace EC.Console.Client.Calculator.Presentation.Processors.Factory
{
    public interface IOperationProcessorFactory
    {
        IOperationProcessor Build(string operation);
    }
}
