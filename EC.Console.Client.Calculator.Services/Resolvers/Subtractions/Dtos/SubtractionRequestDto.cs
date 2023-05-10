namespace EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Dtos
{
    public class SubtractionRequestDto
    {
        public SubtractionRequestDto(int minuend, int subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
        }

        public int Minuend { get; }

        public int Subtrahend { get; }
    }
}
