using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Presentation.Processors.Multiplications
{
    public class MultiplicationResponseDto
    {
        public MultiplicationResponseDto(int product)
        {
            Product = product;
        }

        [JsonPropertyName("product")]
        public int Product { get; }
    }
}
