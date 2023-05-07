using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Presentation.Processors.Subtractions
{
    public class SubtractionResponseDto
    {
        public SubtractionResponseDto(int difference)
        {
            Difference = difference;
        }

        [JsonPropertyName("difference")]
        public int Difference { get; }
    }
}
