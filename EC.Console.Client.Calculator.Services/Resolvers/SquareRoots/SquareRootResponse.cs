using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.SquareRoots
{
    public class SquareRootResponse
    {
        public SquareRootResponse(int square)
        {
            Square = square;
        }

        public int Square { get; }
    }
}
