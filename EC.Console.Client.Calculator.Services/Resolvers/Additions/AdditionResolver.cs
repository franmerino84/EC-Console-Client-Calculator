using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Exceptions;

namespace EC.Console.Client.Calculator.Services.Resolvers.Additions
{
    public class AdditionResolver : IOperationResolver<AdditionResponse>
    {
        private readonly IApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public AdditionResolver(IApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<AdditionResponse> Resolve(IEnumerable<string> arguments, string? trackingId)
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
                return new AdditionRequestDto(arguments.Select(int.Parse).ToArray());
            }
            catch (Exception ex)
            {
                throw new AdditionRequiresIntegerArgumentsException(ex);
            }
        }
    }
}
