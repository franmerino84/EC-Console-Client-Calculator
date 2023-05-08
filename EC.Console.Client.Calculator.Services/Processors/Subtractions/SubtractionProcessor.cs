using EC.Console.Client.Calculator.Services.Processors;

namespace EC.Console.Client.Calculator.Services.Processors.Subtractions
{
    public class SubtractionProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public SubtractionProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetSutbractionRequestDto(arguments.ToArray());

            var responseDto = await _calculatorApiManager.PostAsync<SubtractionRequestDto, SubtractionResponseDto>("calculator/sub", requestDto, trackingId);

            System.Console.WriteLine(responseDto.Difference);
        }

        private static SubtractionRequestDto GetSutbractionRequestDto(IList<string> arguments)
        {
            if (arguments.Count != 2)
                throw new SubtractionRequiresTwoArgumentsException();
            try
            {
                return new SubtractionRequestDto(int.Parse(arguments[0]), int.Parse(arguments[1]));
            }
            catch (Exception ex)
            {
                throw new SubtractionRequiresIntegerArgumentsException(ex);
            }
        }
    }
}
