using EC.Console.Client.Calculator.Services.Api.Dtos;
using EC.Console.Client.Calculator.Services.Api.Exceptions;
using System.Text;
using System.Text.Json;

namespace EC.Console.Client.Calculator.Services.Resolvers
{
    public class ApiManager : IApiManager
    {
        private readonly HttpClient _httpClient;

        public ApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<U> PostAsync<T, U>(string endpoint, T body, string? trackingId)
        {
            try
            {
                SetUpHttpClient(trackingId);

                var json = JsonSerializer.Serialize(body);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                return await ManagePostRequest<U>(endpoint, stringContent);
            }
            catch (HttpRequestException ex)
            {
                throw new ApiConnectionException(ex);
            }
        }

        private async Task<U> ManagePostRequest<U>(string endpoint, StringContent stringContent)
        {
            var response = await _httpClient.PostAsync(endpoint, stringContent);

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

            var deserializedErrorContent = JsonSerializer.Deserialize<ApplicationErrorBodyDto>(errorResponseContent) 
                ?? throw new ApiResponseErrorException(new ApplicationErrorBodyDto("Unknown", (int)response.StatusCode, errorResponseContent));

            throw new ApiResponseErrorException(deserializedErrorContent);

            
        }

        private void SetUpHttpClient(string? trackingId)
        {
            if (trackingId != null)
                _httpClient.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);
        }
    }
}
