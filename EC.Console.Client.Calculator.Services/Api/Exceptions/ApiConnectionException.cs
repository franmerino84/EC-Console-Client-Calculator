using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Api.Exceptions
{
    [Serializable]
    public class ApiConnectionException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 14;
        private static string DefaultErrorMessage(string suffix) => $"There were problems connecting to the api{suffix}";
        public ApiConnectionException() : base(_errorNumber, DefaultErrorMessage(string.Empty))
        {
        }

        public ApiConnectionException(Exception? innerException) : base(_errorNumber, DefaultErrorMessage($": {innerException}"))
        {
        }

        public ApiConnectionException(string? message) : base(_errorNumber, message)
        {
        }

        public ApiConnectionException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected ApiConnectionException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}