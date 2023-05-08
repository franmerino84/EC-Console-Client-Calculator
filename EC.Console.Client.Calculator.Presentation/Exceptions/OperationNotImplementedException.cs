using EC.Console.Client.Calculator.Services.Exceptions;
using System.Runtime.Serialization;

[Serializable]
public class OperationNotImplementedException : ApplicationNumberedErrorException
{

    private const int _errorNumber = 13;
    private static string DefaultErrorMessage(string operation) => $"The operation {operation} is not supported.";

    public OperationNotImplementedException(string operation) : base(_errorNumber, DefaultErrorMessage(operation))
    {
        Operation = operation;
    }

    public OperationNotImplementedException(string operation, Exception? innerException) : base(_errorNumber, DefaultErrorMessage(operation), innerException)
    {
        Operation = operation;
    }

    public OperationNotImplementedException(string operation, string? message) : base(_errorNumber, message)
    {
        Operation = operation;
    }

    public OperationNotImplementedException(string operation, string? message, Exception? innerException) : base(_errorNumber, message, innerException)
    {
        Operation = operation;
    }

    protected OperationNotImplementedException(string operation, SerializationInfo info, StreamingContext context) : base(_errorNumber, info, context)
    {
        Operation = operation;
    }

    public string Operation { get; }
}