namespace EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos
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
