namespace EC.Console.Client.Calculator.Services.Processors.Additions.Dtos
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
