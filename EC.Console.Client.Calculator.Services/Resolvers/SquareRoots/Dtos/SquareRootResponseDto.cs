using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Dtos
{
    public class SquareRootResponseDto
    {
        public SquareRootResponseDto(int square)
        {
            Square = square;
        }

        [JsonPropertyName("square")]
        public int Square { get; }
    }
}
