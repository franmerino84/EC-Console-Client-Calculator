namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public interface ICalculatorApiManager
    {
        Task<U> PostAsync<T, U>(string endpoint, T body, string? trackingId = null);
    }
}