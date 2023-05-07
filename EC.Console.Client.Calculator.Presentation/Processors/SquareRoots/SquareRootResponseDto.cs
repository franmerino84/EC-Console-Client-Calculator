using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Presentation.Processors.SquareRoots
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
