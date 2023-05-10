using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions;
using EC.Console.Client.Calculator.Services.Resolvers.Journals.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Journals.Exceptions;

namespace EC.Console.Client.Calculator.Services.Resolvers.Journals
{
    public class JournalResolver : IOperationResolver<JournalResponse>
    {
        private readonly IApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public JournalResolver(IApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<JournalResponse> Resolve(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetJournalRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<JournalRequestDto, JournalResponseDto>("journal/query", requestDto);

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
