using EC.Console.Client.Calculator.Services.Processors.Additions.Dtos;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class AdditionProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<AdditionResponse> _calculator;

        public AdditionProcessor(IOperationResolver<AdditionResponse> calculator)
        {
            _calculator = calculator;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _calculator.Calculate(arguments, trackingId);

            System.Console.WriteLine(result.Sum);
        }
    }
}
