using System.Runtime.Serialization;

namespace EC.Console.Client.Calculator.Services.Exceptions
{
    [Serializable]
    public class ApplicationNumberedErrorException : Exception
    {
        public int ErrorNumber { get; set; }

        public ApplicationNumberedErrorException(int errorNumber)
        {
            ErrorNumber = errorNumber;
        }

        public ApplicationNumberedErrorException(int errorNumber, string? message) : base(message)
        {
            ErrorNumber = errorNumber;
        }

        public ApplicationNumberedErrorException(int errorNumber, string? message, Exception? innerException) : base(message, innerException)
        {
            ErrorNumber = errorNumber;
        }

        protected ApplicationNumberedErrorException(int errorNumber, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ErrorNumber = errorNumber;
        }

        public string ConsoleErrorMessage => $"ERROR CCC{ErrorNumber:000}: {Message}";
    }
}