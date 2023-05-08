using EC.Console.Client.Calculator.Presentation.Exceptions;

namespace EC.Console.Client.Calculator.Presentation.Processors.SquareRoots
{
    public class SquareRootProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public SquareRootProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetSquareRootRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<SquareRootRequestDto, SquareRootResponseDto>("calculator/sqrt", requestDto, trackingId);

            System.Console.WriteLine(responseDto.Square);
        }

        private static SquareRootRequestDto GetSquareRootRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() != 1)
                throw new ApplicationNumberedErrorException(8, "Square root requires exactly 1 argument.");
            try
            {
                return new SquareRootRequestDto(int.Parse(arguments.First()));
            }
            catch (Exception ex)
            {
                throw new ApplicationNumberedErrorException(9, "The argument for square root operation must be integer.", ex);
            }
        }
    }
}
