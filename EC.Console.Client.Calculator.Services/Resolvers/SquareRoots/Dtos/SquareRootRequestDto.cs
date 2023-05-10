namespace EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Dtos
{
    public class SquareRootRequestDto
    {
        public SquareRootRequestDto(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }
}
