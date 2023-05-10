using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Dtos
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
