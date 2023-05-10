using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Additions.Exceptions
{
    [Serializable]
    public class AdditionRequiresIntegerArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 3;
        private const string _defaultErrorMessage = "All arguments for addition operation must be integer.";
        public AdditionRequiresIntegerArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public AdditionRequiresIntegerArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public AdditionRequiresIntegerArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public AdditionRequiresIntegerArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected AdditionRequiresIntegerArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}