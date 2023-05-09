using CommandLine;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace EC.Console.Client.Calculator.Presentation.Client
{
    public class CalculatorClientConsoleArguments
    {
        [Value(0, Required = true, HelpText = "Operation to realize (sum/sub/mult/div/sqr/journal)")]
        public string Operation { get; set; }

        [Value(1, Required = true, HelpText = "Argument of the operation")]
        public IEnumerable<string> Arguments { get; set; }

        [Option('t', "trackingid", HelpText = "Tracking id of the request")]
        public string? TrackingId { get; set; }

    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
