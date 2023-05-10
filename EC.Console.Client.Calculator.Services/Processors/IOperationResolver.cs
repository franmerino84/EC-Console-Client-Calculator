public interface IOperationResolver<T>
{
    Task<T> Calculate(IEnumerable<string> arguments, string? trackingId = null);
}