using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Divisions
{
    [Serializable]
    public class DivisionRequiresTwoArgumentsException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 4;
        private const string _defaultErrorMessage = "Division requires exactly 2 arguments.";
        public DivisionRequiresTwoArgumentsException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public DivisionRequiresTwoArgumentsException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public DivisionRequiresTwoArgumentsException(string? message) : base(_errorNumber, message)
        {
        }

        public DivisionRequiresTwoArgumentsException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected DivisionRequiresTwoArgumentsException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}