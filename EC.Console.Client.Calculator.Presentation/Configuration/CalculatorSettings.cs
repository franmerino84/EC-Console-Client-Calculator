using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace EC.Console.Client.Calculator.Presentation.Configuration
{
    public class CalculatorSettings
    {
        [Required]
        public string CalculatorApiUrl { get; set; }
    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
