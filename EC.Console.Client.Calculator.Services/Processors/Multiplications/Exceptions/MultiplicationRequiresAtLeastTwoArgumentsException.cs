using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Multiplications.Exceptions
{
    [Serializable]
    public class MultiplicationRequiresAtLeastTwoArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 6;
        private const string _defaultErrorMessage = "Multiplication requires at least 2 arguments.";
        public MultiplicationRequiresAtLeastTwoArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public MultiplicationRequiresAtLeastTwoArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public MultiplicationRequiresAtLeastTwoArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public MultiplicationRequiresAtLeastTwoArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected MultiplicationRequiresAtLeastTwoArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}