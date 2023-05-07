namespace EC.Console.Client.Calculator.Presentation.Processors.Additions
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
