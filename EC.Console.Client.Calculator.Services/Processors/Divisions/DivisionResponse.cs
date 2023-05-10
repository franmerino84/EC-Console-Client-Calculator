using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Processors.Divisions
{
    public class DivisionResponse
    {
        public DivisionResponse(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public int Quotient { get; }

        public int Remainder { get; }
    }
}
