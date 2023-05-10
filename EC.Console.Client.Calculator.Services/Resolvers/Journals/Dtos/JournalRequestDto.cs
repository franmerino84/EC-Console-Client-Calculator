namespace EC.Console.Client.Calculator.Services.Resolvers.Journals.Dtos
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
