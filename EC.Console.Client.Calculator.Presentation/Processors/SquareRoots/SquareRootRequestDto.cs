namespace EC.Console.Client.Calculator.Presentation.Processors.SquareRoots
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
