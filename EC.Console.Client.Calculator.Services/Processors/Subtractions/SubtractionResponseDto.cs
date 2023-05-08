using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Subtractions
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
