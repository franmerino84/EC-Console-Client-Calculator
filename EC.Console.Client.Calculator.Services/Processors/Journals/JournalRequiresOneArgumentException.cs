using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Journals
{
    [Serializable]
    public class JournalRequiresOneArgumentException : ApplicationNumberedErrorException
    {
        private const int _errorNumber = 16;
        private const string _defaultErrorMessage = "Journal requires exactly 1 argument.";
        public JournalRequiresOneArgumentException() : base(_errorNumber, _defaultErrorMessage)
        {
        }

        public JournalRequiresOneArgumentException(Exception? innerException) : base(_errorNumber, _defaultErrorMessage, innerException) { }

        public JournalRequiresOneArgumentException(string? message) : base(_errorNumber, message)
        {
        }

        public JournalRequiresOneArgumentException(string? message, Exception? innerException) : base(_errorNumber, message, innerException)
        {
        }

        protected JournalRequiresOneArgumentException(SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
        {
        }
    }
}