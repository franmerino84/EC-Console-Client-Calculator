using EC.Console.Client.Calculator.Services.Resolvers.Subtractions;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class SubtractionProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<SubtractionResponse> _resolver;

        public SubtractionProcessor(IOperationResolver<SubtractionResponse> resolver)
        {
            _resolver = resolver;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _resolver.Resolve(arguments, trackingId);

            System.Console.WriteLine(result.Difference);
        }
    }
}
