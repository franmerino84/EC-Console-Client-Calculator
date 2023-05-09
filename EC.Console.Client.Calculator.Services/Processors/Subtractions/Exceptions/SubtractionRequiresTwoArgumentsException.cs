using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Subtractions.Exceptions
{
    [Serializable]
    public class SubtractionRequiresTwoArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 10;
        private const string _defaultErrorMessage = "Subtraction requires exactly 2 arguments.";
        public SubtractionRequiresTwoArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public SubtractionRequiresTwoArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public SubtractionRequiresTwoArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public SubtractionRequiresTwoArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected SubtractionRequiresTwoArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}