namespace EC.Console.Client.Calculator.Presentation.Processors.Subtractions
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

        private SubtractionRequestDto GetSutbractionRequestDto(IList<string> arguments)
        {
            if (arguments.Count != 2)
                return ErrorManager.LaunchError<SubtractionRequestDto>(10, "Subtraction requires exactly 2 arguments.");
            try
            {
                return new SubtractionRequestDto(int.Parse(arguments[0]), int.Parse(arguments[1]));
            }
            catch (Exception)
            {
                return ErrorManager.LaunchError<SubtractionRequestDto>(11, "All arguments for subtraction operation must be integer.");
            }
        }
    }
}
