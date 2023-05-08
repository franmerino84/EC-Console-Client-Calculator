using EC.Console.Client.Calculator.Services.Api;
using System.Text;
using System.Text.Json;

namespace EC.Console.Client.Calculator.Services.Processors
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
            try
            {
                var httpClient = GetHttpClient(trackingId);

                var json = JsonSerializer.Serialize(body);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                return await ManageRequest<U>(httpClient, endpoint, stringContent);
            }
            catch (HttpRequestException ex)
            {
                throw new ApiConnectionException(ex);
            }
        }

        private static async Task<U> ManageRequest<U>(HttpClient httpClient, string endpoint, StringContent stringContent)
        {
            var response = await httpClient.PostAsync(endpoint, stringContent);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                await ManageResponseErrors(response);

            return await GetResponseContent<U>(response);
        }

        private static async Task<U> GetResponseContent<U>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            var deserializedContent = JsonSerializer.Deserialize<U>(responseContent);

            return deserializedContent == null ? throw new NotExpectedResponseException(responseContent) : deserializedContent;
        }

        private static async Task ManageResponseErrors(HttpResponseMessage response)
        {
            var errorResponseContent = await response.Content.ReadAsStringAsync();

            var deserializedErrorContent = JsonSerializer.Deserialize<ApplicationErrorBody>(errorResponseContent);

            throw new ApiResponseError(deserializedErrorContent);
        }

        private HttpClient GetHttpClient(string? trackingId)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_apiAddress)
            };

            if (trackingId != null)
                httpClient.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);
            return httpClient;
        }
    }
}
