using AutoMapper;
using EC.Console.Client.Calculator.Services.Processors.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Additions.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Additions
{
    public class AdditionResolver : IOperationResolver<AdditionResponse>
    {
        private readonly ICalculatorApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public AdditionResolver(ICalculatorApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<AdditionResponse> Calculate(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetAdditionRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<AdditionRequestDto, AdditionResponseDto>("calculator/add", requestDto, trackingId);

            var response = _mapper.Map<AdditionResponse>(responseDto);

            return response;
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
