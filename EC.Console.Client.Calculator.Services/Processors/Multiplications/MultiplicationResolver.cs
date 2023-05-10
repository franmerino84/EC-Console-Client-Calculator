using AutoMapper;
using EC.Console.Client.Calculator.Services.Processors.Multiplications.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Multiplications.Exceptions;

namespace EC.Console.Client.Calculator.Services.Processors.Multiplications
{
    public class MultiplicationResolver : IOperationResolver<MultiplicationResponse>
    {
        private readonly ICalculatorApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public MultiplicationResolver(ICalculatorApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<MultiplicationResponse> Calculate(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetMultiplicationRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<MultiplicationRequestDto, MultiplicationResponse>("calculator/mult", requestDto, trackingId);

            var response = _mapper.Map<MultiplicationResponse>(responseDto);

            return response;
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
