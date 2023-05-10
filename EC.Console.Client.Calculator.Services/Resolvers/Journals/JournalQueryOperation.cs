using System.Text.Json.Serialization;

namespace EC.Console.Client.Calculator.Services.Resolvers.Journals
{
    public class JournalQueryOperation
    {
        public JournalQueryOperation(string operation, string calculation, DateTime date)
        {
            Operation = operation;
            Calculation = calculation;
            Date = date;
        }

        public string Operation { get; }

        public string Calculation { get; }

        public DateTime Date { get; }
    }
}