namespace EC.Console.Client.Calculator.Services.Processors.Journals
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
