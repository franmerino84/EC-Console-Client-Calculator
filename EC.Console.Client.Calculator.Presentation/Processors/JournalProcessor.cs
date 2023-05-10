using EC.Console.Client.Calculator.Services.Processors.Journals;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class JournalProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<JournalResponse> _calculator;

        public JournalProcessor(IOperationResolver<JournalResponse> calculator)
        {
            _calculator = calculator;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _calculator.Calculate(arguments, trackingId);

            foreach (var operation in result.Operations)
            {
                System.Console.WriteLine($"{operation.Date} ({operation.Operation}): {operation.Calculation}");
            }
        }
    }
}
