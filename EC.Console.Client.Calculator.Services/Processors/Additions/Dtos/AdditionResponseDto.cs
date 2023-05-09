using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Additions.Dtos
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
