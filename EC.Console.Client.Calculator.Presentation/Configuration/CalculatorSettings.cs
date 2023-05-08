using System.ComponentModel.DataAnnotations;

namespace EC.Console.Client.Calculator.Presentation.Configuration
{
    public class CalculatorSettings
    {
        [Required]
        public string CalculatorApiUrl { get; set; }
    }
}