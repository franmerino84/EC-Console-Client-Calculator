using EC.Console.Client.Calculator.Services.Resolvers.Journals;

namespace EC.Console.Client.Calculator.Presentation.Processors
{
    public class JournalProcessor : IOperationProcessor
    {
        private readonly IOperationResolver<JournalResponse> _resolver;

        public JournalProcessor(IOperationResolver<JournalResponse> resolver)
        {
            _resolver = resolver;
        }

        public async Task Process(IEnumerable<string> arguments, string? trackingId)
        {
            var result = await _resolver.Resolve(arguments, trackingId);

            foreach (var operation in result.Operations)
            {
                System.Console.WriteLine($"{operation.Date} ({operation.Operation}): {operation.Calculation}");
            }
        }
    }
}
