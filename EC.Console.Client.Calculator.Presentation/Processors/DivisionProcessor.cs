using EC.Console.Client.Calculator.Services.Resolvers.Divisions;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class DivisionProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<DivisionResponse> _resolver;

        public DivisionProcessor(IOperationResolver<DivisionResponse> resolver)
        {
            _resolver = resolver;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _resolver.Resolve(arguments, trackingId);

            System.Console.WriteLine($"Quotient: {result.Quotient}. Remainder: {result.Remainder}");
        }
    }
}
