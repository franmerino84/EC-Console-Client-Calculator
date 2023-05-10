using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class AdditionProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<AdditionResponse> _resolver;

        public AdditionProcessor(IOperationResolver<AdditionResponse> resolver)
        {
            _resolver = resolver;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _resolver.Resolve(arguments, trackingId);

            System.Console.WriteLine(result.Sum);
        }
    }
}
