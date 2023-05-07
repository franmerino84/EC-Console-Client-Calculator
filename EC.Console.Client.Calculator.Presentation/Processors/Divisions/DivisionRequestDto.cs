namespace EC.Console.Client.Calculator.Presentation.Processors.Divisions
{
    public class DivisionRequestDto
    {
        public DivisionRequestDto(int dividend, int divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }

        public int Dividend { get; }

        public int Divisor { get; }
    }
}
