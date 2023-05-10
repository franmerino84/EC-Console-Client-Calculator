using AutoMapper;
using EC.Console.Client.Calculator.Services.Processors.Divisions;
using EC.Console.Client.Calculator.Services.Processors.Journals.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Journals.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Journals
{
    public class JournalResolver : IOperationResolver<JournalResponse>
    {
        private readonly ICalculatorApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public JournalResolver(ICalculatorApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<JournalResponse> Calculate(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetJournalRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<JournalRequestDto, JournalResponse>("journal/query", requestDto);

            var response = _mapper.Map<JournalResponse>(responseDto);

            return response;
        }

        private static JournalRequestDto GetJournalRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() != 1)
                throw new JournalRequiresOneArgumentException();

            return new JournalRequestDto(arguments.First());
        }
    }
}
