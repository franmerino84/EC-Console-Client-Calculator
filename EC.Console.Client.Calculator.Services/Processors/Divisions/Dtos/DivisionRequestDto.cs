namespace EC.Console.Client.Calculator.Services.Processors.Divisions.Dtos
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
