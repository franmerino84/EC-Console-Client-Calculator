namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public interface IOperationProcessor
    {
        Task Process(IEnumerable<string> arguments, string? trackingId);
    }
}