using EC.Console.Client.Calculator.Services.Processors.Divisions;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class DivisionProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<DivisionResponse> _calculator;

        public DivisionProcessor(IOperationResolver<DivisionResponse> calculator)
        {
            _calculator = calculator;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _calculator.Calculate(arguments, trackingId);

            System.Console.WriteLine($"Quotient: {result.Quotient}. Remainder: {result.Remainder}");
        }
    }
}
