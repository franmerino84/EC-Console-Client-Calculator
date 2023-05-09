using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Divisions.Exceptions
{
    [Serializable]
    public class DivisionRequiresIntegerArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 5;
        private const string _defaultErrorMessage = "All arguments for division operation must be integer.";
        public DivisionRequiresIntegerArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public DivisionRequiresIntegerArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }


        public DivisionRequiresIntegerArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public DivisionRequiresIntegerArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected DivisionRequiresIntegerArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}