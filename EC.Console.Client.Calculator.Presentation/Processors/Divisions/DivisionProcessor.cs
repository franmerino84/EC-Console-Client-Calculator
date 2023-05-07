namespace EC.Console.Client.Calculator.Presentation.Processors.Divisions
{
    public class DivisionProcessor : IOperationProcessor
    {
        private readonly ICalculatorApiManager _calculatorApiManager;

        public DivisionProcessor(ICalculatorApiManager calculatorApiManager)
        {
            _calculatorApiManager = calculatorApiManager;
        }
        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetDivisionRequestDto(arguments.ToArray());

            var responseDto = await _calculatorApiManager.PostAsync<DivisionRequestDto, DivisionResponseDto>("calculator/div", requestDto, trackingId);

            System.Console.WriteLine($"Quotient: {responseDto.Quotient}. Remainder: {responseDto.Remainder}");
        }

        private DivisionRequestDto GetDivisionRequestDto(IList<string> arguments)
        {
            if (arguments.Count != 2)
                return ErrorManager.LaunchError<DivisionRequestDto>(4, "Division requires exactly 2 arguments.");
            try
            {
                return new DivisionRequestDto(int.Parse(arguments[0]), int.Parse(arguments[1]));
            }
            catch (Exception)
            {
                return ErrorManager.LaunchError<DivisionRequestDto>(5, "All arguments for division operation must be integer.");
            }
        }
    }
}
