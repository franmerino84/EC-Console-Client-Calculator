namespace EC.Console.Client.Calculator.Services.Resolvers.Journals
{
    public class JournalResponse
    {
        public JournalResponse(IEnumerable<JournalQueryOperation> operations)
        {
            Operations = operations;
        }

        public IEnumerable<JournalQueryOperation> Operations { get; }
    }
}
