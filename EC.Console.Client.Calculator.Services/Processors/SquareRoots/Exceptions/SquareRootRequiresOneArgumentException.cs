using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.SquareRoots.Exceptions
{
    [Serializable]
    public class SquareRootRequiresOneArgumentException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 8;
        private const string _defaultErrorMessage = "Square root requires exactly 1 argument.";
        public SquareRootRequiresOneArgumentException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public SquareRootRequiresOneArgumentException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public SquareRootRequiresOneArgumentException(string? message) : base(_errorNumber, message)
        {
        }

        public SquareRootRequiresOneArgumentException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected SquareRootRequiresOneArgumentException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}