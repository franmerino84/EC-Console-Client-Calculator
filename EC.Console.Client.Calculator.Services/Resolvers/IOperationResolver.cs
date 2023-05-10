public interface IOperationResolver<T>
{
    Task<T> Resolve(IEnumerable<string> arguments, string? trackingId = null);
}