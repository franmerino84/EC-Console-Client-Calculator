using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Exceptions
{
    [Serializable]
    public class SubtractionRequiresIntegerArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 11;
        private const string _defaultErrorMessage = "All arguments for subtraction operation must be integer.";
        public SubtractionRequiresIntegerArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public SubtractionRequiresIntegerArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }


        public SubtractionRequiresIntegerArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public SubtractionRequiresIntegerArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected SubtractionRequiresIntegerArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}