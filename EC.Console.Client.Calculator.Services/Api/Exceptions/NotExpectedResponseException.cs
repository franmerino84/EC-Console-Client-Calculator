using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Api.Exceptions
{
    [Serializable]
    public class NotExpectedResponseException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 15;
        public NotExpectedResponseException() : base(_errorNumber)
        {
        }

        public NotExpectedResponseException(string? message) : base(_errorNumber, message)
        {
        }

        public NotExpectedResponseException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected NotExpectedResponseException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}