namespace EC.Console.Client.Calculator.Services.Resolvers
{
    public interface IApiManager
    {
        Task<U> PostAsync<T, U>(string endpoint, T body, string? trackingId = null);
    }
}