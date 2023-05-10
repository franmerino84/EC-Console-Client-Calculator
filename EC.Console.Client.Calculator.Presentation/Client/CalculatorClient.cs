using EC.Console.Client.Calculator.Presentation.Processors.Factory;

namespace EC.Console.Client.Calculator.Presentation.Client
{
    public class CalculatorClient : ICalculatorClient
    {
        private readonly IOperationProcessorFactory _operationProcessorFactory;

        public CalculatorClient(IOperationProcessorFactory operationProcessorFactory)
        {
            _operationProcessorFactory = operationProcessorFactory;
        }

        public async Task Process(CalculatorClientConsoleArguments consoleArguments)
        {
            var processor = _operationProcessorFactory.Build(consoleArguments.Operation);

            await processor.Process(consoleArguments.Arguments, consoleArguments.TrackingId);
        }
    }
}