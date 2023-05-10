using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class SquareRootProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<SquareRootResponse> _resolver;

        public SquareRootProcessor(IOperationResolver<SquareRootResponse> resolver)
        {
            _resolver = resolver;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _resolver.Resolve(arguments, trackingId);

            System.Console.WriteLine(result.Square);
        }
    }
}
