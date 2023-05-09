using EC.Console.Client.Calculator.Services.Processors.Multiplications.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Multiplications.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Multiplications
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
                throw new MultiplicationRequiresAtLeastTwoArgumentsException();
            try
            {
                return new MultiplicationRequestDto(arguments.Select(int.Parse));
            }
            catch (Exception ex)
            {
                throw new MultiplicationRequiresIntegerArgumentsException(ex);
            }
        }
    }
}
