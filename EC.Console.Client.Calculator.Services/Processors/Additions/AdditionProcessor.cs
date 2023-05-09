using EC.Console.Client.Calculator.Services.Processors.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Additions.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Additions
{
    public class AdditionProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public AdditionProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetAdditionRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<AdditionRequestDto, AdditionResponseDto>("calculator/add", requestDto, trackingId);

            System.Console.WriteLine(responseDto.Sum);
        }

        private static AdditionRequestDto GetAdditionRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() < 2)
                throw new AdditionRequiresAtLeastTwoArgumentsException();
            try
            {
                return new AdditionRequestDto(arguments.Select(int.Parse));
            }
            catch (Exception ex)
            {
                throw new AdditionRequiresIntegerArgumentsException(ex);
            }
        }
    }
}
