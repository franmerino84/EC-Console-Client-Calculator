using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Api
{
    public class ApplicationErrorBody
    {
        public ApplicationErrorBody(string errorCode, int httpStatusCode, string message)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; }

        [JsonPropertyName("httpStatusCode")]
        public int HttpStatusCode { get; }

        [JsonPropertyName("message")]
        public string Message { get; }
    }
}
