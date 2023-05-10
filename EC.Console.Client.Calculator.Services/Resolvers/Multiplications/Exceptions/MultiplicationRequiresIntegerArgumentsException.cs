using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Multiplications.Exceptions
{
    [Serializable]
    public class MultiplicationRequiresIntegerArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 7;
        private const string _defaultErrorMessage = "All arguments for multiplication operation must be integer.";
        public MultiplicationRequiresIntegerArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public MultiplicationRequiresIntegerArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public MultiplicationRequiresIntegerArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public MultiplicationRequiresIntegerArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected MultiplicationRequiresIntegerArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}