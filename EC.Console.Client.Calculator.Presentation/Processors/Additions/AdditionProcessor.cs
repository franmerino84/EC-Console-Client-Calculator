using EC.Console.Client.Calculator.Presentation.Exceptions;

namespace EC.Console.Client.Calculator.Presentation.Processors.Additions
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
                throw new ApplicationNumberedErrorException(2, "Addition requires at least 2 arguments.");
            try
            {
                return new AdditionRequestDto(arguments.Select(int.Parse));
            }
            catch (Exception ex)
            {
                throw new ApplicationNumberedErrorException(3, "All arguments for addition operation must be integer.", ex);
            }
        }
    }
}
