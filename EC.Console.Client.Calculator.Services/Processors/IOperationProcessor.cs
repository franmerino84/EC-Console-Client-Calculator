public interface IOperationProcessor
{
    Task Process(IEnumerable<string> arguments, string? trackingId = null);
}