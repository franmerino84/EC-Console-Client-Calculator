namespace EC.Console.Client.Calculator.Services.Processors.Journals.Dtos
{
    public class JournalRequestDto
    {
        public JournalRequestDto(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
