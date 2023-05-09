namespace EC.Console.Client.Calculator.Services.Processors.Multiplications.Dtos
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
