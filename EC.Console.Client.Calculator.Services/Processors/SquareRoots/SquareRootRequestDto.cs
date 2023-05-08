namespace EC.Console.Client.Calculator.Services.Processors.SquareRoots
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
