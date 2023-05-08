using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Multiplications
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
