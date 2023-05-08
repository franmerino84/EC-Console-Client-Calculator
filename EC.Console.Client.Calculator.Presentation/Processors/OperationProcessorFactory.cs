using EC.Console.Client.Calculator.Services.Processors;
using EC.Console.Client.Calculator.Services.Processors.Additions;
using EC.Console.Client.Calculator.Services.Processors.Divisions;
using EC.Console.Client.Calculator.Services.Processors.Journals;
using EC.Console.Client.Calculator.Services.Processors.Multiplications;
using EC.Console.Client.Calculator.Services.Processors.SquareRoots;
using EC.Console.Client.Calculator.Services.Processors.Subtractions;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class OperationProcessorFactory : IOperationProcessorFactory
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public OperationProcessorFactory(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }

        public IOperationProcessor Build(string operation)
        {
            return operation.ToLower() switch
            {
                "sum" => new AdditionProcessor(_calculatorApiManager),
                "div" => new DivisionProcessor(_calculatorApiManager),
                "mul" => new MultiplicationProcessor(_calculatorApiManager),
                "sqr" => new SquareRootProcessor(_calculatorApiManager),
                "sub" => new SubtractionProcessor(_calculatorApiManager),
                "journal" => new JournalProcessor(_calculatorApiManager),
                _ => throw new OperationNotImplementedException(operation),
            };
        }
    }
}
