using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Additions.Dtos
{
    public class AdditionResponse
    {
        public AdditionResponse(int sum)
        {
            Sum = sum;
        }

        public int Sum { get; }
    }
}
