using System.Text;
using System.Text.Json;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class CalculatorApiManager : ICalculatorApiManager
    {
        private readonly string _apiAddress;

        public CalculatorApiManager(string apiAddress)
        {
            _apiAddress = apiAddress;
        }

        public async Task<U> PostAsync<T, U>(string endpoint, T body, string? trackingId)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_apiAddress)
            };

            var json = JsonSerializer.Serialize(body);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            if (trackingId != null)
                httpClient.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);

            var response = await httpClient.PostAsync(endpoint, stringContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<U>(responseContent);
        }
    }
}
