using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Divisions
{
    public class DivisionResponseDto
    {
        public DivisionResponseDto(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        [JsonPropertyName("quotient")]
        public int Quotient { get; }

        [JsonPropertyName("remainder")]
        public int Remainder { get; }
    }
}
