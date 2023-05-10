using AutoMapper;
using EC.Console.Client.Calculator.Services.Processors.Divisions.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Divisions.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Divisions
{
    public class DivisionResolver : IOperationResolver<DivisionResponse>
    {
        private readonly ICalculatorApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public DivisionResolver(ICalculatorApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<DivisionResponse> Calculate(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetDivisionRequestDto(arguments.ToArray());

            var responseDto = await _calculatorApiManager.PostAsync<DivisionRequestDto, DivisionResponse>("calculator/div", requestDto, trackingId);

            var response = _mapper.Map<DivisionResponse>(responseDto);

            return response;
        }

        private static DivisionRequestDto GetDivisionRequestDto(IList<string> arguments)
        {
            if (arguments.Count != 2)
                throw new DivisionRequiresTwoArgumentsException();

            try
            {
                return new DivisionRequestDto(int.Parse(arguments[0]), int.Parse(arguments[1]));
            }
            catch (Exception ex) 
            {
                throw new DivisionRequiresIntegerArgumentsException(ex);
            }
        }
    }
}
