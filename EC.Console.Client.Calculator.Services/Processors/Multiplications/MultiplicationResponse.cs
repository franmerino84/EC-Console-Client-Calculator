namespace EC.Console.Client.Calculator.Services.Processors.Multiplications
{
    public class MultiplicationResponse
    {
        public MultiplicationResponse(int product)
        {
            Product = product;
        }

        public int Product { get; }
    }
}
