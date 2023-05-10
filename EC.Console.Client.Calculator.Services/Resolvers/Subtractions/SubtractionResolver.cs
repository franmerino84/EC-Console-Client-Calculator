using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Exceptions;

namespace EC.Console.Client.Calculator.Services.Resolvers.Subtractions
{
    public class SubtractionResolver : IOperationResolver<SubtractionResponse>
    {
        private readonly IApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public SubtractionResolver(IApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<SubtractionResponse> Resolve(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetSutbractionRequestDto(arguments.ToArray());

            var responseDto = await _calculatorApiManager.PostAsync<SubtractionRequestDto, SubtractionResponseDto>("calculator/sub", requestDto, trackingId);

            var response = _mapper.Map<SubtractionResponse>(responseDto);

            return response;
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
