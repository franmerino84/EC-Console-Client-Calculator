using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Additions
{
    [Serializable]
    public class AdditionRequiresAtLeastTwoArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 2;
        private const string _defaultErrorMessage = "Addition requires at least 2 arguments.";
        public AdditionRequiresAtLeastTwoArgumentsException(): base(_errorNumber, _defaultErrorMessage)
        {
        }

        public AdditionRequiresAtLeastTwoArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public AdditionRequiresAtLeastTwoArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public AdditionRequiresAtLeastTwoArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected AdditionRequiresAtLeastTwoArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}