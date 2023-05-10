using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Exceptions;

namespace EC.Console.Client.Calculator.Services.Resolvers.SquareRoots
{
    public class SquareRootResolver : IOperationResolver<SquareRootResponse>
    {
        private readonly IApiManager _calculatorApiManager;
        private readonly IMapper _mapper;

        public SquareRootResolver(IApiManager calculatorApiManager, IMapper mapper)
        {
            _calculatorApiManager = calculatorApiManager;
            _mapper = mapper;
        }
        public async Task<SquareRootResponse> Resolve(IEnumerable<string> arguments, string? trackingId)
        {
            var requestDto = GetSquareRootRequestDto(arguments);

            var responseDto = await _calculatorApiManager.PostAsync<SquareRootRequestDto, SquareRootResponseDto>("calculator/sqrt", requestDto, trackingId);

            var response = _mapper.Map<SquareRootResponse>(responseDto);

            return response;
        }

        private static SquareRootRequestDto GetSquareRootRequestDto(IEnumerable<string> arguments)
        {
            if (arguments.Count() != 1)
                throw new SquareRootRequiresOneArgumentException();
            try
            {
                return new SquareRootRequestDto(int.Parse(arguments.First()));
            }
            catch (Exception ex)
            {
                throw new SquareRootRequiresIntegerArgumentsException(ex);
            }
        }
    }
}
