using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Multiplications.Dtos
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
