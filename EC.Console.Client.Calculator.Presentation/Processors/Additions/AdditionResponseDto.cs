using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Presentation.Processors.Additions
{
    public class AdditionResponseDto
    {
        public AdditionResponseDto(int sum)
        {
            Sum = sum;
        }

        [JsonPropertyName("sum")]
        public int Sum { get; }
    }
}
