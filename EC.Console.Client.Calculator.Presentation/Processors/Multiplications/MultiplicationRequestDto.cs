namespace EC.Console.Client.Calculator.Presentation.Processors.Multiplications
{
    public class MultiplicationRequestDto
    {
        public MultiplicationRequestDto(IEnumerable<int> factors)
        {
            Factors = factors;
        }

        public IEnumerable<int> Factors { get; }
    }
}
