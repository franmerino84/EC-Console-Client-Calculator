using EC.Console.Client.Calculator.Services.Resolvers.Multiplications;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class MultiplicationProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<MultiplicationResponse> _resolver;

        public MultiplicationProcessor(IOperationResolver<MultiplicationResponse> resolver)
        {
            _resolver = resolver;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _resolver.Resolve(arguments, trackingId);

            System.Console.WriteLine(result.Product);
        }
    }
}
