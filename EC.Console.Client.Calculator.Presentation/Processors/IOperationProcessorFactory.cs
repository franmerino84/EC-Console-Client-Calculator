namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public interface IOperationProcessorFactory
    {
        IOperationProcessor Build(string operation);
    }
}
