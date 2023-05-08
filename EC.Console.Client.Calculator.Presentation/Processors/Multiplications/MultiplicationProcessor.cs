using EC.Console.Client.Calculator.Presentation.Exceptions;

namespace EC.Console.Client.Calculator.Presentation.Processors.Multiplications
{
    public class MultiplicationProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public MultiplicationProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetMultiplicationRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<MultiplicationRequestDto, MultiplicationResponseDto>("calculator/mult", requestDto, trackingId);

            System.Console.WriteLine(responseDto.Product);
        }

        private static MultiplicationRequestDto GetMultiplicationRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() < 2)
                throw new ApplicationNumberedErrorException(6, "Multiplication requires at least 2 arguments.");
            try
            {
                return new MultiplicationRequestDto(arguments.Select(int.Parse));
            }
            catch (Exception ex)
            {
                throw new ApplicationNumberedErrorException(7, "All arguments for multiplication operation must be integer.", ex);
            }
        }
    }
}
