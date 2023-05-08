using EC.Console.Client.Calculator.Services.Api;
using System.Runtime.Serialization;
using EC.Console.Client.Calculator.Services.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors
{
    [Serializable]
    public class ApiResponseError : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 15;
        private static string DefaultErrorMessage(ApplicationErrorBody applicationErrorBody) => $"ERROR CCC015: There were problems during the request to the api: " +
            $"({applicationErrorBody.HttpStatusCode}) ({applicationErrorBody.ErrorCode}) {applicationErrorBody.Message}";
        public ApplicationErrorBody ApplicationErrorBody { get; set; }

        public ApiResponseError(ApplicationErrorBody applicationErrorBody) : base(_errorNumber, DefaultErrorMessage(applicationErrorBody))
        {
            ApplicationErrorBody = applicationErrorBody;
        }

        public ApiResponseError(ApplicationErrorBody applicationErrorBody, string? message) : base(_errorNumber, message)
        {
            ApplicationErrorBody = applicationErrorBody;
        }

        public ApiResponseError(ApplicationErrorBody applicationErrorBody, string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
            ApplicationErrorBody = applicationErrorBody;
        }

        protected ApiResponseError(ApplicationErrorBody applicationErrorBody, SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
            ApplicationErrorBody = applicationErrorBody;
        }
    }
}