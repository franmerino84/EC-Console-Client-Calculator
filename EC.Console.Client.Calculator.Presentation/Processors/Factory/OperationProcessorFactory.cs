namespace EC.Console.Client.Calculator.Presentation.Processors.Factory
{
    public class OperationProcessorFactory : IOperationProcessorFactory
    {
        private readonly Dictionary<string, IOperationProcessor> _processors;

        public OperationProcessorFactory(AdditionProcessor addition, DivisionProcessor division, MultiplicationProcessor multiplication, SquareRootProcessor squareRoot,
            SubtractionProcessor subtraction, JournalProcessor journal)
        {
            _processors = new Dictionary<string, IOperationProcessor>
            {
                { "sum", addition },
                { "div", division },
                { "mul", multiplication },
                { "sqr", squareRoot },
                { "sub", subtraction },
                { "journal", journal }
            };
        }

        public IOperationProcessor Build(string operation)
        {
            var lowerCaseOperation = operation.ToLower();
            if (!_processors.ContainsKey(lowerCaseOperation))
                throw new OperationNotImplementedException(operation);

            return _processors[lowerCaseOperation];
        }
    }
}
