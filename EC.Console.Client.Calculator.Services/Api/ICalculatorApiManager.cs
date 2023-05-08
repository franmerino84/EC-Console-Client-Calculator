namespace EC.Console.Client.Calculator.Services.Processors
{
    public interface ICalculatorApiManager
    {
        Task<U> PostAsync<T, U>(string endpoint, T body, string? trackingId = null);
    }
}