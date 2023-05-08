namespace EC.Console.Client.Calculator.Services.Processors.Additions
{
    public class AdditionRequestDto
    {
        public AdditionRequestDto(IEnumerable<int> addends)
        {
            Addends = addends;
        }

        public IEnumerable<int> Addends { get; }
    }
}
