using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Journals.Dtos
{
    public class JournalResponseDto
    {
        public JournalResponseDto(IEnumerable<JournalQueryOperationDto> operations)
        {
            Operations = operations;
        }

        [JsonPropertyName("operations")]
        public IEnumerable<JournalQueryOperationDto> Operations { get; }
    }
}
