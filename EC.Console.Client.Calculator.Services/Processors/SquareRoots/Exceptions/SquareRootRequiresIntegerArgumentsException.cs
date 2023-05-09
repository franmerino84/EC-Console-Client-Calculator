using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.SquareRoots.Exceptions
{
    [Serializable]
    public class SquareRootRequiresIntegerArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 9;
        private const string _defaultErrorMessage = "The argument for square root operation must be integer.";
        public SquareRootRequiresIntegerArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public SquareRootRequiresIntegerArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public SquareRootRequiresIntegerArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public SquareRootRequiresIntegerArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected SquareRootRequiresIntegerArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}