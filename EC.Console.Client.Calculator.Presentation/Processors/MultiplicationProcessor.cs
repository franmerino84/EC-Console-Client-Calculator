using EC.Console.Client.Calculator.Services.Processors.Multiplications;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class MultiplicationProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<MultiplicationResponse> _calculator;

        public MultiplicationProcessor(IOperationResolver<MultiplicationResponse> calculator)
        {
            _calculator = calculator;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _calculator.Calculate(arguments, trackingId);

            System.Console.WriteLine(result.Product);
        }
    }
}
