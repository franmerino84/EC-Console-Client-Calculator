using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos
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
