using EC.Console.Client.Calculator.Services.Processors.SquareRoots;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class SquareRootProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<SquareRootResponse> _calculator;

        public SquareRootProcessor(IOperationResolver<SquareRootResponse> calculator)
        {
            _calculator = calculator;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _calculator.Calculate(arguments, trackingId);

            System.Console.WriteLine(result.Square);
        }
    }
}
