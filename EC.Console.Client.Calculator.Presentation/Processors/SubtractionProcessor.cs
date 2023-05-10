using EC.Console.Client.Calculator.Services.Processors.Subtractions;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class SubtractionProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<SubtractionResponse> _calculator;

        public SubtractionProcessor(IOperationResolver<SubtractionResponse> calculator)
        {
            _calculator = calculator;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _calculator.Calculate(arguments, trackingId);

            System.Console.WriteLine(result.Difference);
        }
    }
}
